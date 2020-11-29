using System;
using demoApp.Controls;
using Xamarin.Forms;

namespace demoApp.Utils.Behaviors
{
    public class EntryTextValidator : Behavior<CustomEntryCtrl>
    {
        private CustomEntryCtrl control;
        protected override void OnAttachedTo(CustomEntryCtrl ctrl)
        {
            try
            {
                control = ctrl;
                if (control != null)
                {
                    StackLayout stack = ctrl.Content as StackLayout;
                    BorderlessEntry e;

                    foreach (var child in stack.Children)
                    {
                        if (child is BorderlessEntry)
                        {
                            e = child as BorderlessEntry;
                            e.Unfocused += HandleFocusChanged;
                            e.TextChanged += HandleTextChanged;
                            break;
                        }
                    }
                }
                base.OnAttachedTo(ctrl);
            }
            catch (Exception)
            {

            }
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                control.HasError = false;
                control.Error = string.Empty;
            }
        }

        void HandleFocusChanged(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(((BorderlessEntry)sender).Text))
            {
                control.HasError = true;
                control.Error = $"{((BorderlessEntry)sender).Placeholder} is required";
            }
            else
            {
                control.HasError = false;
                control.Error = string.Empty;
            }
        }

        protected override void OnDetachingFrom(CustomEntryCtrl ctrl)
        {
            // bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(ctrl);
        }
    }
}
