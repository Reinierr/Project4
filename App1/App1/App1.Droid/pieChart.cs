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

            seriesP1.Slices.Add(new PieSlice("Giant", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP1.Slices.Add(new PieSlice("Batavus", 929) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Gazelle", 4157) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Piagio", 739) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Holland", 35) { IsExploded = true });

            modelP1.Series.Add(seriesP1);

            return modelP1;
        }
    }
}