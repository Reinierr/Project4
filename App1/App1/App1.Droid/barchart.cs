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
    [Activity(Label = "barchart")]
    public class barchart : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.barChart);
            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view_bar);
            view.Model = CreatePlotModel();

            // Create your application here
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2140:TransparentMethodsMustNotReferenceCriticalCodeFxCopRule")]
        public PlotModel CreatePlotModel()
        {
            string test = "Faalhaas 49";
            var model = new PlotModel {
                Title = "BarChart",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0

            };

            var s1 = new ColumnSeries { Title = "Serie 1", StrokeColor = OxyColors.Black, StrokeThickness = 1 , FontSize = 24};
            s1.Items.Add(new ColumnItem { Value = 25 });
            s1.Items.Add(new ColumnItem { Value = 137 });

            var s2 = new ColumnSeries { Title = "Series 2", StrokeColor = OxyColors.Black, StrokeThickness = 1 , FontSize = 24 };
            s2.Items.Add(new ColumnItem { Value = 16 });
            s2.Items.Add(new ColumnItem { Value = 200 });
            var s3 = new ColumnSeries { Title = "MoerWijk", StrokeColor = OxyColors.Black, StrokeThickness = 1 , FontSize = 24};
            s3.Items.Add(new ColumnItem { Value = 255 });
            s3.Items.Add(new ColumnItem { Value = 15 });
            
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom, FontSize = 24 };
            categoryAxis.Labels.Add("Henk");
            categoryAxis.Labels.Add(test);
            var valueAxis = new LinearAxis { Position = AxisPosition.Left, Minimum= 0, Maximum = 300 , FontSize = 24};

            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Series.Add(s3);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            return model;
        }
    }
}