using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace demoApp.Controls
{
    public partial class AppLoader : ContentView
    {
        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(nameof(IsRunning), returnType: typeof(bool), declaringType: typeof(bool), defaultValue: false);
        public bool IsRunning
        {
            get
            {
                return (bool)GetValue(IsRunningProperty);
            }
            set
            {
                SetValue(IsRunningProperty, value);
            }
        }

        public AppLoader()
        {
            InitializeComponent();
        }
    }
}
