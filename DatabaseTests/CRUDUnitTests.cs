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
        public void CreateDatabase()
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
            Item testItem = new Item { ID = "testID", Name = "Sword", Description = "A really cool sword. ", Strength = 1 };

            //insert it
            await testDatabase.SaveItemAsync(testItem);

            Task<int> result = testDatabase.DoesItemExist("testID");
            Assert.AreNotEqual(1, result, "The item has been inserted and should exist");

        }

        //tests insert by showing an item does exist after it is inserted
        [TestMethod]
        public async Task InsertIntoDatabaseAsync()
        {
            int firstCount = (testDatabase.CountRows()).Result;

            //define an item
            Item testItem = new Item { ID = Guid.NewGuid().ToString(), Name = "Sword", Description = "A really cool sword. ", Strength = 1 };

            //insert it
            await testDatabase.SaveItemAsync(testItem);

            int secondCount = (testDatabase.CountRows()).Result;

            Assert.AreEqual(secondCount, firstCount + 1, "The total number of rows before and insert" +
                "should be one less than the total number of rows after an insert");


        }



    }
}
