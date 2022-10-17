using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame.Classes
{
    public class Item
    {
        public enum CombineCode
        {
            Red,
            Blue,
            Green,
        }
        public string Name { get; set; }
        public string ItemDescription { get; set; }
        public bool CanBePickedUp { get; set; }
        public CombineCode CombineItem { get; set; }
        public Item(string name, string itemDescription, CombineCode combineCode) : this(name, itemDescription)
        {
            CombineItem = combineCode;
        }

        public Item(string name, string itemDescription)
        {
            Name = name;
            ItemDescription = itemDescription;
        }
    }
}
