using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wenslerh.Models;
using wenslerh.Services;
using wenslerh;
using System.IO;

namespace DatabaseTests
{
    [TestClass]
    public class CRUDUnitTests
    {
        [TestMethod]
        public void CreateDatabase()
        {
            //set up a new database
            var testDatabase = new ItemsDatabase(Path.GetTempFileName());
            Assert.IsNotNull(testDatabase, "The database should not be null after creation. ");

        }
    }
}
