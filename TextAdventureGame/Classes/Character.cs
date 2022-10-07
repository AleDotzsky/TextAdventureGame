using System;
using System.Collections.Generic;
using System.Linq;
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
    public class Character
    {
        public string Name { get; set; }
        public MoveDirection Move { get; set; }
        public List<Items> ItemList { get; set; }
        public Rooms CurrentRoom { get; set; }

        public Character(string name, Rooms currentRoom)
        {
            Name = name;
        }

        public void MoveChar(Character player)
        {
            if(player.Move == MoveDirection.North)
            {

            }
        }

        public void PickupItem()
        {

        }
        public void DropItem()
        {

        }
    }
    
}
