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
        public Items SelectedItem { get; set; }
        public List<Items> ItemList { get; set; }
        public Room CurrentRoom { get; set; }

        public Character(string name, Room currentRoom, List<Items> itemList)
        {
            Name = name;
            CurrentRoom = currentRoom;
            ItemList = itemList;
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

        public Character PickupItem(Character player, string itemToPickup)
        {
            var result = player.CurrentRoom.ItemList.Where(item => item.Name.ToLower() == itemToPickup.ToLower()).Single();
            player.ItemList.Add(result);
            player.CurrentRoom.ItemList.Remove(result);
            Console.WriteLine($"You picked up {result.Name}");
            return player;
        }
        public Character DropItem(Character player, string itemToDrop)
        {
            var result = player.ItemList.Where(item => item.Name.ToString().ToLower() == itemToDrop).SingleOrDefault();
            player.CurrentRoom.ItemList.Add(result);
            player.ItemList.Remove(result);
            Console.WriteLine($"You dropped {result.Name}");
            return player;
        }
        public void UseItem(Character player, string itemChoice, string direction, string whatToUseOn)
        {
            if (player.SelectedItem.ItemDescription.ToLower().Contains(player.CurrentRoom.Name.ToString().ToLower()))
            {
                if (direction == "west")
                {
                    player.CurrentRoom.WestExit.Locked = false;
                    Console.WriteLine("You unlocked the west door");
                }
                if (direction == "north")
                {
                    player.CurrentRoom.NorthExit.Locked = false;
                    Console.WriteLine("You unlocked the north door");

                }
                if (direction == "east")
                {
                    player.CurrentRoom.EastExit.Locked = false;
                    Console.WriteLine("You unlocked the east door");
                }
                if (direction == "south")
                {
                    player.CurrentRoom.SouthExit.Locked = false;
                    Console.WriteLine("You unlocked the south door");
                }

                foreach (var item in player.ItemList)
                {
                    if (item.Name.ToLower() == itemChoice.ToLower())
                    {
                        ItemList.Remove(item);
                        break;
                    }
                }
            }

            if (itemChoice.Contains("key"))
            {
                
            }

            foreach (var item in player.ItemList)
            {
                if (item.Name.ToString().ToLower() == itemChoice.ToLower())
                {
                    if (player.CurrentRoom.NorthExit.Locked == true && item.Name.ToString().ToLower() == "key")
                    {
                        player.CurrentRoom.NorthExit.Locked = false;
                        player.ItemList.Remove(item);
                        break;
                    }
                }

            }
                
        }
        public void Inspect(Character player, string whatToInspect)
        {
            if (whatToInspect.ToLower().Contains("room"))
            {
                Console.Clear();
                Console.WriteLine(player.CurrentRoom.RevisitDescription);
                if (player.CurrentRoom.ItemList != null)
                {
                    foreach (var item in player.CurrentRoom.ItemList)
                    {
                        Console.WriteLine($"\nIn the room you can also see a {item.Name}");
                    }
                }
            }
            if (whatToInspect.ToLower().Contains("items"))
            {
                Console.Clear();
                Console.WriteLine("These are the items you have:\n");
                foreach (var item in player.ItemList)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                foreach (var item in player.ItemList)
                {
                    if (whatToInspect.ToLower() == item.ToString().ToLower())
                        Console.WriteLine(item.ItemDescription);
                }
            }

        }
    }
    
}
