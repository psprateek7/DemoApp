using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoApp.Interfaces.PlatformServices;
using Xamarin.Forms;

namespace demoApp.Services.PlatformServices
{
    public class NavigationService : INavigationService
    {
        private readonly object _sync = new object();
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private NavigationPage CurrentNavigationPage { get; set; }


        public Page SetRootPage(string rootPageKey)
        {
            var rootPage = GetPage(rootPageKey);
            CurrentNavigationPage = new NavigationPage(rootPage);
            return CurrentNavigationPage;
        }


        public void Configure(string pageKey, Type pageType)
        {
            lock (_sync)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        public async Task GoBack()
        {

            if (CurrentNavigationPage.Navigation.NavigationStack.Count > 0)
                await CurrentNavigationPage.Navigation.PopAsync();
        }

        public async Task NavigateAsync(string pageKey, bool animated = true)
        {
            await NavigateAsync(pageKey, null, animated);
        }

        public async Task NavigateAsync(string pageKey, object[] parameter, bool animated = true)
        {
            var page = GetPage(pageKey, parameter);
            await CurrentNavigationPage.Navigation.PushAsync(page, animated);
        }

        private Page GetPage(string pageKey, object[] parameter = null)
        {

            lock (_sync)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(
                        $"No such page: {pageKey}. Did you forget to call NavigationService.Configure?");
                }

                var type = _pagesByKey[pageKey];
                object[] parameters = parameter;

                //creates instance of the page by using the type of provided class/
                Page pageToNavigate = (Page)Activator.CreateInstance(type, parameters);

                return pageToNavigate;
            }
        }
    }
}
