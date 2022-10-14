using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame.Classes
{
    public class Items
    {
        public enum KeyType
        {
            Brass,
            Silver,
            Gold,
        }
        public enum CombineCode
        {
            Red,
            Blue,
            Green,
        }
        public string Name { get; set; }
        public string ItemDescription { get; set; }
        public CombineCode CombineItem { get; set; }
        public Items(string name, string itemDescription, CombineCode combineCode) : this(name, itemDescription)
        {
            CombineItem = combineCode;
        }

        public Items(string name, string itemDescription)
        {
            Name = name;
            ItemDescription = itemDescription;
        }
    }
}
