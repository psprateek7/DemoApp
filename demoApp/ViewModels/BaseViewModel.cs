using System;
using System.Threading.Tasks;
using demoApp.Interfaces.Logger;
using demoApp.Interfaces.PlatformServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace demoApp.ViewModels
{
    public class BaseViewModel : BindableObject
    {
        protected INavigationService NavigationService { get; private set; }
        protected IDialogService ShowDialog { get; private set; }
        protected ILoggingService Logger { get; private set; }

        #region UI Functions

        private bool isProgressBarVisible;
        /// <summary>
        /// Bind this to the Progress bar in UI and manage the visibilty.
        /// </summary>
        public bool IsProgressBarVisible
        {
            set
            {
                isProgressBarVisible = value;
                OnPropertyChanged(nameof(IsProgressBarVisible));
            }
            get
            {
                return isProgressBarVisible;
            }
        }

        private string title;
        public string Title
        {
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
            get
            {
                return title;
            }
        }
        #endregion

        /// <summary>
        /// Constructor. Initialises the required service instances.
        /// </summary>
        public BaseViewModel(INavigationService navigationService, IDialogService dialogService, ILoggingService loggingService)
        {
            NavigationService = navigationService;
            ShowDialog = dialogService;
            Logger = loggingService;
        }

        /// <summary>
        /// Called when back button is pressed.
        /// Override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>True when back action should be cancelled, else false</returns>
        public virtual bool OnBackButtonPressed()
        {
            return false;
        }

        /// <summary>
        /// called on 'OnAppearing' lifecycle event 
        /// Override this method to provide OnAppearing behavior.
        /// </summary>
        public virtual bool OnAppearing()
        {
            return false;
        }

        /// <summary>
        /// called on 'OnDisappearing' lifecycle event 
        /// Override this method to provide OnDisappearing behavior.
        /// </summary>
        public virtual bool OnDisappearing()
        {
            return false;
        }

        protected void ShowProgress(bool isVisible)
        {
            IsProgressBarVisible = isVisible;
        }

        protected bool IsNetworkAvailable()
        {
            var networkAccess = Connectivity.NetworkAccess;

            if (networkAccess == NetworkAccess.None || networkAccess == NetworkAccess.Unknown)
                return false;

            return true;
        }

        public async Task<bool> CheckNetworkAndShowDialog()
        {
            var networkAccess = Connectivity.NetworkAccess;
            if (networkAccess == NetworkAccess.None || networkAccess == NetworkAccess.Unknown)
            {
                await ShowDialog.ShowMessage("Please check your network connectivity!", "No Internet");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
