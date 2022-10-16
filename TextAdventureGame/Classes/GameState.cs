using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame.Classes
{
    public class GameState
    {
        public Character Player { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Item> Items { get; set; }

        public GameState(string playerName)
        {
            Item key = new Item("Key", "Its a dusty old key with the word lobby printed on it");
            Item endKey = new Item("BigKey", "Its a big old metal key, looks like it could fit on the gate in the yard");
            Item canOpener = new Item("CanOpener", "A opener for standard cans of food, smells faintly of beans", Item.CombineCode.Red);
            Item canOfBeans = new Item("TinCan", "A tincan with something inside", Item.CombineCode.Red);

            Room lobby = new Room("Lobby", "Lobby first time", "Lobby second time");
            Room diningRoom = new Room("Dining room", "Dining room first time", "Dining room second time");
            Room kitchen = new Room("Kitchen", "Kitchen first time", "Kitchen second time");
            Room artRoom = new Room("Art Room", "Art room first time", "art room second time");
            Room barRoom = new Room("Bar room", "Bar first time", "Bar second time");
            Room greatHall = new Room("Great Hall", "Great hall first time", "Great hall second time");
            Room office = new Room("Office", "office first time", "office second time");
            Room yard = new Room("Yard", "yard first time", "yard second time");
            Room shed = new Room("Shed", "Shed first time", "Shed second time");
            Room winRoom = new Room("Winroom", "", "");

            //AddItemUse(key, lobby.NorthExit, (_, exit) => exit.locked = false);

            //ReadFile(string filepath, () )

            artRoom.ItemList.Add(key);
            shed.ItemList.Add(endKey);

            lobby.AddExit(diningRoom, false, Exit.Direction.West, "A open door and there looks to be a dining room inside", "The doorway back out to the lobby");
            lobby.AddExit(greatHall, true, Exit.Direction.North, "A grand door that looks like it leads to a great hall", "A grand door that leads back to the lobby");
            lobby.AddExit(artRoom, false, Exit.Direction.East, "This door has splashes of paint on it, maybe someone who paints lives there?", "This door leads back to the lobby i woke up in");
            diningRoom.AddExit(kitchen, false, Exit.Direction.North, "This door has food stains and grease on it, maybe it leads to a kitchen?", "The door back to the dining room");
            artRoom.AddExit(barRoom, false, Exit.Direction.North, "A nice luxurious door, must be something nice behind it!", "The door back to the art room");
            greatHall.AddExit(office, false, Exit.Direction.East, "The door looks very much like a normal door, maybe there is something normal behind it?", "This door leads back to the great hall");
            greatHall.AddExit(yard, false, Exit.Direction.North, "I can hear the wind seeping through the cracks of the door, maybe it leads outside?", "This door leads back to the great hall");
            yard.AddExit(shed, false, Exit.Direction.West, "Its a small run down shed with a slighty open and damaged door", "This door leads back outside to the yard");
            yard.AddExit(winRoom, true, Exit.Direction.North, "Its a big metal gate with a lock, it looks like it could be my only way out of this mansion!", "");
            winRoom.EndPoint = true;

            Player = new Character(playerName, lobby);

            Player.ItemList.Add(canOpener);
            Player.ItemList.Add(canOfBeans);

            Items = new List<Item> { key, canOfBeans, canOpener};
            Rooms = new List<Room> { lobby, diningRoom, kitchen, artRoom, barRoom, greatHall, office, yard, shed };
        }
    }
}
