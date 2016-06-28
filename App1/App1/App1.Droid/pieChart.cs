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
    [Activity(Label = "piechart")]
    public class piechart : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.pieChart);
            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);
            view.Model = CreatePlotModel();
        }
        public PlotModel CreatePlotModel()
        {
            var modelP1 = new PlotModel { Title = "Most stolen bike brands" };

            var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            Dictionary<string, int> fdBrand = preLoad.csvFD.getPiechartBrand();
            foreach(KeyValuePair<string, int> item in fdBrand)
            {
              seriesP1.Slices.Add(new PieSlice(item.Key, item.Value) { IsExploded = true });
            }

            modelP1.Series.Add(seriesP1);

            return modelP1;
        }
    }
}