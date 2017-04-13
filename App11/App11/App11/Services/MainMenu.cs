using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App11.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(App11.Services.MainMenu))]
namespace App11.Services
{
	public class MainMenu : IDataStore<Item>
	{
		bool isInitialized;
		List<Item> pages;

		public async Task<bool> AddItemAsync(Item item)
		{
			await InitializeAsync();

			pages.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = pages.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			pages.Remove(_item);
			pages.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = pages.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			pages.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			await InitializeAsync();

			return await Task.FromResult(pages.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			await InitializeAsync();

			return await Task.FromResult(pages);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}

		public async Task InitializeAsync()
		{
			if (isInitialized)
				return;

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

			isInitialized = true;
		}
	}
}
