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

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), returnType: typeof(bool), declaringType: typeof(bool), defaultValue: false);
        public bool IsPassword
        {
            get
            {
                return (bool)GetValue(IsPasswordProperty);
            }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), returnType: typeof(Keyboard), declaringType: typeof(Keyboard), defaultValue: Keyboard.Default);

        public Xamarin.Forms.Keyboard Keyboard
        {
            get
            {
                return (Keyboard)GetValue(KeyboardProperty);
            }
            set
            {
                SetValue(KeyboardProperty, value);
            }
        }
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), returnType: typeof(int), declaringType: typeof(int), defaultValue: 100);

        public int MaxLength
        {
            get
            {
                return (int)GetValue(MaxLengthProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }
        public CustomEntryCtrl()
        {
            InitializeComponent();
        }
    }
}
