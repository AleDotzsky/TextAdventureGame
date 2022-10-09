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

        public Character(string name, Room currentRoom)
        {
            Name = name;
            CurrentRoom = currentRoom;
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

        public void PickupItem()
        {

        }
        public void DropItem()
        {

        }
    }
    
}
