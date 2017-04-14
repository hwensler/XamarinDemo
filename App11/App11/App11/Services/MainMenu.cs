using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App11.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(App11.Services.MainMenu))]
namespace App11.Services
{
	public class MainMenu
    {
		public List<Item> pages { get; set; }

        public MainMenu()
        {
            pages = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Score", Description="Check the current score."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Character", Description="View all current characters."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Inventory", Description="View the current party's inventory."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Monsters", Description="See the monsters your party is up against."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Items", Description="Check out all possible items."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Battle", Description="This is where the action is."},
            };

            foreach (Item item in _items)
            {
                pages.Add(item);
            }
        }
	}
}
