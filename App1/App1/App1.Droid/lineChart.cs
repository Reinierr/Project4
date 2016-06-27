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
    [Activity(Label = "linechart")]
    public class linechart : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.lineChart);
            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);
            view.Model = CreatePlotModel();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2140:TransparentMethodsMustNotReferenceCriticalCodeFxCopRule")]
        protected PlotModel CreatePlotModel()
        {
            string title = "fietsdiefstallen per maand";
            var plotModel = new PlotModel
            {
                Title = title,
                TitleFontSize = 24,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0

            };
           // plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Maanden", TitleFontSize = 20, }); //TitleColor = OxyColors.White, AxislineColor = OxyColors.White});
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0, Title = "Diefstal", TitleFontSize = 20 });// TitleColor = OxyColors.White, TitleFontSize = 20});
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


            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };
            Random y = new Random();
            for (Double i = 0; i < 13; i++)
            {
                Double z = y.Next(0, 11);
                series1.Points.Add(new DataPoint(i, z));
            }
            var series2 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Yellow,


            };
            Random h = new Random();
            for (Double i = 0; i < 13; i++)
            {

                Double z = h.Next(0, 11);
                series2.Points.Add(new DataPoint(i, z));
            }

            plotModel.Series.Add(series1);
            plotModel.Series.Add(series2);
            plotModel.Axes.Add(categoryAxis);

            return plotModel;
        }
    }
}