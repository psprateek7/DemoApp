using System;
using Android.Content;
using demoApp.Controls;
using demoApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderLessEntryRenderer))]
namespace demoApp.Droid.Renderers
{
    public class BorderLessEntryRenderer : EntryRenderer
    {
        public BorderLessEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                Control?.SetBackground(null);
            }


        }
    }
}
