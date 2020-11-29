using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demoApp.DBHelper
{
    public interface ISqliteHelper
    {
        /// <summary>
        /// Initialization of SQLiteHelper
        /// </summary>
        /// <param name="entityName">string used for table name</param>
        /// <returns>true if init success</returns>
        Task<bool> InitializeAsync(string entityName);

        /// <summary>
        /// Delete a certain Item
        /// </summary>
        /// <typeparam name="U">object type to be deleted</typeparam>
        /// <param name="item">object to be deleted</param>
        /// <returns>true of the item was successfully deleted</returns>
        Task<bool> DeleteItemAsync<U>(U item);

        /// <summary>
        /// Save a certain Item
        /// </summary>
        /// <typeparam name="U">object type to be saved</typeparam>
        /// <param name="item">object to be saved</param>
        /// <returns>true if the item was successfuly saved</returns>
        Task<bool> SaveItemAsync<U>(U item);

        /// <summary>
        /// Return a list of items
        /// </summary>
        /// <typeparam name="T">list type to be returned</typeparam>
        /// <returns>list of items</returns>
        Task<IList<T>> GetItemsAsync<T>() where T : new();

        /// <summary>
        /// Update a certain Item
        /// </summary>
        /// <typeparam name="U">object type to be updated</typeparam>
        /// <param name="item">object to be updated</param>
        /// <returns>true if the update is successfull</returns>
        Task<bool> UpdateItem<U>(U item);
    }
}
