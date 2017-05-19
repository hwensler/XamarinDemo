using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using wenslerh.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace wenslerh.Services
{
    public class ApiGetter
    {
        public async Task<List<Item>> Get(int runNumber)

        {
            Run run;
            List<Item> items;
            using (var client = new HttpClient())
            {
                //get the stuff from api
                HttpResponseMessage response = await client.GetAsync("http://thursdayhomework.azurewebsites.net/API/GetItemList/" + runNumber.ToString());

                //get a string of the results
                var itemsJson = await response.Content.ReadAsStringAsync();

                //turn json string into list of items
                run = JsonConvert.DeserializeObject<Run>(itemsJson);
                items = run.data;
                // we need to add IDs to the items, since they don't get them from the API
                foreach(Item item in items)
                {
                    item.ID = Guid.NewGuid().ToString();
                }
            }

            return items;
        }

        //create post
        public async Task<List<Item>> Post(int random, string CharacterType, int CharacterLevel)

        {
            Run run;
            List<Item> items;
            using (var client = new HttpClient())
            {
                //create the body
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("random", random.ToString()),
                    new KeyValuePair<string, string>("charactertype", CharacterType),
                    new KeyValuePair<string, string>("characterlevel", CharacterLevel.ToString())

                });

                //get the stuff from api
                HttpResponseMessage response = await client.PostAsync("http://thursdayhomeworkpost.azurewebsites.net/api/GetItems", content);

                //get a string of the results
                var itemsJson = await response.Content.ReadAsStringAsync();

                //turn json string into list of items
                run = JsonConvert.DeserializeObject<Run>(itemsJson);
                items = run.data;
                // we need to add IDs to the items, since they don't get them from the API
                foreach (Item item in items)
                {
                    item.ID = Guid.NewGuid().ToString();
                }
            }

            return items;
        }

        public async void UpdateDatabase(List<Item> items)
        {
            var oldItems = await App.Database.GetItemsAsync();
            foreach (Item item in oldItems)
            {
                await App.Database.DeleteItemAsync(item);
            }
            foreach(Item item in items)
            {
                await App.Database.SaveItemAsync(item);
            }
        }
    }
}
