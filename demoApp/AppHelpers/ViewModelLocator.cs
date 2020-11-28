using System;
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

    }
}
