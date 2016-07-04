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

namespace App1.Droid
{
  [Activity(Label = "linechart", Icon = "@drawable/icon")]
  public class linechart : Activity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.barChart);
      PlotView view = FindViewById<PlotView>(Resource.Id.plot_view_bar);
      CreateLineChart linechart = new CreateLineChart();
      view.Model = linechart.CreatePlotModel();
    }
  }
  // IChart implements CreatePlotModel() which creates the graph
  //This will implement a linechart
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2140:TransparentMethodsMustNotReferenceCriticalCodeFxCopRule")]
  public class CreateLineChart : IChart
  {
    public PlotModel CreatePlotModel()
    {
      string title = "fietsdiefstallen per maand";
      var plotModel = new PlotModel
      {
        Title = title,
        TitleFontSize = 24,
        LegendFontSize = 24,
        LegendPlacement = LegendPlacement.Inside,
        LegendPosition = LegendPosition.RightTop,
        LegendOrientation = LegendOrientation.Horizontal,
        LegendBorderThickness = 0

      };
      IFactory factory = new ConcreteFactory();
      var linearAxis = factory.CreateLinearAxisBasic("Diefstal Totaal");
      var categoryAxis = factory.CreateCategoryAxisMonths();

      var series1 = new LineSeries
      {
        MarkerType = MarkerType.Circle,
        MarkerSize = 4,
        MarkerStroke = OxyColors.White,
        Title = "totaal"
      };

      Dictionary<int, int> fd = preLoad.csvFD.getLinechart();
      foreach (KeyValuePair<int, int> item in fd)
      {
        series1.Points.Add(new DataPoint(item.Key - 1.5, item.Value));
      }

      plotModel.Series.Add(series1);
      plotModel.Axes.Add(categoryAxis);
      plotModel.Axes.Add(linearAxis);

      return plotModel;
    }
  }
}