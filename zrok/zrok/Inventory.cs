﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace zrok
{
    [Serializable]
    public class Inventory
    {
        private int maxitems = 8;
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public bool Add(Item item)
        {
            if (items.Count >= maxitems)
            {
                Random random = new Random();
                if (random.Next(0,100)>=80)
                {
                    items.Add(item);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                items.Add(item);
                return true;
            }
        }

        public void Show()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Your inventory does not contain any items");
            }
            else
            {
                Console.WriteLine("Inventory contains: ");
                foreach (var item in items)
                {
                    Console.WriteLine(item.GetName() + item.GetState());
                }
            }
        }

        public Item Remove(string name)
        {
            foreach (Item item in items)
            {
                if (item.IsSynonym(name))
                {
                    items.Remove(item);
                    return item;
                }
            }
            Console.WriteLine("You don't have that item on you");
            return null;
        }

        public bool find(string name)
        {
            foreach (var item in items)
            {
                if (item.GetName() == name)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetSize()
        {
            return items.Count;
        }

        public int GetTreasureCount()
        {
            int count = 0;
            foreach (var item in items)
            {
                if (item.IsTreasure())
                {
                    count++;
                }
            }
            return count;
        }

        public List<Item> GetItems()
        {
            return items;
        }

    }
}
