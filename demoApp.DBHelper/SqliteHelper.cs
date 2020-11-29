using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoApp.DBHelper.Utils;
using SQLite;

namespace demoApp.DBHelper
{
    public class SqliteHelper : ISqliteHelper
    {
        /// <summary>
        /// Sqlite Database Object
        /// </summary>
        public static SQLiteAsyncConnection Database => lazyInitializer.Value;

        /// <summary>
        /// Used to check if the initialization is already done
        /// </summary>
        private static bool initialized = false;

        /// <summary>
        /// Lazy Initializer
        /// </summary>
        private static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(SqliteHelperConstants.DatabasePath, SqliteHelperConstants.Flags);
        });

        /// <summary>
        /// Initializes the Database and creates a Table if not present
        /// </summary>
        /// <param name="entityName">parameter for table name</param>
        /// <returns>true if initializion done for the first time</returns>
        public async Task<bool> InitializeAsync(string entityName)
        {
            //if (!initialized)
            //{
            if (entityName != null)
            {
                var tableType = Type.GetType(string.Concat(SqliteHelperConstants.EntityAssemblyName, entityName));
                if (tableType != null)
                {
                    if (!Database.TableMappings.Any(m => m.MappedType.Name == tableType.Name))
                    {
                        await Database.CreateTablesAsync(CreateFlags.AutoIncPK, tableType);
                        initialized = true;
                    };
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            // }
            //else
            //{
            //    return false;
            //}
        }

        /// <summary>
        /// Delete a certain Item
        /// </summary>
        /// <typeparam name="U">object type to be deleted</typeparam>
        /// <param name="item">object to be deleted</param>
        /// <returns>true of the item was successfully deleted</returns>
        public async Task<bool> DeleteItemAsync<U>(U item)
        {
            if (item != null)
            {
                return (await Database.DeleteAsync(item) == 1) ? true : false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Save a certain Item
        /// </summary>
        /// <typeparam name="U">object type to be saved</typeparam>
        /// <param name="item">object to be saved</param>
        /// <returns>true if the item was successfuly saved</returns>
        public async Task<bool> SaveItemAsync<U>(U item)
        {
            if (item != null)
            {
                return (await Database.InsertAsync(item) == 1) ? true : false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Return a list of items
        /// </summary>
        /// <typeparam name="T">list type to be returned</typeparam>
        /// <returns>list of items</returns>
        public async Task<IList<T>> GetItemsAsync<T>() where T : new()
        {
            return await Database.Table<T>().ToListAsync();
        }

        /// <summary>
        /// Update a certain Item
        /// </summary>
        /// <typeparam name="U">object type to be updated</typeparam>
        /// <param name="item">object to be updated</param>
        /// <returns>true if the update is successfull</returns>
        public async Task<bool> UpdateItem<U>(U item)
        {
            if (item != null)
            {
                return await Database.UpdateAsync(item) == 1 ? true : false;
            }
            else
            {
                return false;
            }
        }
    }
}
