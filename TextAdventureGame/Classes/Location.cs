using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame.Classes
{
    public class Location
    {
        public Exit Door { get; set; }
        public bool EndPoint { get; set; }
        public bool Visited { get; set; }
        public Items Item { get; set; }

    }
}
