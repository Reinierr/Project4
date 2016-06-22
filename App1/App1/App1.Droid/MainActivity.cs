using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App1.Droid
{
	[Activity (Label = "Bike Crime 'n Storage", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
            // buttons for the charts (visitor  and list)
            Button barscreen = FindViewById<Button>(Resource.Id.screen2);
            barscreen.Click += (sender, e) =>
             {
                 var intent = new Intent(this, typeof(screen2));
                 StartActivity(intent);
             };
            Button piescreen = FindViewById<Button>(Resource.Id.pieChart);
            piescreen.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(pieChart));
                StartActivity(intent);
            };
            Button linescreen = FindViewById<Button>(Resource.Id.lineChart);
            linescreen.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(lineChart));
                StartActivity(intent);
            };
        }
	}
}


