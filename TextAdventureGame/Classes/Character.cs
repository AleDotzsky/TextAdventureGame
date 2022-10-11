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

        public List<Items> PickupItem(Character player, string itemToPickup)
        {
            //player.ItemList.Add();
            return ItemList;
        }
        public void DropItem(Character player)
        {

        }
        public void UseItem(Character player, string itemChoice)
        {
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
        public void Inspect(Character player)
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
    }
    
}
