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

        /// <summary>
        /// Get DashboardViewModel
        /// </summary>
        public DashboardViewModel DashboardViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DashboardViewModel>();
            }
        }

        /// <summary>
        /// Get NewUserViewModel
        /// </summary>
        public NewUserViewModel NewUserViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NewUserViewModel>();
            }
        }

        /// <summary>
        /// Get SavedUserViewModel
        /// </summary>
        public SavedUserViewModel SavedUserViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SavedUserViewModel>();
            }
        }
    }
}
