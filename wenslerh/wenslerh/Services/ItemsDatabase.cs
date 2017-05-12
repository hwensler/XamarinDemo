/**
 * This is the items database
 * **/
 
 using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using wenslerh.Models;
using System;
using System.Linq;

namespace wenslerh
{
    public class ItemsDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ItemsDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();
        }

        public async Task Initialize()
        {
            int rowCount = await database.Table<Item>().CountAsync();

            if (rowCount == 0)
            {
                var AllItems = new List<Item>
                {
                    new Item {ID = Guid.NewGuid().ToString(), Name = "Sword", Attribute= "Str", Value = 1},
                    new Item {ID = Guid.NewGuid().ToString(), Name = "Shield", Attribute="Str", Value = 1},
                    new Item {ID = Guid.NewGuid().ToString(), Name = "Shoes", Attribute="Str", Value = 1},
                    new Item {ID = Guid.NewGuid().ToString(), Name = "Bow", Attribute="Str", Value = 1},
                    new Item {ID = Guid.NewGuid().ToString(), Name = "Lance", Attribute="Str", Value = 1},
                    new Item {ID = Guid.NewGuid().ToString(), Name  = "Axe", Attribute="Str" , Value = 1},
                };

                foreach (Item item in AllItems)
                {
                    await database.InsertAsync(item);
                }
            }
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return database.Table<Item>().ToListAsync();
        }

        public Task<Item> GetItemAsync(String id)
        {
            return database.Table<Item>().Where(i => i.ID == id).FirstAsync();
        }


        //returns the number of items with this id
        public async Task<int> DoesItemExist(String id)
        {
            int count; 

            //if there is at least one item with that id and you can run the query
            try
            {
                //tell me how many items have that id
                count = await database.ExecuteScalarAsync<int>("SELECT Count(*) from Item WHERE ID = '" + id + "';");
            }

            //else, let me know there are none
            catch
            {
                count = 0;
            }

            return count;

        }

        //gets total number of rows
        public async Task<int> CountRows()
        {
            var count = await database.ExecuteScalarAsync<int>("SELECT Count(*) FROM Item");

            //convert task<int> to int
            return Convert.ToInt32(count);
        }

        //save the item!
        public async Task<int> SaveItemAsync(Item item)
        {
            int exists = await DoesItemExist(item.ID);

           //if the item exist
            if (exists != 0)
            {
                return await database.UpdateAsync(item);
            }
            //else
            else
            {
                return await database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return database.DeleteAsync(item);
        }
    }
}
