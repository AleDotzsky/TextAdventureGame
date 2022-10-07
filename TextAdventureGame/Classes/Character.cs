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

        public void MoveChar()
        {

        }

        public void PickupItem()
        {

        }
        public void DropItem()
        {

        }
    }
    
}
