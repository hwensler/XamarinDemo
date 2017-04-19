using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using System.IO;
using App11.Services;
using App11.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(DBConnection_iOS))]

namespace App11.iOS
{
    class DBConnection_iOS
    {
        public class DatabaseConnection_iOS
        {
            public SQLiteConnection DbConnection()
            {
                var dbName = "Sample.db3";
                string personalFolder =
                  System.Environment.
                  GetFolderPath(Environment.SpecialFolder.Personal);
                string libraryFolder =
                  Path.Combine(personalFolder, "..", "Library");
                var path = Path.Combine(libraryFolder, dbName);
                return new SQLiteConnection(path);
            }
        }
    }
}
}
