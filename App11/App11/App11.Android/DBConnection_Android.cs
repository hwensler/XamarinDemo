using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;
using System.IO;
using App11.Services;
using App11.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DBConnection_Android))]

namespace App11.Droid
{

        public class DBConnection_Android : IDatabaseConnection
        {
            public SQLiteConnection DbConnection()
            {
                var dbName = "Sample.db3";
                var path = Path.Combine(System.Environment.
                  GetFolderPath(System.Environment.
                  SpecialFolder.Personal), dbName);
                return new SQLiteConnection(path);
            }
        }
    }
}