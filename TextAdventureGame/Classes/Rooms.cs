using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame.Classes
{
    public class Rooms
    {
        public enum Room
        {
            Lobby,
            DiningRoom,
            ArtRoom,
            GreatHall,
            Yard,
        }
        public Room ActiveRoom { get; set; }
        public bool EndPoint { get; set; }
        public bool Visited { get; set; }
        public Items Item { get; set; }

        public Rooms(Room activeRoom, bool visited)
        {
            ActiveRoom = activeRoom;
            Visited = visited;
        }

        public static void RoomInfo(Character player)
        {
            if (player.CurrentRoom.ActiveRoom == Room.Lobby)
            {
                if (player.CurrentRoom.Visited == false)
                {
                    Console.WriteLine("You find yourself in a grand entryhall with a big chandelier hanging from the roof, to your north there is a big door" +
                        "that looks locked. To your east there is a closed door. To your west there is a open door and you think you can see a big table inside");
                    player.CurrentRoom.Visited = true;
                }
                    
                else
                    Console.WriteLine("You are back in the entrance room, nothing of note here.");
            }
            if (player.CurrentRoom.ActiveRoom == Room.DiningRoom)
                if(player.CurrentRoom.Visited == false)
                {
                    Console.WriteLine("Dining room first time");
                    player.CurrentRoom.Visited = true;
                }
                else
                {
                    Console.WriteLine("dinign second time");
                }
        }

    }
}
