using System;
using System.Threading.Tasks;
using demoApp.Interfaces.PlatformServices;
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
    }
}
