using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame.Classes
{
    public static class Story
    {

        public static void Start()
        {
            Console.WriteLine("The mad mansion");
            Console.WriteLine("Name?: ");
            Rooms roomLobby = new Rooms(Rooms.Room.Lobby, false);
            Character player = new Character(Console.ReadLine(), roomLobby);
            Console.WriteLine("You wake up on the floor in what looks like the entrance of a mansion, you dont remember anything...");
            if (player.Name == "")
                Console.WriteLine("Not even your name");
            else
                Console.WriteLine($"Except your name {player.Name}");
            Console.ReadKey();
            GameFlow(player);
        }
        public static Character GameFlow(Character player)
        {
            while (true)
            {
                Console.Clear();
                while (true)
                {
                    Rooms.RoomInfo(player);
                    Console.WriteLine("Type \"Help\" to see commands");
                    Console.WriteLine("What would you like to do?");
                    string playerInput = Console.ReadLine();
                    if (playerInput.ToLower() == "Help".ToLower())
                        Help();
                    Console.Clear();
                    if (playerInput.ToLower().Contains("go"))
                        player.MoveChar(player);
                }
            }
        }
        public static void Help()
        {
            Console.WriteLine("Commands: Go - North/East/South/West");
            Console.ReadKey();
        }

    }

}
