using System;
using System.Windows.Input;
using demoApp.Interfaces.Logger;
using demoApp.Interfaces.PlatformServices;
using demoApp.Views;
using Xamarin.Forms;

namespace demoApp.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        #region Commands
        public ICommand ImportDataCommand { get; set; }

        public ICommand NewUserCommand { get; set; }

        public ICommand SavedUserCommand { get; set; }

        public ICommand SyncDataCommand { get; set; }

        #endregion

        public DashboardViewModel(INavigationService _navigationService, IDialogService _dialogService, ILoggingService _loggingService) : base(_navigationService,
                                                                                                                                                _dialogService,
                                                                                                                                                _loggingService)


        {
            Title = "Dashboard";
            InitCommands();
        }

        private void InitCommands()
        {
            ImportDataCommand = new Command(ExecuteImportData);
            NewUserCommand = new Command(ExecuteNewUser);
            SavedUserCommand = new Command(ExecuteSavedUser);
            SyncDataCommand = new Command(ExecuteSyncData);
        }

        private void ExecuteImportData()
        {

        }

        private void ExecuteNewUser()
        {
            NavigationService.NavigateAsync(nameof(NewUserView));
        }

        private void ExecuteSavedUser()
        {
            NavigationService.NavigateAsync(nameof(SavedUserView));
        }

        private void ExecuteSyncData()
        {

        }
    }
}
