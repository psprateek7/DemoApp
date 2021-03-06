﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using demoApp.AppHelpers;
using demoApp.Interfaces.Logger;
using demoApp.Interfaces.PlatformServices;
using demoApp.Interfaces.VMServices;
using demoApp.Models.RequestModels;
using demoApp.Models.ResponseModels;
using demoApp.Utils;
using demoApp.Views;
using Xamarin.Forms;

namespace demoApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ILoginService loginService { get; set; }

        #region Properties
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }

        #endregion
        public LoginViewModel(INavigationService _navigationService, IDialogService _dialogService, ILoggingService _loggingService, ILoginService _loginService) : base(_navigationService,
                                                                                                                                                                            _dialogService,
                                                                                                                                                                            _loggingService)
        {
            loginService = _loginService;
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        private async Task ExecuteLoginCommand()
        {
            try
            {
                if (IsValidInput())
                {
                    IsProgressBarVisible = true;
                    if (await CheckNetworkAndShowDialog())
                    {
                        var req = new LoginReqModel();
                        req.UserName = UserName;
                        req.Password = Password;

                        LoginResponse response = await loginService.PerformLogin(AppConstants.EndPoints.Login, req);

                        if (response != null && response.Errors == null && response.TokenResult != null)
                        {
                            AppSession.UpdateSessionParam(AppConstants.SessionParams.Token, response.TokenResult.Token);
                            await NavigationService.NavigateAsync(nameof(DashboardView));
                        }
                        else
                        {
                            await ShowDialog.ShowMessage("Please check your username/password and try again!", "Invalid Inputs");
                        }
                    }
                }
                else
                {
                    await ShowDialog.ShowMessage("Please provide username/password and try again!", "Invalid Inputs");
                }
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex.Message);
            }
            finally
            {
                IsProgressBarVisible = false;
            }
        }

        private bool IsValidInput()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }
    }

}
