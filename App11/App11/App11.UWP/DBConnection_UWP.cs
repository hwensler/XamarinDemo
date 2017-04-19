using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using System.IO;
using App11.Services;
using App11.UWP;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(DBConnection_UWP))]

namespace App11.UWP
{
    class DBConnection_UWP
    {
        public class DatabaseConnection_UWP : IDatabaseConnection
        {
            public SQLiteConnection DbConnection()
            {
                var dbName = "Sample.db3";
                var path = Path.Combine(ApplicationData.
                  Current.LocalFolder.Path, dbName);
                return new SQLiteConnection(path);
            }
        }
    }
}