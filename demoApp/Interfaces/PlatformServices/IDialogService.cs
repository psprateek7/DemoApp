using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;

namespace demoApp.Interfaces.PlatformServices
{
    public interface IDialogService
    {
        /// <summary>
        /// Shows the native alert dialog.(awaitable) 
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="title">Title for alert</param>
        /// <param name="confirmText">confirm button text</param>
        /// <param name="cancelText">cancel button text</param>
        /// <returns></returns>
        Task<bool> ShowMessage(string message, string title, string confirmText = "Ok", string cancelText = "");

        /// <summary>
        /// Show snack bar equivalent custom popup
        /// </summary>
        /// <param name="text">text to display</param>
        Task ShowCustomPopUp(string text);
    }
}
