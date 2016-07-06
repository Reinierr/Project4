using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;

namespace App1.Droid
{
   interface IFactory
    {
        LinearAxis CreateLinearAxisBasic(string AxisTitle);
        CategoryAxis CreateCategoryAxisMonths();
        CategoryAxis CreateCategoryAxisBasic(string AxisTitle);
        ColumnSeries CreateColumnSeriesBasic(string AxisTitle);
        PieSeries CreatePieSeriesBasic();
    }

    class ConcreteFactory : IFactory
    {
        public LinearAxis CreateLinearAxisBasic(string AxisTitle)
        {
            return new LinearAxis{ Position = AxisPosition.Left, IsPanEnabled = false , IsZoomEnabled = false, Title= AxisTitle };
        }
        public CategoryAxis CreateCategoryAxisMonths()
        {
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom , IsPanEnabled = false , IsZoomEnabled = false , Title = "Months"};

            string[] months = { "Jan", "Feb", "Mrt", "Apr", "Mei", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dec" };
            foreach (string m in months)
            {
                categoryAxis.Labels.Add(m);
            }

            return categoryAxis;
        }

        public CategoryAxis CreateCategoryAxisBasic(string AxisTitle)
        {
            return new CategoryAxis { Position = AxisPosition.Bottom, IsPanEnabled = false, IsZoomEnabled = false, Title = AxisTitle };
        }
        public ColumnSeries CreateColumnSeriesBasic(string AxisTitle)
        {
            return new ColumnSeries { StrokeColor = OxyColors.Black, StrokeThickness = 1 , Title = AxisTitle };
        }

        public PieSeries CreatePieSeriesBasic()
        {
            return new PieSeries { TickDistance = 9999, StrokeThickness = 2.0, InsideLabelPosition = 0.7, AngleSpan = 360, StartAngle = -90, InsideLabelFormat = "{1}: {2:0} %", OutsideLabelFormat = "", FontSize = 20 }; ;
        }
    }
}