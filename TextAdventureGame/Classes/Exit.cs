using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame.Classes
{
    public class Exit
    {
        public enum Direction
        {
            North,
            East,
            South,
            West,
        }
        public string Description { get; set; }
        public bool Locked { get; set; }
        public Room Room { get; set; }

        public Exit(bool locked, Room room, string description)
        {
            Locked = locked;
            Room = room;
            Description = description;
        }       
    }
}
