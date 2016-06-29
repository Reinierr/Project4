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
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Android.Graphics;

namespace App1.Droid
{
  [Activity(Label = "piechart", Icon = "@drawable/icon")]
  public class piechart : Activity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.tablayout);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            ActionBar.SetDisplayShowTitleEnabled(false);
            ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText("PieChart Stolen Brands");
            tab.SetIcon(Resource.Drawable.Icon);
            tab.TabSelected += (sender, args) =>
            {
                SetContentView(Resource.Layout.barChart);
                PlotView view = FindViewById<PlotView>(Resource.Id.plot_view_bar);
                view.SetBackgroundColor(Color.Black);
                CreatePieChart barchart = new CreatePieChart();
                view.Model = barchart.CreatePlotModel();
            };
            ActionBar.AddTab(tab);

            tab = ActionBar.NewTab();
            tab.SetText("Favorite Stolen Bike Colors");
            tab.SetIcon(Resource.Drawable.Icon);
            tab.TabSelected += (sender, args) =>
            {
                SetContentView(Resource.Layout.pieChart);
                PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);
                //   view.Model = CreatePlotModel2();
            };
            ActionBar.AddTab(tab);
            tab = ActionBar.NewTab();
            tab.SetText("List all stolen bike");
            tab.TabSelected += (sender, args) => {
                SetContentView(Resource.Layout.pieChart);
            };
            ActionBar.AddTab(tab);
            
            tab = ActionBar.NewTab();
            tab.SetText("List all stolen bike colors");
            tab.TabSelected += (sender, args) => {
                SetContentView(Resource.Layout.pieChart);
            };
            ActionBar.AddTab(tab);
        }
  }

  public class CreatePieChart : IChart
  {
    public PlotModel CreatePlotModel()
    {
      var modelP1 = new PlotModel { Title = "Most stolen bike brands", TitleColor = OxyColors.White };

      var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0, InsideLabelFormat = "{1}: {2:0} %", OutsideLabelFormat = "" };

      Dictionary<string, int> fdBrand = preLoad.csvFD.getPiechartBrand();
      foreach (KeyValuePair<string, int> item in fdBrand)
      {
        seriesP1.Slices.Add(new PieSlice(item.Key, item.Value) { IsExploded = true });
      }

      modelP1.Series.Add(seriesP1);

      return modelP1;
    }
  }
}