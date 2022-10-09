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
        public Items Item { get; set; }
        public Exit NorthExit { get; set; }
        public Exit EastExit { get; set; }
        public Exit SouthExit { get; set; }
        public Exit WestExit { get; set; }


        public Room(string name, string firstVisitDescription, string revisitDescription)
        {
            Name = name;
            FirstVisitDescription = firstVisitDescription;
            RevisitDescription = revisitDescription;
        }

        public Room(string name, string firstVisitDescription, string revisitDescription, Items item)
        {
            Name = name;
            FirstVisitDescription = firstVisitDescription;
            RevisitDescription = revisitDescription;
            Item = item;
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
        public void AddItem()
        {

        }
        public void AddExit(Room otherRoom, bool locked, Direction direction)
        {
            Exit exitToOtherRoom = new Exit(locked, otherRoom);
            Exit exitToThisRoom = new Exit(false, this);


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
