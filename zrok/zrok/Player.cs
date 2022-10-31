﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zrok
{
    public class Player
    {
        private Room room;
        private Inventory Inventory;

        public Player()
        {
            room = Setup();
            Inventory = new Inventory();
        }

        public Room GetRoom()
        {
            return room;
        }

        public Inventory GetInventory()
        {
            return Inventory;
        }

        private Room Setup()
        {
            //above ground
            Room WestOfHouse = new Room("West of House", "west of house");
            Room SouthOfHouse = new Room("South Of House", "");
            Room BehindHouse = new Room("Behind House", "");
            Room NorthOfHouse = new Room("North Of House", "");
            Room ForestPath = new Room("Forest Path", "");
            Room UpaTree = new Room("Up a Tree", "");
            Room Clearing1 = new Room("Clearing", "");
            Room Clearing2 = new Room("Clearing", "");
            Room Forest1 = new Room("Forest", "");
            Room Forest2 = new Room("Forest", "");
            Room Forest3 = new Room("Forest", "");
            Room Forest4 = new Room("Forest", "");
            Room CanyonView = new Room("Canyon View", "");
            Room RockyLedge = new Room("Rocky Ledge", "");
            Room CanyonBottom = new Room("Canyon Bottom", "");
            Room EndOfRainbow = new Room("End of Rainbow", "");
            Room Kitchen = new Room("Kitchen", "");

            //west of house exits
            WestOfHouse.AddExit(Direction.North, NorthOfHouse);
            WestOfHouse.AddExit(Direction.West, Forest1);
            WestOfHouse.AddExit(Direction.South, SouthOfHouse);

            //north of house exits
            NorthOfHouse.AddExit(Direction.North, ForestPath);
            NorthOfHouse.AddExit(Direction.West, WestOfHouse);
            NorthOfHouse.AddExit(Direction.East, BehindHouse);

            //south of house exits
            SouthOfHouse.AddExit(Direction.West, WestOfHouse);
            SouthOfHouse.AddExit(Direction.East, BehindHouse);
            SouthOfHouse.AddExit(Direction.South, Forest3);

            //behind house exits
            BehindHouse.AddExit(Direction.North, NorthOfHouse);
            BehindHouse.AddExit(Direction.South, SouthOfHouse);
            BehindHouse.AddExit(Direction.East, Clearing1);

            //clearing 1 exits
            Clearing1.AddExit(Direction.East, CanyonView);
            Clearing1.AddExit(Direction.West, BehindHouse);
            Clearing1.AddExit(Direction.South, Forest3);
            Clearing1.AddExit(Direction.North, Forest2);

            //canyon view exits
            CanyonView.AddExit(Direction.South, Forest3);
            CanyonView.AddExit(Direction.NorthWest, BehindHouse);

            //underground
            Room Cellar= new Room("Cellar", "");
            Room  EastOfChasmRoom = new Room("East of Chasm", "");
            Room Gallery= new Room("", "");
            Room Studio= new Room("", "");
            Room StrangePassage= new Room("", "");
            Room CyclopsRoom= new Room("", "");
            Room TreasureRoom= new Room("", "");
            Room TrollRoom= new Room("", "");
            Room EastWestPassage= new Room("", "");
            Room RoundRoom= new Room("", "");
            Room NarrowPassage= new Room("", "");
            Room SouthMirrorRoom= new Room("", "");
            Room WindingPassage= new Room("", "");
            Room Cave= new Room("", "");
            Room EntranceToHades= new Room("", "");


            return WestOfHouse;
        }

        public void Move(Direction direction)
        {
            Room destination;

            if (room.GetExits().TryGetValue(direction, out destination))
            {
                room = destination;
            }
            else
            {
                Console.WriteLine("You cannot go that way");
            }
        }

        public void TakeObject(string Object)
        {
            Item item = this.room.RemoveItem(Object);

            bool confirmed = this.Inventory.Add(item);
            if (confirmed)
            {
                Console.WriteLine("Taken");
            }
            else
            {
                Console.WriteLine("You are holding too many items");
            }

        }

        public void TakeAll()
        {
            int count = 0;
            foreach (Item value in room.GetItems())
            {
                Item item = this.room.RemoveItem(value.GetName());

                bool confirmed = this.Inventory.Add(item);
                if (confirmed)
                {
                    count++;
                    Console.WriteLine($"Taken {value.GetName()}");
                }
                else
                {
                    Console.WriteLine("You are holding too many items");
                    Console.WriteLine($"Took {count} items");
                    return;
                }
            }
        }

        public void DropObject(string Object)
        {
            this.room.AddItem(this.Inventory.Remove(Object));
            Console.WriteLine("Dropped");
        }

        public void LookAt(string Object)
        {
            if (Object == room.GetName())
            {

            }
        }
    }
}
