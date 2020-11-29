using System;
using System.Collections.Generic;
using demoApp.Models.DataModels;
using Xamarin.Forms;

namespace demoApp.Views
{
    public partial class SavedUserView : BaseView
    {
        public SavedUserView()
        {
            InitializeComponent();
        }

        //Normally this should have been done using EventToCommand
        //For the purpose of demo, I have opted for this approach.
        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e != null && e.Item != null)
            {
                var selectedItem = e.Item as UserDataModel;

                if (selectedItem.IsSelected)
                    selectedItem.IsSelected = false;
                else
                    selectedItem.IsSelected = true;

            }
            (sender as ListView).SelectedItem = null;
        }
    }
}
