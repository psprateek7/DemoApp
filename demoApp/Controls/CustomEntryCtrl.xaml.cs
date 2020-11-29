using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace demoApp.Controls
{
    public partial class CustomEntryCtrl : ContentView
    {

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), returnType: typeof(string), declaringType: typeof(string), defaultValue: "", defaultBindingMode: BindingMode.TwoWay);
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), returnType: typeof(string), declaringType: typeof(string), defaultValue: "", defaultBindingMode: BindingMode.TwoWay);
        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }


        public static readonly BindableProperty ErrorProperty = BindableProperty.Create(nameof(Error), returnType: typeof(string), declaringType: typeof(string), defaultValue: "");
        public string Error
        {
            get
            {
                return (string)GetValue(ErrorProperty);
            }
            set
            {
                SetValue(ErrorProperty, value);
            }
        }

        public static readonly BindableProperty HasErrorProperty = BindableProperty.Create(nameof(HasError), returnType: typeof(bool), declaringType: typeof(bool), defaultValue: false);
        public bool HasError
        {
            get
            {
                return (bool)GetValue(HasErrorProperty);
            }
            set
            {
                SetValue(HasErrorProperty, value);
            }
        }

        public CustomEntryCtrl()
        {
            InitializeComponent();
        }
    }
}
