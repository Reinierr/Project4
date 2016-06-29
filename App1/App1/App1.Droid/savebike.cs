using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1.Droid
{
    [Activity(Label = "savebike", Icon = "@drawable/icon")]
    public class savebike : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.tablayout);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText("Calendar");
            tab.SetIcon(Resource.Drawable.Icon);
            tab.TabSelected += (sender, args) =>
            {
                SetContentView(Resource.Layout.savebike);

            };
            ActionBar.AddTab(tab);

            tab = ActionBar.NewTab();
            tab.SetText("Memo");
            tab.SetIcon(Resource.Drawable.Icon);
            tab.TabSelected += (sender, args) =>
            {
                SetContentView(Resource.Layout.savebike2);

            };
            ActionBar.AddTab(tab);
           
        }
    }
}