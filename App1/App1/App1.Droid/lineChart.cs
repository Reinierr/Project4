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

      var linearAxis = new LinearAxis { Position = AxisPosition.Left, Title = "Diefstal totaal", TitleFontSize = 20 };
      var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom, FontSize = 24 };

            string[] months = { "Jan", "Feb", "Mrt", "Apr", "Mei", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dec" };
            foreach( string m in months)
            {
                categoryAxis.Labels.Add(m);
            }

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