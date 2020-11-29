using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace demoApp.Controls
{
    public partial class CustomPopUp
    {
        public CustomPopUp(string title)
        {
            InitializeComponent();
            txtLabel.Text = title;
        }
    }
}
