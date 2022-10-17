using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static TextAdventureGame.Classes.Exit;

namespace TextAdventureGame.Classes
{
    public class Room
    {
        public string Name { get; set; }
        public string FirstVisitDescription { get; set; }
        public string RevisitDescription { get; set; }
        public bool EndPoint { get; set; }
        public bool Visited { get; set; }
        public List<Item> ItemList { get; set; }
        public Exit NorthExit { get; set; }
        public Exit EastExit { get; set; }
        public Exit SouthExit { get; set; }
        public Exit WestExit { get; set; }


        public Room(string name, string firstVisitDescription, string revisitDescription)
        {
            Name = name;
            FirstVisitDescription = firstVisitDescription;
            RevisitDescription = revisitDescription;
            ItemList = new List<Item>();
        }

        public void RoomInfo()
        {
            if(Visited == true)
            {
                Console.WriteLine(RevisitDescription);
            }
            else
            {
                Console.WriteLine(FirstVisitDescription);
            }
        }
        public void AddExit(Room otherRoom, bool locked, Direction direction, string exitToDescription, string exitFromDescription)
        {
            Exit exitToOtherRoom = new Exit(locked, otherRoom, exitToDescription);
            Exit exitToThisRoom = new Exit(false, this, exitFromDescription);


            switch (direction)
            {
                case Direction.North:
                    NorthExit = exitToOtherRoom;
                    otherRoom.SouthExit = exitToThisRoom;
                    break;
                case Direction.East:
                    EastExit = exitToOtherRoom;
                    otherRoom.WestExit = exitToThisRoom;
                    break;
                case Direction.South:
                    SouthExit = exitToOtherRoom;
                    otherRoom.NorthExit = exitToThisRoom;
                    break;
                case Direction.West:
                    WestExit = exitToOtherRoom;
                    otherRoom.EastExit = exitToThisRoom;
                    break;
            }
        }
    }
}
