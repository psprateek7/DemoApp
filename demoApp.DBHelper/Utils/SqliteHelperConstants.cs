using System;
using System.IO;

namespace demoApp.DBHelper.Utils
{
    public class SqliteHelperConstants
    {
        /// <summary>
        /// Database Name
        /// </summary>
        public const string DatabaseFilename = "DefaultDb.db";

        /// <summary>
        /// Assembly Name Constant to resolve Entities
        /// </summary>
        public const string EntityAssemblyName = "demoApp.DBHelper.Entities.";

        /// <summary>
        /// Assembly Name Constant to resolve Entities
        /// </summary>
        public const string UserEntityName = "User";

        /// <summary>
        /// Flags to configure Tables in Sqlite
        /// </summary>
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        /// <summary>
        /// Return the database Path
        /// </summary>
        public static string DatabasePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DatabaseFilename);
            }
        }
    }
}
