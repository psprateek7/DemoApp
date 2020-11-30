using System;
using System.Threading.Tasks;
using System.Windows.Input;
using demoApp.Interfaces.Logger;
using demoApp.Interfaces.PlatformServices;
using demoApp.Interfaces.VMServices;
using demoApp.Models.ResponseModels;
using demoApp.Utils;
using demoApp.Views;
using Xamarin.Forms;

namespace demoApp.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly IDashboardService dashboardService;
        #region Commands
        public ICommand ImportDataCommand { get; set; }

        public ICommand NewUserCommand { get; set; }

        public ICommand SavedUserCommand { get; set; }

        public ICommand SyncDataCommand { get; set; }

        public ICommand LogOutCommand { get; set; }

        #endregion

        public DashboardViewModel(INavigationService _navigationService, IDialogService _dialogService, ILoggingService _loggingService, IDashboardService _dashboardService) : base(_navigationService,
                                                                                                                                                _dialogService,
                                                                                                                                                _loggingService)


        {
            dashboardService = _dashboardService;
            IsConnected = IsNetworkAvailable();
            Title = "Dashboard";
            InitCommands();
        }

        private void InitCommands()
        {
            ImportDataCommand = new Command(ExecuteImportData);
            NewUserCommand = new Command(ExecuteNewUser);
            SavedUserCommand = new Command(ExecuteSavedUser);
            SyncDataCommand = new Command(async () => await ExecuteSyncData());
            LogOutCommand = new Command(LogOut);
        }
        #region overrides
        public override bool OnAppearing()
        {

            return base.OnAppearing();
        }

        protected override void RefreshOnNetworkChange()
        {
            IsConnected = IsNetworkAvailable();
            base.RefreshOnNetworkChange();
        }
        #endregion
        private void ExecuteImportData()
        {

        }
        private void LogOut()
        {
            Application.Current.MainPage = NavigationService.SetRootPage(nameof(LoginView));

        }
        private void ExecuteNewUser()
        {
            NavigationService.NavigateAsync(nameof(NewUserView));
        }

        private void ExecuteSavedUser()
        {
            NavigationService.NavigateAsync(nameof(SavedUserView));
        }

        private async Task ExecuteSyncData()
        {
            try
            {
                ShowProgress(true);
                if (await CheckNetworkAndShowDialog())
                {

                    StudentResponse response = await dashboardService.GetListOfStudents(AppConstants.EndPoints.GetUsers);

                    if (response != null && response.Students != null && response.Students.Count > 0)
                    {
                        var isSyncSuccessful = await dashboardService.AddDetailsToDB(response);

                        if (isSyncSuccessful)
                            await ShowDialog.ShowMessage("Info synced successfully from server!", "Dashboard");
                    }
                    else
                    {
                        await ShowDialog.ShowMessage("Unable to sync, please try again!", "Dashboard");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex.Message);
            }
            finally
            {
                ShowProgress(false);
            }
        }
    }
}
