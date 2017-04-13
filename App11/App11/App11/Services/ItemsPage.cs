﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App11.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(App11.Services.ItemsPage))]
namespace App11.Services
{
    public class ItemsPage : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
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

            isInitialized = true;
        }
    }
}
