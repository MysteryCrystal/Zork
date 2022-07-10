﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zrok
{
    partial class Adventure
    {
        private Room Room;

        public Adventure()
        {
            Room = new Room();
        }

        static Room SetupFromFile(string filename)
        {
            //create map using file
            return null;
        }

        public static void ParseCommand(string command)
        {
            
        }

        static Room Setup(string filename)
        {
            Room room;
            if (filename != "")
            {
                return room = SetupFromFile(filename);
            }
            else
            {
                Room main = new Room("Main", "This is the main room.");
                Room eastWing = new Room("East Wing", "This is the east wing.") { };

                main.AddExit(Direction.East, eastWing);
                eastWing.AddExit(Direction.West, main);

                return main;
            }
        }

        static Room Move(Direction direction, Room room)
        {
            Room destination;

            if (room.GetExits().TryGetValue(direction, out destination))
            {
                return room = destination;
            }
            else
            {
                return null;
            }
        }
    }
}
