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
    [Activity(Label = "barchart", Icon = "@drawable/icon")]
    public class barchart : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.barChart);
            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view_bar);
            CreateBarChart barchart = new CreateBarChart();
            view.Model = barchart.CreatePlotModel();
        }
    }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2140:TransparentMethodsMustNotReferenceCriticalCodeFxCopRule")]
    public class CreateBarChart : IChart
    {
      public PlotModel CreatePlotModel()
      {
        string buurt = "05 CENTRUM-OOST";
        string buurt2 = "Feijenoord";
        var model = new PlotModel
        {
          Title = "BarChart",
          LegendPlacement = LegendPlacement.Outside,
          LegendPosition = LegendPosition.BottomCenter,
          LegendOrientation = LegendOrientation.Horizontal,
          LegendBorderThickness = 0

        };
        var s1 = new ColumnSeries { Title = buurt, StrokeColor = OxyColors.Black, StrokeThickness = 1, FontSize = 24 };
        Dictionary<int, int> fs = preLoad.csvFD.getBarchartGroupFD(buurt);
        foreach (KeyValuePair<int, int> item in fs)
        {
          s1.Items.Add(new ColumnItem { Value = item.Value });
        }
        var s2 = new ColumnSeries { Title = buurt2, StrokeColor = OxyColors.Black, StrokeThickness = 1, FontSize = 24 };
        Dictionary<int, int> fs2 = preLoad.csvFT.getBarchartGroupFT(buurt2);
        foreach (KeyValuePair<int, int> item in fs2)
        {
          s2.Items.Add(new ColumnItem { Value = item.Value });
        }


        var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom, FontSize = 24 };
        categoryAxis.Labels.Add("Jan");
        categoryAxis.Labels.Add("Feb");
        categoryAxis.Labels.Add("Mrt");
        categoryAxis.Labels.Add("Apr");
        categoryAxis.Labels.Add("Mei");
        categoryAxis.Labels.Add("Jun");
        categoryAxis.Labels.Add("Jul");
        categoryAxis.Labels.Add("Aug");
        categoryAxis.Labels.Add("Sep");
        categoryAxis.Labels.Add("Okt");
        categoryAxis.Labels.Add("Nov");
        categoryAxis.Labels.Add("Dec");
        var valueAxis = new LinearAxis { Position = AxisPosition.Left, FontSize = 24 };

        model.Series.Add(s1);
        model.Series.Add(s2);
        model.Axes.Add(categoryAxis);
        model.Axes.Add(valueAxis);

        return model;
    }
  }
}