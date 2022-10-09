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
            Items item = new Items("Key");

            Room lobby = new Room("Lobby", "Lobby first time", "Lobby second time");
            Room diningRoom = new Room("Dining room", "Dining room first time", "Dining room second time");
            Room kitchen = new Room("Kitchen", "Kitchen first time", "Kitchen second time");
            Room artRoom = new Room("Art Room", "Art room first time, key on floor", "art room second time, key on floor", item);
            Room barRoom = new Room("Bar room", "Bar first time", "Bar second time");
            Room greatHall = new Room("Great Hall", "Great hall first time", "Great hall second time");
            Room office = new Room("Office", "office first time", "office second time");
            Room yard = new Room("Yard", "yard first time", "yard second time");
            Room shed = new Room("Shed", "Shed first time", "Shed second time");

            lobby.AddExit(diningRoom, false, Exit.Direction.West);
            lobby.AddExit(greatHall, true, Exit.Direction.North);
            lobby.AddExit(artRoom, false, Exit.Direction.East);
            diningRoom.AddExit(kitchen, false, Exit.Direction.North);
            artRoom.AddExit(barRoom, false, Exit.Direction.North);
            greatHall.AddExit(office, false, Exit.Direction.East);
            greatHall.AddExit(yard, false, Exit.Direction.North);
            yard.AddExit(shed, false, Exit.Direction.West);







            Console.WriteLine("The mad mansion");
            Console.WriteLine("Name?: ");
            Character player = new Character(Console.ReadLine(), lobby);
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
                player.CurrentRoom.RoomInfo();
                MoveStatus moveStatus = player.MoveChar((MoveDirection)Enum.Parse(typeof(MoveDirection), Console.ReadLine(), true));
                switch (moveStatus)
                {
                    case MoveStatus.NoExit:
                        Console.WriteLine("inget här");
                        Console.ReadKey();
                        break;
                    case MoveStatus.Locked:
                        Console.WriteLine("låst");
                        Console.ReadKey();
                        break;
                }

            }
            //while (true)
            //{
            //    Console.Clear();
            //    while (true)
            //    {
            //        player.CurrentRoom.RoomInfo();
            //        Console.WriteLine("Type \"Help\" to see commands");
            //        Console.WriteLine("What would you like to do?");
            //        string playerInput = Console.ReadLine();
            //        if (playerInput.ToLower() == "Help".ToLower())
            //            Help();
            //        Console.Clear();
            //        if (playerInput.ToLower().Contains("go"))
            //            player.MoveChar(player);
            //    }
            //}
        }
        public static void Help()
        {
            Console.WriteLine("Commands: Go - North/East/South/West");
            Console.ReadKey();
        }

    }

}
