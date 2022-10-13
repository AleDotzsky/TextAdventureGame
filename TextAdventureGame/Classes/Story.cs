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
            List<Items> playerItemList = new List<Items>();

            List<Items> lobbyItemList = new List<Items>();
            List<Items> diningRoomItemList = new List<Items>();
            List<Items> kitchenItemList = new List<Items>();
            List<Items> artRoomItemList = new List<Items>();
            List<Items> barRoomItemList = new List<Items>();
            List<Items> greatHallItemList = new List<Items>();
            List<Items> officeItemList = new List<Items>();
            List<Items> yardItemList = new List<Items>();
            List<Items> shedItemList = new List<Items>();

            Items key = new("Key", "Its a dusty old key with the word lobby printed on it");

            Room lobby = new Room("Lobby", "Lobby first time", "Lobby second time", lobbyItemList);
            Room diningRoom = new Room("Dining room", "Dining room first time", "Dining room second time", diningRoomItemList);
            Room kitchen = new Room("Kitchen", "Kitchen first time", "Kitchen second time", kitchenItemList);
            Room artRoom = new Room("Art Room", "Art room first time", "art room second time", artRoomItemList);
            Room barRoom = new Room("Bar room", "Bar first time", "Bar second time", barRoomItemList);
            Room greatHall = new Room("Great Hall", "Great hall first time", "Great hall second time", greatHallItemList);
            Room office = new Room("Office", "office first time", "office second time", officeItemList);
            Room yard = new Room("Yard", "yard first time", "yard second time", yardItemList);
            Room shed = new Room("Shed", "Shed first time", "Shed second time", shedItemList);

            artRoom.ItemList.Add(key);

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
            Character player = new Character(Console.ReadLine(), lobby, playerItemList);
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
                Console.WriteLine("What do you want to do? Write \"Help\" to see commandlist");
                player.CurrentRoom.RoomInfo();
                string val = "";
                string firstInput = "";
                string secondInput = "";
                string thirdInput = "";
                string fourthInput = "";

                val = Console.ReadLine().ToLower();
                firstInput = val.Split(' ')[0];
                if (val.Split(' ').Length > 1)
                {
                    secondInput = val.Split(' ')[1];
                    if (val.Split(' ').Length > 2)
                    {
                        thirdInput = val.Split(' ')[2];
                        if (val.Split(' ').Length > 3)
                            fourthInput = val.Split(' ')[3];
                    }


                }

                switch (firstInput)
                {
                    case "go":
                        MoveStatus moveStatus = player.MoveChar((MoveDirection)Enum.Parse(typeof(MoveDirection), secondInput, true));
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
                        break;
                    case "help":
                        Help();
                        break;
                    case "pickup":
                        player = player.PickupItem(player, secondInput);
                        Console.ReadKey();
                        break;
                    case "drop":
                        player = player.DropItem(player, secondInput);
                        Console.ReadKey();
                        break;
                    case "use":
                        foreach (var item in player.ItemList)
                        {
                            if(item.Name.ToString().ToLower() == secondInput)
                            {
                                player.SelectedItem = item;
                                player.UseItem(player, secondInput, thirdInput, fourthInput);
                                break;
                            }
                        }
                        Console.ReadKey();
                        break;
                    case "inspect":
                        player.Inspect(player, secondInput);
                        Console.ReadKey();
                        break;
                    case "combine":
                        break;
                    default:
                        Console.WriteLine("Felaktig inmatning, försök igen");
                        Console.ReadKey();
                        break;
                }
            }
            
            while (true)
            {
                

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
            Console.Clear();
            Console.WriteLine("To move simply write \"Go\" North/East/South/West\nTo use write use\nTo pickup write pickup");
            Console.ReadKey();
        }

    }

}
