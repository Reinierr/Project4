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
                listofpieChart data = new listofpieChart();
                List<string> test = data.listofpieChart1();
                ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, test);
            };
            ActionBar.AddTab(tab);

            tab = ActionBar.NewTab();
            tab.SetText("Favorite Stolen Bike Colors");
            tab.SetIcon(Resource.Drawable.Icon);
            tab.TabSelected += (sender, args) =>
            {
                listofpieChartColor data2 = new listofpieChartColor();
                List<string> test2 = data2.listofpieChart1();
                ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, test2);
            };
            ActionBar.AddTab(tab);

        }




        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
        }

    }
    public class listofpieChart {
        public List<string> listofpieChart1()
        {
            List<string> data = new List<string>();
            Dictionary<string, int> fdBrand = preLoad.csvFD.getPiechartBrandFull();
            foreach (KeyValuePair<string, int> item in fdBrand)
            {
                data.Add(item.Key + " totaal van " + item.Value );
            }
            return data;
        }
    }
    public class listofpieChartColor
    {
        public List<string> listofpieChart1()
        {
            List<string> data = new List<string>();
            Dictionary<string, int> fdBrand = preLoad.csvFD.getPiechartColorFull();
            foreach (KeyValuePair<string, int> item in fdBrand)
            {
                data.Add(item.Key + " totaal van " + item.Value);
            }
            return data;
        }
    }

}
