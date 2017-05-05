using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wenslerh.Models;
using wenslerh.Services;
using wenslerh;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using wenslerh.Models;
using System;
using System.Linq;

namespace DatabaseTests
{
    [TestClass]
    public class CRUDUnitTests
    {

        //create database to use in further testing
        //set up a new database
        ItemsDatabase testDatabase = new ItemsDatabase(Path.GetTempFileName());

        //tests that a database is created
        [TestMethod]
        public void CreateDatabaseCreatesDatabase()
        {
            //set up a new database
            var createDatabase = new ItemsDatabase(Path.GetTempFileName());
            Assert.IsNotNull(createDatabase, "The database should not be null after creation. ");

        }

        //tests that an item doesn't return it exists if it doesn't exist
        [TestMethod]
        public void ItemDoesNotExistInDatabase()
        {
            Task<int> result = testDatabase.DoesItemExist("1");
            Assert.AreNotEqual(1, result, "The item hasn't been inserted and should not exist");

        }

        //test that an item does return that an item exists if it does indeed exist
        [TestMethod]
        public async Task ItemDoesExistInDatabase()
        {
            //define an item
            Item testItem = new Item { ID = "testID",
                Name = "Sword",
                Description = "A really cool sword. ",
                Strength = 1 };

            //insert it
            await testDatabase.SaveItemAsync(testItem);

            Task<int> result = testDatabase.DoesItemExist("testID");
            Assert.AreNotEqual(1, result, "The item has been inserted and should exist");

        }

        //tests INSERT by showing the total rows has increased by 1 after a new insertion
        [TestMethod]
        public async Task InsertIntoDatabaseAsync()
        {
            int firstCount = (testDatabase.CountRows()).Result;

            //define an item
            Item testItem = new Item { ID = Guid.NewGuid().ToString(),
                Name = "Better Sword",
                Description = "A better sword. ",
                Strength = 19 };

            //insert it
            await testDatabase.SaveItemAsync(testItem);

            int secondCount = (testDatabase.CountRows()).Result;

            Assert.AreEqual(secondCount, firstCount + 1, "The total number of rows before and insert" +
                "should be one less than the total number of rows after an insert");
        }

        //tests read ability
        [TestMethod]
        public async Task ReadFromDatabaseAsync()
        {
            //define an item
            Item testItem = new Item
            {
                ID = "testID",
                Name = "AVeryTestableName",
                Description = "A really cool sword. ",
                Strength = 1
            };

            //put it in the database
            await testDatabase.SaveItemAsync(testItem);

            //read it from the database
            var readItem = testDatabase.GetItemAsync("testID").Result;

            //make sure the item you got is one you inserted
            string testName = readItem.Name;

            Assert.AreEqual(testName, "AVeryTestableName", "These names should be the same");
        }

        //test update ability
        [TestMethod]
        public async Task UpdateDatabaseAsync()
        {
            //define an item
            Item testItem = new Item
            {
                ID = "testID",
                Name = "Sword",
                Description = "A really cool sword. ",
                Strength = 1
            };

            //put it in the database
            await testDatabase.SaveItemAsync(testItem);

            //update it
            Item testItemUpdate = new Item
            {
                ID = "testID",
                Name = "Cooler Sword",
                Description = "A really cool sword. ",
                Strength = 22
            };
            await testDatabase.SaveItemAsync(testItemUpdate);

            //get the item
            var finalItem = await testDatabase.GetItemAsync("testID");

            //make sure the strength is 22

            Assert.AreEqual(22, finalItem.Strength);
        }

        //delete an item that does exist
        [TestMethod]
        public async Task DeleteDatabaseAsync()
        {
            //define an item
            Item testItem = new Item
            {
                ID = "testID",
                Name = "Sword",
                Description = "A really cool sword. ",
                Strength = 1
            };

            //put it in the database
            await testDatabase.SaveItemAsync(testItem);

            //delete it
            await testDatabase.DeleteItemAsync(testItem);

            //count how many testIDs are in the database
            int howManyExist = testDatabase.DoesItemExist("testID").Result;

            Assert.AreEqual(howManyExist, 0);

        }
    }
}
