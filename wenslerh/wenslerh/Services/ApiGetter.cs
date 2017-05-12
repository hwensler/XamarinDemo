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
        public async Task<List<Item>> Get()

        {
            Run run;
            List<Item> items;
            using (var client = new HttpClient())
            {
                //get the stuff from api
                HttpResponseMessage response = await client.GetAsync("http://thursdayhomework.azurewebsites.net/API/GetItemList/1");

                //get a string of the results
                var itemsJson = await response.Content.ReadAsStringAsync();

                //turn json string into list of items
                run = JsonConvert.DeserializeObject<Run>(itemsJson);
                items = run.data;
            }

            return items;
        }
    }
}
