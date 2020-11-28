using System;
using demoApp.Controls;
using demoApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderLessEntryRenderer))]
namespace demoApp.iOS.Renderers
{
    public class BorderLessEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}
