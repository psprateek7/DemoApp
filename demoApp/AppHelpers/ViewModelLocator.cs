using System;
using CommonServiceLocator;
using demoApp.ViewModels;

namespace demoApp.AppHelpers
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initialize the bootstrapping sequence for application
        /// </summary>
        static ViewModelLocator()
        {
            ApplicationBootstrapper.Initialize();
        }

        /// <summary>
        /// Get LoginViewModel
        /// </summary>
        public LoginViewModel LoginViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
    }
}
