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
            tab.SetIcon(Resource.Drawable.barcharticon);
            tab.TabSelected += (sender, args) =>
            {
                SetContentView(Resource.Layout.barChartEdit);
                List<string> spinnerArray = new List<string>();
                spinnerArray.Add("one");
                spinnerArray.Add("two");
                spinnerArray.Add("three");
                spinnerArray.Add("four");
                spinnerArray.Add("5");
                spinnerArray.Add("six");
                Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

                spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
                var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, spinnerArray);
                adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                spinner.Adapter = adapter;
            };
            ActionBar.AddTab(tab);

            tab = ActionBar.NewTab();
            tab.SetText("Single Bar Chart");
            tab.SetIcon(Resource.Drawable.barcharticon);
            tab.TabSelected += (sender, args) =>
            {
                SetContentView(Resource.Layout.barChart);
                PlotView view = FindViewById<PlotView>(Resource.Id.plot_view_bar);
                CreateBarChart barchart = new CreateBarChart();
                view.Model = barchart.CreatePlotModel();
            };
            ActionBar.AddTab(tab);
            /*     EditText buurtname = FindViewById<EditText>(Resource.Id.buurtname);
                 buurtname.KeyPress += (object sender, View.KeyEventArgs e) =>
                 {
                     if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                     {
                         this.buurt = buurtname.Text;
                         PlotView view = FindViewById<PlotView>(Resource.Id.plot_view_bar);
                         CreateGroupedBarChart barchart = new CreateGroupedBarChart(buurt);
                         view.Model = barchart.CreatePlotModel();
                         InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);

                         inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
                     }
                     else
                     {
                         e.Handled = false;
                     }
                 };*/

        }
        public void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
        }
    }


    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2140:TransparentMethodsMustNotReferenceCriticalCodeFxCopRule")]
    public class CreateGroupedBarChart : IChart
    {
        private string buurt;
        private string deelgem;
        public CreateGroupedBarChart(string buurt)
        {
            if (buurt.Length > 0)
            {
                this.buurt = preLoad.csvFD.getBuurt(buurt);
                this.deelgem = buurt;
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
                Title = "BarChart",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0

            };
            IFactory factory = new ConcreteFactory();
            var s1 = factory.CreateColumnSeriesBasic(buurt);
            var s2 = factory.CreateColumnSeriesBasic(deelgem);
            var categoryAxis = factory.CreateCategoryAxisMonths();
            var valueAxis = factory.CreateLinearAxisBasic("totaal aantal");

            Dictionary<int, int> fs = preLoad.csvFD.getBarchartGroupFD(buurt);
            foreach (KeyValuePair<int, int> item in fs)
            {
                s1.Items.Add(new ColumnItem { Value = item.Value });
            }

            Dictionary<int, int> fs2 = preLoad.csvFT.getBarchartGroupFT(deelgem);
            foreach (KeyValuePair<int, int> item in fs2)
            {
                s2.Items.Add(new ColumnItem { Value = item.Value });
            }

            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            return model;
        }
    }

    public class CreateBarChart : IChart
    {
        public PlotModel CreatePlotModel()
        {
            var model = new PlotModel
            {
                Title = "Top 5 wijken",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0

            };
            IFactory factory = new ConcreteFactory();
            var s1 = factory.CreateColumnSeriesBasic("FietsTrommels");
            var categoryAxis = factory.CreateCategoryAxisBasic("FietsTrommels");
            var valueAxis = factory.CreateLinearAxisBasic("Totaal Aantal");

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