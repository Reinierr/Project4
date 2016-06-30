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
using OxyPlot.Xamarin.Android;
using Android.Graphics;

namespace App1.Droid
{
    [Activity(Label = "pielist")]
    public class pielist : ListActivity
    {
        string[] data = { "one", "two", "three", "four", "five", "six", "seven", "ate", "nien", "windows Poep", "Fart" };
        string[] data2 = { "three", "four", "five", "six", "seven", "ate", "nien", "windows Poep", "Fart", "one", "two" };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            ActionBar.SetDisplayShowTitleEnabled(false);
            ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText("stolen bike brands");
            tab.SetIcon(Resource.Drawable.Icon);
            tab.TabSelected += (sender, args) =>
            {
                ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, data);
            };
            ActionBar.AddTab(tab);

            tab = ActionBar.NewTab();
            tab.SetText("Favorite Stolen Bike Colors");
            tab.SetIcon(Resource.Drawable.Icon);
            tab.TabSelected += (sender, args) =>
            {
                ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, data2);
            };
            ActionBar.AddTab(tab);
            
        }




        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
        }
    }
}
