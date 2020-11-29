using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using demoApp.DBHelper.Entities;
using demoApp.Interfaces.Logger;
using demoApp.Interfaces.PlatformServices;
using demoApp.Interfaces.VMServices;
using demoApp.Models.DataModels;
using demoApp.Models.RequestModels;
using demoApp.Models.ResponseModels;
using demoApp.Utils;
using Xamarin.Forms;

namespace demoApp.ViewModels
{
    public class SavedUserViewModel : BaseViewModel
    {
        private readonly ISavedUserService savedUserService;

        private List<User> listOfSavedUser;
        private ObservableCollection<UserDataModel> unsyncedUsers;

        public ObservableCollection<UserDataModel> UnsyncedUsers
        {
            get
            {
                return unsyncedUsers;
            }
            set
            {
                unsyncedUsers = value;
                OnPropertyChanged(nameof(UnsyncedUsers));
            }

        }

        private bool isError;

        public bool IsError
        {
            get
            {
                return isError;
            }
            set
            {
                isError = value;
                OnPropertyChanged(nameof(IsError));
            }

        }

        #region Commands
        public ICommand SyncCommand { get; set; }

        #endregion

        public SavedUserViewModel(INavigationService _navigationService, IDialogService _dialogService, ILoggingService _loggingService, ISavedUserService _savedUserService) : base(_navigationService,
                                                                                                                                                                            _dialogService,
                                                                                                                                                                            _loggingService)

        {
            SyncCommand = new Command(async () => await ExecuteSyncCommand());
            savedUserService = _savedUserService;
        }

        public override bool OnAppearing()
        {
            GetListOfUnSyncedUsersAsync();
            return base.OnAppearing();
        }

        private List<UserDataModel> GetSelectedUser()
        {
            var selectedUser = UnsyncedUsers.Where(x => x.IsSelected).ToList();
            return selectedUser;
        }
        private async Task ExecuteSyncCommand()
        {
            try
            {
                bool success = true;
                ShowProgress(true);
                if (IsNetworkAvailable())
                {
                    var selectedUser = GetSelectedUser();
                    foreach (var user in selectedUser)
                    {
                        var req = CreateNewUserRequest(user);
                        GenericResponse response = await savedUserService.SubmitUserDetails(AppConstants.EndPoints.AddUser, req);

                        if (response == null)
                        {
                            success = false;
                        }
                        else if (response != null && response.Success == false)
                        {
                            success = false;
                        }
                        else
                        {
                            var userToDelete = listOfSavedUser.Where(x => x.ID == user.ID).FirstOrDefault();
                            if (userToDelete != null)
                            {
                                await savedUserService.DeleteItemIfSynced(userToDelete);
                            }
                        }
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

        private void GetListOfUnSyncedUsersAsync()
        {
            Task.Run(async () =>
            {
                try
                {
                    UnsyncedUsers = new ObservableCollection<UserDataModel>();
                    listOfSavedUser = await savedUserService.GetSavedUser();
                    if (listOfSavedUser != null && listOfSavedUser.Count() > 0)
                    {
                        foreach (var user in listOfSavedUser)
                        {
                            var unsyncedUser = new UserDataModel();

                            unsyncedUser.ID = user.ID;
                            unsyncedUser.Email = user.Email;
                            unsyncedUser.Address = user.Address;
                            unsyncedUser.Age = user.Age;
                            unsyncedUser.FirstName = user.FirstName;
                            unsyncedUser.LastName = user.LastName;
                            unsyncedUser.PhoneNumber = user.PhoneNumber;

                            UnsyncedUsers.Add(unsyncedUser);
                        }
                    }
                    else
                    {
                        await ShowDialog.ShowMessage("No Records found!", "Saved Users");
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogDebug(ex.Message);
                }
            });


        }

        private void HandleSyncResult(bool isSuccess)
        {
            if (!isSuccess)
            {
                IsError = true;
            }

        }
        private AddUserReqModel CreateNewUserRequest(UserDataModel userDataModel)
        {
            AddUserReqModel req = new AddUserReqModel();
            req.FirstName = userDataModel.FirstName;
            req.LastName = userDataModel.LastName;
            req.PhoneNumber = userDataModel.PhoneNumber;
            req.Email = userDataModel.Email;
            req.Address = userDataModel.Address;
            req.Age = userDataModel.Age;

            return req;
        }
    }
}
