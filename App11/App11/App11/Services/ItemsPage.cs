using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App11.Models;

using Xamarin.Forms;

namespace App11.Services
{
    public class ItemsPage
    {
        public List<Item> items { get; set; }

        public ItemsPage()
        {
            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sword", Description="Check the current score."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Shield", Description="View all current characters."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Shoes", Description="View the current party's inventory."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Bow", Description="See the monsters your party is up against."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Items", Description="Check out all possible items."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Axe", Description="This is where the action is."},
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }
        }


    }

}
