﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zrok
{
    class Player
    {
        private Room room;
        List<Item> inventory = new List<Item>();

        public Player(Room _room)
        {
            room = _room;
        }



    }
}
