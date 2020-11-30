using System;
using System.Threading.Tasks;
using System.Windows.Input;
using demoApp.Interfaces.Logger;
using demoApp.Interfaces.PlatformServices;
using demoApp.Interfaces.VMServices;
using demoApp.Models.RequestModels;
using demoApp.Models.ResponseModels;
using demoApp.Utils;
using Xamarin.Forms;

namespace demoApp.ViewModels
{
    public class NewUserViewModel : BaseViewModel
    {
        private INewUserService newUserService { get; set; }

        #region Properties
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string age;
        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        #endregion

        #region Commands
        public ICommand SubmitCommand { get; set; }

        #endregion

        public NewUserViewModel(INavigationService _navigationService, IDialogService _dialogService, ILoggingService _loggingService, INewUserService _newUserService) : base(_navigationService,
                                                                                                                                                _dialogService,
                                                                                                                                                _loggingService)


        {
            newUserService = _newUserService;
            SubmitCommand = new Command(async () => await ExecuteSubmitCommand());
            Title = "Add new user";
        }


        private async Task ExecuteSubmitCommand()
        {
            try
            {
                if (IsValidInput())
                {
                    IsProgressBarVisible = true;
                    var req = CreateNewUserRequest();
                    if (IsNetworkAvailable())
                    {

                        GenericResponse response = await newUserService.SubmitUserDetails(AppConstants.EndPoints.AddUser, req);

                        if (response != null && response.Success == true)
                        {
                            await ShowDialog.ShowMessage("Info saved successfully!", "New User");
                            await NavigationService.GoBack();
                        }
                        else
                        {
                            await ShowDialog.ShowMessage("Please try again!", "New User");
                        }
                    }
                    else
                    {
                        bool response = await newUserService.AddDetailsToDB(req);
                        if (response)
                        {
                            await ShowDialog.ShowMessage("Info saved locally. Please visit Saved User to sync once internet connectivity comes!", "New User");
                            await NavigationService.GoBack();
                        }
                        else
                        {
                            await ShowDialog.ShowMessage("Please try again!", "New User");
                        }
                    }
                }
                else
                {
                    await ShowDialog.ShowMessage("Please check your inputs.", "New User");

                }


            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex.Message);
                await ShowDialog.ShowMessage("Please try again!", "New User");
            }
            finally
            {
                IsProgressBarVisible = false;
            }
        }

        private AddUserReqModel CreateNewUserRequest()
        {
            AddUserReqModel req = new AddUserReqModel();
            req.FirstName = FirstName;
            req.LastName = LastName;
            req.PhoneNumber = PhoneNumber;
            req.Email = Email;
            req.Address = Address;

            int age = 0;
            if (int.TryParse(Age, out age))
            {
                req.Age = age;
            }

            return req;
        }

        private bool IsValidInput()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(FirstName);
        }
    }
}
