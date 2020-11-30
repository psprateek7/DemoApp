using System;
using System.Threading.Tasks;
using demoApp.Interfaces.Logger;
using demoApp.Interfaces.PlatformServices;
using demoApp.Utils;
using Plugin.Connectivity;
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
        private bool isConnected;
        /// <summary>
        /// Bind this to the Progress bar in UI and manage the visibilty.
        /// </summary>
        public bool IsConnected
        {
            set
            {
                isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
            }
            get
            {
                return isConnected;
            }
        }

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
            // SubscribeToNetworkChange();
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
            SubscribeToNetworkChange();
            return false;
        }

        /// <summary>
        /// called on 'OnDisappearing' lifecycle event 
        /// Override this method to provide OnDisappearing behavior.
        /// </summary>
        public virtual bool OnDisappearing()
        {
            UnsubscribeFromNetworkChange();
            return false;
        }

        /// <summary>
        /// override this to handle network change
        /// </summary>
        protected virtual void RefreshOnNetworkChange()
        {

        }

        protected void ShowProgress(bool isVisible)
        {
            IsProgressBarVisible = isVisible;
        }

        #region NetworkChecks
        protected void SetConnectivityConst()
        {
            IsConnected = IsNetworkAvailable();
        }

        protected bool IsNetworkAvailable()
        {
            bool isAvailable = CrossConnectivity.Current.IsConnected;

            if (!isAvailable)
                return false;

            return true;
        }

        protected async Task<bool> CheckNetworkAndShowDialog()
        {

            if (!IsNetworkAvailable())
            {
                await ShowDialog.ShowMessage("Please check your network connectivity!", "No Internet");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SubscribeToNetworkChange()
        {
            MessagingCenter.Subscribe(this, AppConstants.MessagingCenterConsts.NetworkChanged, (object arg1) => { HandleNetworkChange(arg1); });
        }


        private void UnsubscribeFromNetworkChange()
        {
            MessagingCenter.Unsubscribe<App>(this, AppConstants.MessagingCenterConsts.NetworkChanged);
        }

        private async Task HandleNetworkChange(object sender)
        {
            try
            {
                if (sender != null)
                {
                    if (IsNetworkAvailable())
                    {

                        await ShowDialog.ShowCustomPopUp("You now have internet access!");
                        RefreshOnNetworkChange();
                    }
                    else
                    {

                        await ShowDialog.ShowCustomPopUp("You have lost internet access. You are now in in Offline Mode!");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDebug("Refresh failed on network change with ex - " + ex.Message);
            }
        }
        #endregion
    }
}
