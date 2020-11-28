using System;
using demoApp.ViewModels;
using Xamarin.Forms;

namespace demoApp.Views
{
    public class BaseView : ContentPage
    {
        public bool IsBackbuttonEnabled { get; private set; }

        public BaseView(bool isBackButtonEnabled = true)
        {
            IsBackbuttonEnabled = isBackButtonEnabled;
        }

        /// <summary>
        /// If back button is enabled it will first be relayed to the viewmodel to allow specific actions to perform,
        /// If it is not handled by ViewModel, it will perform the default back action
        /// </summary>
        protected override bool OnBackButtonPressed()
        {
            return !IsBackbuttonEnabled || (BindingContext as BaseViewModel).OnBackButtonPressed() || base.OnBackButtonPressed();
        }

        /// <summary>
        /// OnAppearing event will be relayed to the viewmodel's OnAppearing
        /// </summary>
        protected override void OnAppearing()
        {
            (BindingContext as BaseViewModel)?.OnAppearing();
            base.OnAppearing();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDisappearing()
        {
            (BindingContext as BaseViewModel)?.OnDisappearing();
            base.OnDisappearing();
        }
    }
}
