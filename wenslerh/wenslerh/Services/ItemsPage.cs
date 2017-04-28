/**
 * This is where the items list is populated from... for now.
 * **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using wenslerh.Models;

using Xamarin.Forms;

namespace wenslerh.Services
{
    public class ItemsPage
    {
        public List<Item> items { get; set; }

        public ItemsPage()
        {
            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), id = 1, Name = "Sword", Description= "A really cool sword. ", Strength = 1},
                new Item { Id = Guid.NewGuid().ToString(), id = 2, Name = "Shield", Description="A really cool shield. ", Strength = 1},
                new Item { Id = Guid.NewGuid().ToString(), id = 3, Name = "Shoes", Description="A really cool pair of shoes. ", Strength = 1},
                new Item { Id = Guid.NewGuid().ToString(), id = 4, Name = "Bow", Description="A realy cool bow.", Strength = 1},
                new Item { Id = Guid.NewGuid().ToString(), id = 5, Name = "Lance", Description="A really cool lance. ", Strength = 1},
                new Item { Id = Guid.NewGuid().ToString(), id = 6, Name  = "Axe", Description="A really cool axe. " , Strength = 1},
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }
        }


    }

}
