﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zrok
{
    public class Item
    {
        private string Name;
        private string Description;
        private string Sound = null;
        private bool Treasure = false;

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Item(string name, string description, bool treasure)
        {
            Name = name;
            Description = description;
            Treasure = treasure;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetDescription()
        {
            return Description;
        }

        public bool IsTreasure()
        {
            return Treasure;
        }
    }
}
