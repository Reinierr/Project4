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
      tab.SetIcon(Resource.Drawable.piefix);
      tab.TabSelected += (sender, args) =>
      {
        SetContentView(Resource.Layout.barChart);
        PlotView view = FindViewById<PlotView>(Resource.Id.plot_view_bar);
        CreatePieChart barchart = new CreatePieChart();
        view.Model = barchart.CreatePlotModel();
      };
      ActionBar.AddTab(tab);

      tab = ActionBar.NewTab();
      tab.SetText("Favorite Stolen Bike Colors");
      tab.SetIcon(Resource.Drawable.piefix);
      tab.TabSelected += (sender, args) =>
      {
        SetContentView(Resource.Layout.barChart);
        PlotView view = FindViewById<PlotView>(Resource.Id.plot_view_bar);
        CreatePieChart2 pieChart = new CreatePieChart2();
        view.Model = pieChart.CreatePlotModel();
      };
      ActionBar.AddTab(tab);
      tab = ActionBar.NewTab();
      tab.SetText("List for piecharts");
      tab.TabSelected += (sender, args) =>
      {

        var intent = new Intent(this, typeof(pielist));
        StartActivity(intent);

      };
      ActionBar.AddTab(tab);
    }
  }
  // IChart implements CreatePlotModel() which creates the graph
  //This will implement a piechart
  public class CreatePieChart : IChart
  {
    public PlotModel CreatePlotModel()
    {
      var modelP1 = new PlotModel { Title = "Most stolen bike brands top 5", TitleColor = OxyColors.Black };
      IFactory factory = new ConcreteFactory();
      var seriesP1 = factory.CreatePieSeriesBasic();

      Dictionary<string, int> fdBrand = preLoad.csvFD.getPiechartBrand();
      foreach (KeyValuePair<string, int> item in fdBrand)
      {
        seriesP1.Slices.Add(new PieSlice(item.Key, item.Value) { IsExploded = true });
      }

      modelP1.Series.Add(seriesP1);

      return modelP1;
    }
  }
  // IChart implements CreatePlotModel() which creates the graph
  //This will implement a piechart
  public class CreatePieChart2 : IChart
  {
    public PlotModel CreatePlotModel()
    {
      var modelP1 = new PlotModel { Title = "Most stolen bike Color top 5", TitleColor = OxyColors.Black };
      IFactory factory = new ConcreteFactory();
      var seriesP1 = factory.CreatePieSeriesBasic();
      Dictionary<string, int> fdBrand = preLoad.csvFD.getPiechartColor();
      foreach (KeyValuePair<string, int> item in fdBrand)
      {
        seriesP1.Slices.Add(new PieSlice(item.Key, item.Value) { IsExploded = true });
      }

      modelP1.Series.Add(seriesP1);

      return modelP1;
    }
  }
}