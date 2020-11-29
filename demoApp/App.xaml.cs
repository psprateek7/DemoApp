using CommonServiceLocator;
using demoApp.Interfaces.PlatformServices;
using demoApp.Utils;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace demoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SubscribeToNetworkChange();
            var mainPage = ServiceLocator.Current.GetInstance<INavigationService>().SetRootPage("LoginView");

            MainPage = mainPage;
        }

        private void SubscribeToNetworkChange()
        {
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                MessagingCenter.Send<object>(this, AppConstants.MessagingCenterConsts.NetworkChanged);
            };
        }
        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
