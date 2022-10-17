using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame.Classes
{
    public static class Story
    {

        public static void Start()
        {
            Console.WriteLine("Welcome to the mad mansion");
            Console.WriteLine("Name?: ");

            var state = new GameState(Console.ReadLine());

            Console.WriteLine("You wake up on the floor in what looks like the entrance of a mansion, you dont remember anything...");
            if (state.Player.Name == "")
                Console.WriteLine("Not even your name");
            else
                Console.WriteLine($"Except your name {state.Player.Name}");
            Console.ReadKey();
            GameFlow(state);
        }
        public static Character GameFlow(GameState state)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What do you want to do? Write \"Help\" to see commandlist");
                state.Player.CurrentRoom.RoomInfo();
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
                        var direction = secondInput switch
                        {
                            "north" => MoveDirection.North,
                            "east" => MoveDirection.East,
                            "south" => MoveDirection.South,
                            "west" => MoveDirection.West,
                            _ => (MoveDirection?)null,
                        };
                        if (direction == null)
                        {
                            Console.WriteLine($"Unknown direction '{secondInput}' try one of: North, East, South, West.");
                            Console.ReadKey();
                            continue;
                        }
                        MoveStatus moveStatus = state.Player.MoveChar(direction.Value);
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
                        var itemPickup = state.Player.CurrentRoom.ItemList.Find(item => item.Name.ToLower() == secondInput);
                        if (itemPickup != null)
                        {
                            state.Player.PickupItem(secondInput);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("I did not understand what you want to pickup");
                            Console.ReadKey();
                        }
                        break;
                    case "drop":
                        var itemDrop = state.Player.ItemList.Find(item => item.Name.ToLower() == secondInput);
                        if (itemDrop != null)
                        {
                            state.Player.DropItem(secondInput);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("I did not understand what you want to drop");
                            Console.ReadKey();
                        }
                        break;
                    case "use":
                        var itemUse = state.Player.ItemList.Find(item => item.Name.ToLower() == secondInput);
                        if((itemUse != null) && (thirdInput == "north") || (thirdInput == "south") || (thirdInput == "east") || (thirdInput == "west"))
                        {
                            state.Player.UseItem(secondInput, thirdInput, fourthInput);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You cannot use it like that");
                            Console.ReadKey();
                        }
                        break;
                    case "inspect":
                        var itemInspect = state.Player.ItemList.Find(item => item.Name.ToLower() == secondInput);
                        if ((itemInspect != null) || (thirdInput == "door") || (secondInput == "room") || (secondInput == "items"))
                        {
                            state.Player.Inspect(secondInput, thirdInput);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("I did not understand what you want to inspect");
                            Console.ReadKey();
                        }
                        break;
                    case "look":
                        var itemLook = state.Player.ItemList.Find(item => item.Name.ToLower() == secondInput);
                        if ((itemLook != null) || (secondInput == "door") || (secondInput == "room") || (secondInput == "items"))
                        {
                            state.Player.Inspect(secondInput, thirdInput);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("I did not understand what you want to look at");
                            Console.ReadKey();
                        }
                        break;
                    case "combine":
                        var itemFirstItem = state.Player.ItemList.Find(item => item.Name.ToLower() == secondInput);
                        var itemSecondItem = state.Player.ItemList.Find(item => item.Name.ToLower() == thirdInput);
                        if(itemFirstItem != null && itemSecondItem != null)
                        {
                            state.Player.CombineItems(secondInput, thirdInput);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("I do not know how to combine those");
                            Console.ReadKey();
                        }
                        break;
                    default:
                        Console.WriteLine("I did not understand that, maybe you wrote something wrong?");
                        Console.ReadKey();
                        break;
                }                
                if (state.Player.CurrentRoom.EndPoint == true)
                {
                    Console.Clear();
                    Console.WriteLine("You successfully escaped the mad mansion and survived!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }
        public static void Help()
        {
            Console.Clear();
            Console.WriteLine("To move simply write: \"Go\" North/East/South/West" +
                "\nTo use write: \"use key north door\"" +
                "\nTo pickup write: pickup \"itemname\" " +
                "\nTo drop write: drop \"itemname\" " +
                "\nTo inspect/look write: \"look door north\" - or - inspect \"itemname\" - or - look \"items\" " +
                "\nTo combine two items write: combine \"item1\" \"item2\"");
            Console.ReadKey();
        }

    }

}
