﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zrok
{
    [Serializable]
    public class Weapon : Item
    {
        public Weapon(string name, string description) : base (name, description)
        {
        }
    }
}
