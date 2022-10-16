using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame.Classes
{
    public enum MoveDirection
    {
        North,
        South,
        West,
        East,
    }
    public enum MoveStatus
    {
        NoExit,
        Locked,
        Success,
    }
    public class Character
    {
        public string Name { get; set; }
        public List<Item> ItemList { get; set; }
        public Room CurrentRoom { get; set; }

        public Character(string name, Room currentRoom)
        {
            Name = name;
            CurrentRoom = currentRoom;
            ItemList = new List<Item>();
        }

        public MoveStatus MoveChar(MoveDirection direction)
        {
            Exit exit = direction switch
            {
                MoveDirection.North => CurrentRoom.NorthExit,
                MoveDirection.South => CurrentRoom.SouthExit,
                MoveDirection.West => CurrentRoom.WestExit,
                MoveDirection.East => CurrentRoom.EastExit,
            };

            if (exit == null)
                return MoveStatus.NoExit;
            if (exit.Locked) 
                return MoveStatus.Locked;
            CurrentRoom.Visited = true;
            CurrentRoom = exit.Room;
            return MoveStatus.Success;
        }

        public void PickupItem(string itemToPickup)
        {
            var result = CurrentRoom.ItemList.Where(item => item.Name.ToLower() == itemToPickup.ToLower()).Single();
            ItemList.Add(result);
            CurrentRoom.ItemList.Remove(result);
            Console.WriteLine($"You picked up {result.Name}");
        }
        public void DropItem(string itemToDrop)
        {
            var result = ItemList.Where(item => item.Name.ToString().ToLower() == itemToDrop).SingleOrDefault();
            CurrentRoom.ItemList.Add(result);
            ItemList.Remove(result);
            Console.WriteLine($"You dropped {result.Name}");
        }
        public void UseItem(string itemChoice, string direction, string whatToUseOn)
        {
            var item = ItemList.Find(item => item.Name.ToLower() == itemChoice);

            if (item.ItemDescription.ToLower().Contains(CurrentRoom.Name.ToString().ToLower()))
            {
                if (direction == "west")
                {
                    CurrentRoom.WestExit.Locked = false;
                    Console.WriteLine("You unlocked the west door");
                }
                if (direction == "north")
                {
                    CurrentRoom.NorthExit.Locked = false;
                    Console.WriteLine("You unlocked the north door");

                }
                if (direction == "east")
                {
                    CurrentRoom.EastExit.Locked = false;
                    Console.WriteLine("You unlocked the east door");
                }
                if (direction == "south")
                {
                    CurrentRoom.SouthExit.Locked = false;
                    Console.WriteLine("You unlocked the south door");
                }
                ItemList.RemoveAll(item => item.Name.ToLower() == itemChoice);
            }
        }
        public void Inspect(string whatToInspect, string direction = null)
        {
            if (whatToInspect.ToLower().Contains("room"))
            {
                Console.Clear();
                Console.WriteLine(CurrentRoom.FirstVisitDescription);
                if (CurrentRoom.ItemList != null)
                {
                    foreach (var roomItem in CurrentRoom.ItemList)
                    {
                        Console.WriteLine($"\nIn the room you can see a {roomItem.Name}");
                    }                    
                }
                Console.WriteLine("\nIn the room you can also see these exits:\n");
                if (CurrentRoom.NorthExit != null)
                    Console.WriteLine($"To the north you can see an exit leading to the {CurrentRoom.NorthExit.Room.Name}");
                if (CurrentRoom.EastExit != null)
                    Console.WriteLine($"To the east you can see an exit leading to the {CurrentRoom.EastExit.Room.Name}");
                if (CurrentRoom.SouthExit != null)
                    Console.WriteLine($"To the south you can see an exit leading to the {CurrentRoom.SouthExit.Room.Name}");
                if (CurrentRoom.WestExit != null)
                    Console.WriteLine($"To the west you can see an exit leading to the {CurrentRoom.WestExit.Room.Name}");
            }
            if (whatToInspect.ToLower().Contains("items"))
            {
                Console.Clear();
                Console.WriteLine("These are the items you have:\n");
                foreach (var playerItem in ItemList)
                {
                    Console.WriteLine(playerItem.Name);
                }
            }
            if (whatToInspect.Contains("door"))
            {
                if ((direction == "north") && (CurrentRoom.NorthExit != null))
                    Console.WriteLine($"{CurrentRoom.NorthExit.Description}");
                if ((direction == "east") && (CurrentRoom.EastExit != null))
                    Console.WriteLine($"{CurrentRoom.EastExit.Description}");
                if ((direction == "south") && (CurrentRoom.SouthExit != null))
                    Console.WriteLine($"{CurrentRoom.SouthExit.Description}");
                if ((direction == "west") && (CurrentRoom.WestExit != null))
                    Console.WriteLine($"{CurrentRoom.WestExit.Description}");
                else
                {
                    Console.WriteLine("There is no door there");
                    Console.ReadKey();
                }
            }
            var item = ItemList.Find(item => item.Name.ToLower() == whatToInspect);
            if ((item != null) && (item.Name == whatToInspect))
            {
                Console.WriteLine(item.ItemDescription);
                Console.ReadKey();
            }
        }
        public void CombineItems(string firstItem, string secondItem)
        {
            string switchController = "";
            Item item1 = ItemList.Where(x => x.Name.ToLower() == firstItem).FirstOrDefault();
            Item item2 = ItemList.Where(x => x.Name.ToLower() == secondItem).FirstOrDefault();
            if (item1.CombineItem == Item.CombineCode.Red && item2.CombineItem == Item.CombineCode.Red)
            {
                if(item1.Name.ToLower().Contains("can") && item2.Name.ToLower().Contains("can"))
                {
                    switchController = "can";
                }
                switch (switchController)
                {
                    case "can":
                        ItemList.Remove(item1);
                        ItemList.Remove(item2);
                        ItemList.Add(new Item("OpenCan", "An opened can of beans, yum!"));
                        Console.WriteLine("You opened the can and its full of beans");
                        break;
                    default:
                        break;
                }
            }
        }
    }
    
}
