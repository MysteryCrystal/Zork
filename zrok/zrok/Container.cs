﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zrok
{
    [Serializable]
    public class Container: Item
    {
        private bool Opened = false;

        List<Item> items;

        public Container(string name, string description):base(name, description)
        {
            items = new List<Item>();
        }


        public Container(string name, string description, bool treasure) : base(name, description, treasure)
        {
            items = new List<Item>();
            Opened = false;
        }
        //string name, string description, bool takeable,  string negative
        public Container(string name, string description, bool takeable, string negative) : base(name, description, takeable, negative)
        {
            items = new List<Item>();
            Opened = false;

        }

        public void Open()
        {
            if (Opened == true)
            {
                Console.WriteLine($"{this.GetName()} is already open.");
            }
            else
            {
                Opened = true;
                Console.WriteLine($"{this.GetName()} contains:");
                foreach (var item in items)
                {
                    Console.WriteLine(item.GetName());
                }
            }
        }

        public void Close()
        {
            if (Opened == false)
            {
                Console.WriteLine($"{this.GetName()} is already closed.");
            }
            else
            {
                Opened = false;
                Console.WriteLine("Closed.");
            }
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public Item RemoveItem(string Object)
        {
            Item item;
            foreach (var x in items)
            {
                if (Object == x.GetName())
                {
                    item = x;
                    foreach (var Item in items)
                    {
                        if (Item.GetName() == item.GetName())
                        {
                            return item;
                        }
                    }
                    Console.WriteLine("that item doesn't exist");
                    return null;
                }
            }
            return null;
        }
    }
}
