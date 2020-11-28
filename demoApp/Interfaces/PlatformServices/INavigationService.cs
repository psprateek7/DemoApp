using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace demoApp.Interfaces.PlatformServices
{
    /*-----
     * Various more implementations could be done, like Pushing modally
     * This was designed keeping in mind the scope of demo.
     ------*/
    public interface INavigationService
    {
        /// <summary>
        /// Configure page key with its associated page type.
        /// Use this to configure Navigation Pages.
        /// </summary>
        /// <param name="pageKey">Name of the page</param>
        /// <param name="pageType">Type of the page</param>
        void Configure(string pageKey, Type pageType);

        /// <summary>
        /// Use this to navigate back.
        /// </summary>
        /// <returns></returns>
        Task GoBack();

        /// <summary>
        /// (awaitable) Use this to push pages onto the navigation stack
        /// </summary>
        /// <param name="pageKey">key of the page to be navigated to</param>
        /// <param name="animated">(boolean)set value to show animation</param>
        /// <returns></returns>
        Task NavigateAsync(string pageKey, bool animated = true);

        /// <summary>
        /// (awaitable) Use this to push pages onto the navigation stack
        /// </summary>
        /// <param name="pageKey">key of the page to be navigated to</param>
        /// <param name="parameter">object array of params to be passed onto the navigated page</param>
        /// <param name="animated">(boolean)set value to show animation</param>
        /// <returns></returns>
        Task NavigateAsync(string pageKey, object[] parameter, bool animated = true);
    }
}
