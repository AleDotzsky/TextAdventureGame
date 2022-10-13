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
        public string Name { get; set; }
        public string ItemDescription { get; set; }
        public KeyType KeyMatch { get; set; }

        public Items(string name, string itemDescription, KeyType keyMatch) : this(name, itemDescription)
        {
            KeyMatch = keyMatch;
        }

        public Items(string name, string itemDescription)
        {
            Name = name;
            ItemDescription = itemDescription;
        }
    }
}
