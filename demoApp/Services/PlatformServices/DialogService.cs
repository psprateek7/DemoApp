using System;
using System.Threading;
using System.Threading.Tasks;
using demoApp.Controls;
using demoApp.Interfaces.PlatformServices;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace demoApp.Services.PlatformServices
{
    public class DialogService : IDialogService
    {
        private static Page CurrentMainPage => Application.Current.MainPage;

        public Task<bool> ShowMessage(string message, string title, string confirmText = "Ok", string cancelText = "")
        {
            var taskcompletionservice = new TaskCompletionSource<bool>();

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = false;
                if (cancelText == "")
                    await CurrentMainPage.DisplayAlert(title, message, confirmText);
                else
                    result = await CurrentMainPage.DisplayAlert(title, message, confirmText, cancelText);

                taskcompletionservice.SetResult(result);
            });
            return taskcompletionservice.Task;
        }


        public async Task ShowCustomPopUp(string text)
        {
            if (PopupNavigation.Instance.PopupStack.Count < 1)
            {
                var popUp = new CustomPopUp(text);
                await PopupNavigation.Instance.PushAsync(popUp);
                Thread.Sleep(1000);
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}
