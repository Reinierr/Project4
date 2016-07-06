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
using Android.Views.InputMethods;
using Android.Graphics;

namespace App1.Droid
{
  [Activity(Label = "barchart", Icon = "@drawable/barcharticon")]
  public class barchart : Activity
  {
    private string buurt = "";
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.tablayout);
      ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
      ActionBar.SetDisplayShowTitleEnabled(false);
      ActionBar.Tab tab = ActionBar.NewTab();
      tab.SetText("Group Bar Chart");
      tab.SetIcon(Resource.Drawable.barfix);
      tab.TabSelected += (sender, args) =>
      {
        SetContentView(Resource.Layout.barChartEdit);
        List<string> spinnerArray = new List<string>();
        List<string> Buurten = preLoad.csvFD.getBuurten();
        Dictionary<int, string> Districts = new Dictionary<int, string>();
        Districts.Add(3, "Delfshaven");
        Districts.Add(4, "Centrum");
        Districts.Add(5, "Noord-Hillegersberg");
        Districts.Add(6, "Kralingen/Crooswijk");
        Districts.Add(9, "Feijenoord");
        Districts.Add(10, "Charlois");

        foreach (string item in Buurten)
        {
          if (item.Length > 0)
          {
            spinnerArray.Add(item.Remove(0, 2));
          }
        }
        Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

        spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
        var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, spinnerArray);
        adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
        spinner.Adapter = adapter;
      };
      ActionBar.AddTab(tab);

      tab = ActionBar.NewTab();
      tab.SetText("Single Bar Chart");
      tab.SetIcon(Resource.Drawable.barfix);
      tab.TabSelected += (sender, args) =>
      {
        SetContentView(Resource.Layout.barChart);
        PlotView view = FindViewById<PlotView>(Resource.Id.plot_view_bar);
        CreateBarChart barchart = new CreateBarChart();
        view.Model = barchart.CreatePlotModel();
      };
      ActionBar.AddTab(tab);
    }
    public void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
    {
      Spinner spinner = (Spinner)sender;
      string buurt = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
      Toast.MakeText(this, buurt, ToastLength.Short).Show();
      PlotView view = FindViewById<PlotView>(Resource.Id.plot_view_bar);
      CreateGroupedBarChart barchart = new CreateGroupedBarChart(buurt);
      view.SetBackgroundColor(Color.White);
      view.Model = barchart.CreatePlotModel();
    }
  }


  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2140:TransparentMethodsMustNotReferenceCriticalCodeFxCopRule")]
  public class CreateGroupedBarChart : IChart
  {
    private string buurt;
    private string deelgem;

    Dictionary<int, string> Districts = new Dictionary<int, string>();

    public CreateGroupedBarChart(string buurt)
    {
      Districts.Add(3, "Delfshaven");
      Districts.Add(4, "Centrum");
      Districts.Add(5, "Noord");
      Districts.Add(6, "Kralingen/Crooswijk");
      Districts.Add(9, "Feijenoord");
      Districts.Add(10, "Charlois");

      if (buurt.Length > 0)
      {
        Dictionary<string, string> BuurtGem = preLoad.csvFD.getBuurt(buurt);
        foreach (KeyValuePair<string, string> item in BuurtGem)
        {
          if (item.Value.Remove(0, 2).ToLower() == buurt.ToLower())
          {
            this.buurt = item.Value.Remove(0, 2);
            foreach (KeyValuePair<int, string> district in Districts)
            {
              if (item.Key.Remove(0, 9) == district.Key.ToString())
              {
                this.deelgem = district.Value;
              }
              else
              {
                this.deelgem = null;
              }
            }
          }
        }
      }
      else
      {
        this.buurt = "";
      }
    }
    public PlotModel CreatePlotModel()
    {

      var model = new PlotModel
      {
        Title = "Grouped chart of " + deelgem,
        LegendPlacement = LegendPlacement.Outside,
        LegendPosition = LegendPosition.BottomCenter,
        LegendOrientation = LegendOrientation.Horizontal,
        LegendBorderThickness = 0
      };

      IFactory factory = new ConcreteFactory();
      var s1 = factory.CreateColumnSeriesBasic("Bike Thefts");
      var s2 = factory.CreateColumnSeriesBasic("Bike Storage Units");
      var categoryAxis = factory.CreateCategoryAxisMonths();
      var valueAxis = factory.CreateLinearAxisBasic("Total amount");

      Dictionary<int, int> fs = preLoad.csvFD.getBarchartGroupFD(buurt);
      foreach (KeyValuePair<int, int> item in fs)
      {
        s1.Items.Add(new ColumnItem { Value = item.Value });
      }

      if (this.deelgem != null)
      {
        Dictionary<int, int> fs2 = preLoad.csvFT.getBarchartGroupFT(deelgem);
        foreach (KeyValuePair<int, int> item in fs2)
        {
          s2.Items.Add(new ColumnItem { Value = item.Value });
        }
        model.Series.Add(s2);
      }


      model.Series.Add(s1);

      model.Axes.Add(categoryAxis);
      model.Axes.Add(valueAxis);

      return model;
    }
  }
  // This creates a bar chart
  // Ichart implements Plotmodel CreatePlotModel()
  public class CreateBarChart : IChart
  {
    public PlotModel CreatePlotModel()
    {
      var model = new PlotModel
      {
        Title = "Top 5 Neighborhood",
        LegendPlacement = LegendPlacement.Outside,
        LegendPosition = LegendPosition.BottomCenter,
        LegendOrientation = LegendOrientation.Horizontal,
        LegendBorderThickness = 0

      };
      IFactory factory = new ConcreteFactory();
      var s1 = factory.CreateColumnSeriesBasic("Bike Storage Unit");
      var categoryAxis = factory.CreateCategoryAxisBasic("Neighborhoods");
      var valueAxis = factory.CreateLinearAxisBasic("Total Amount");

      Dictionary<string, int> fs = preLoad.csvFT.getBarchart();
      foreach (KeyValuePair<string, int> item in fs)
      {
        s1.Items.Add(new ColumnItem { Value = item.Value });
        categoryAxis.Labels.Add(item.Key);
      }

      model.Series.Add(s1);
      model.Axes.Add(categoryAxis);
      model.Axes.Add(valueAxis);

      return model;
    }
  }
}