
/**
 * This is where the main menu is populated from
 * **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using wenslerh.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(wenslerh.Services.MainMenu))]
namespace wenslerh.Services
{
    public class MainMenu
    {
        public List<MenuPage> pages { get; set; }

        public MainMenu()
        {
            pages = new List<MenuPage>();
            var _items = new List<MenuPage>
            {
                new MenuPage {Text = "Score", Description="Check the current score."},
                new MenuPage {Text = "Character", Description="View all current characters."},
                new MenuPage {Text = "Inventory", Description="View the current party's inventory."},
                new MenuPage {Text = "Monsters", Description="See the monsters your party is up against."},
                new MenuPage {Text = "Items", Description="Check out all possible items."},
                new MenuPage {Text = "Battle", Description="This is where the action is."},
            };

            foreach (MenuPage item in _items)
            {
                pages.Add(item);
            }
        }
    }
}
