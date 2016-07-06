using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1 {
	

	public partial class Form1 : Form {
		CSVConnection csvFD, csvFT;
		SeriesChartType status;
		Adaptor seriesAdaptor;
	
		public Form1() {
			InitializeComponent();
			csvFD = new CSVConnection("fietsdiefstal", new StreamReader("Contents/fietsdiefstal.csv")); // Initializes Database Connection
			csvFT = new CSVConnection("fietstrommel", new StreamReader("Contents/fietstrommels.csv"));
			seriesAdaptor = new SeriesAdaptor(); //Creates Adaptor
		}

		private void Form1_Load(object sender, EventArgs e) {
			//createSeries(chart1, "Mannen");
		}

		private void button1_Click(object sender, EventArgs e) {
			
		}

		private void chart1_Click(object sender, EventArgs e) {
			//Random m = new Random();
			//addToChart(chart1, "Memes", m.Next(0, 10));
			//addToChart(chart1, "Vrouwen", m.Next(0, 10));
		}

		private void changeAxisTitle(Chart chart, string x, string y) { //Is called whenever titles on axis are to be changed
			chart.ChartAreas["Default"].AxisX.Title = x; //Changes x/y axis tites to text given
			chart.ChartAreas["Default"].AxisY.Title = y;
		}



		private void addToChart<t>(Chart chart, string Series, Dictionary<t, int> yValue) { //Adds data to chart, suitable for Column, Line and Pie diagrams, as used in the application.
			int i = 0;
			int items = 7; //Limits amount of items shown in pie chart
			foreach (KeyValuePair<t, int> a in yValue) {
				if (chart.Series[Series].ChartType == SeriesChartType.Pie) { //Checks if charttype is Pie chart, if so: pie-specific code is utilized
					if (i != items) {
						DataPoint dataPoint = new DataPoint();
						if (a.Key.ToString() == "") {
							dataPoint.LegendText = "Unknown";
							dataPoint.ToolTip = "Unknown";
							dataPoint.Name = "Unknown";
							dataPoint.Label = "#PERCENT";
						}
						else {
							dataPoint.Name = a.Key.ToString(); //Extracts names and values from dictionary to put in the datapoint
							dataPoint.LegendText = a.Key.ToString().First().ToString().ToUpper() + a.Key.ToString().ToLower().Substring(1) + " - " + a.Value.ToString() + " bikes";
							dataPoint.ToolTip = a.Key.ToString().First().ToString().ToUpper() + a.Key.ToString().ToLower().Substring(1);
							dataPoint.Label = "#PERCENT"; //Puts percentages inside of pie chart
						}
						
						dataPoint.XValue = 0;
						dataPoint.YValues = new double[] { a.Value };
						chart.Series[Series].Points.Add(dataPoint); //Add complete datapoint to pie chart
						
						i++;
					}
					
				}
				else {
					chart.Series[Series].Points.AddXY(0, a.Value); //If graph series is not pie chart, simply add values to graph
				}
					
				}
				//Console.WriteLine(a.Value.ToString());
			}

		private void addToChart_CustomColors(Chart chart, string Series, Dictionary<string, int> yValue) {
			int i = 0;
			int items = 8; //Limits amount of items used in pie chart
			foreach (KeyValuePair<string, int> a in yValue) {
				if (i != items) {
					DataPoint dataPoint = new DataPoint();
					if (a.Key.ToString() == "") {
						dataPoint.LegendText = "Unknown";
						dataPoint.ToolTip = "Unknown";
						dataPoint.Name = "Unknown";
						dataPoint.Label = "#PERCENT";
					}
					else {
						dataPoint.Name = a.Key.ToString();
						dataPoint.LegendText = a.Key.ToString().First().ToString().ToUpper() + a.Key.ToString().ToLower().Substring(1) + " - " + a.Value.ToString() + " bikes";
						dataPoint.Label = "#PERCENT";
						dataPoint.ToolTip = a.Key.ToString().First().ToString().ToUpper() + a.Key.ToString().ToLower().Substring(1);
						Console.WriteLine(a.Key.ToString());
						if (getColor(a.Key.ToString()) != Color.Empty) {
							dataPoint.Color = getColor(a.Key.ToString());
							if (dataPoint.Color == Color.Black || dataPoint.Color == Color.DarkBlue) { //Checks if color is too dark
								dataPoint.LabelForeColor = Color.White; //Change labeltext to white if color is black or darkblue

							}
						}						
					}

					dataPoint.XValue = 0;
					dataPoint.YValues = new double[] { a.Value };
					chart.Series[Series].Points.Add(dataPoint);

					i++;
				}
			}
		}

		private Color getColor(string dC) { //Translates CSV Color strings to Color
			if (dC == "ZWART") {
				return Color.Black;
			}
			else if (dC == "BLAUW") {
				return Color.DarkBlue;
			}
			else if (dC == "ONBEKEND") {
				return Color.Empty;
			}
			else if (dC == "GRIJS") {
				return Color.Gray;
			}
			else if (dC == "ZILVERKLEURIG") {
				return Color.Silver;
			}
			else if (dC == "MEERKLEURIG") {
				return Color.Yellow;
			}
			else if (dC == "WIT") {
				return Color.AntiqueWhite;
			}
			else if (dC == "GROEN") {
				return Color.Green;
			}
			else if (dC == "ROOD") {
				return Color.Red;
			}
			else if (dC == "PAARS") {
				return Color.Purple;
			}
			else {
				return Color.Empty; //If colorstring is not in database, return an empty color
			}
		}


		private void bikeTheftsToolStripMenuItem_Click(object sender, EventArgs e) { //Creates a barchart with customizable neighborhoods to compare
			chart1.Series.Clear();
			status = SeriesChartType.Column; //Set status to Column, so that Button2 knows to make a column series if clicked
			List<string> buurten = csvFD.getBuurten(); //Gets all neighborhoods and stores them in the dropdown box
			foreach (string buurt in buurten) {
				comboBox1.Items.Add(buurt);
			}
			comboBox1.Text = "Select neighborhood";
			changeAxisTitle(chart1, "months", "bikes stolen");
			chart1.Titles["Title1"].Text = "Bike thefts in certain neigborhoods per month"; //Sets title of chart to string

			//Sets last clicked button to false, and all others to true to reset previously disabled buttons
			bikeTheftsToolStripMenuItem.Enabled = false;
			byColorToolStripMenuItem.Enabled = true;
			byBrandToolStripMenuItem.Enabled = true;
			button2.Enabled = true;
			bikeTheftsToolStripMenuItem1.Enabled = true;
			bikeTheftsPerNeighborhoodToolStripMenuItem.Enabled = true;
			//--
		}

		private void byColorToolStripMenuItem_Click(object sender, EventArgs e) { //Creates a pie chart sorted by color
			chart1.Series.Clear(); //Clears previous series
			comboBox1.Items.Clear(); //Clears combobox items
			seriesAdaptor.adapt(chart1, new string[] { "fietsdiefstallen" }, SeriesChartType.Pie); //Add a piechart series to the chart
			chart1.Titles["Title1"].Text = "Bike thefts by color";
			addToChart_CustomColors(chart1, "fietsdiefstallen", csvFD.getPiechartColorFull()); //Adds values to series
			byColorToolStripMenuItem.Enabled = false;
			bikeTheftsToolStripMenuItem.Enabled = true;
			byBrandToolStripMenuItem.Enabled = true;
			button2.Enabled = false;
			bikeTheftsToolStripMenuItem1.Enabled = true;
			bikeTheftsPerNeighborhoodToolStripMenuItem.Enabled = true;
		}

		private void byBrandToolStripMenuItem_Click(object sender, EventArgs e) { //Creates a pie chart sorted by brand
			chart1.Series.Clear();
			comboBox1.Items.Clear();
			seriesAdaptor.adapt(chart1, new string[] { "fietsdiefstallen" }, SeriesChartType.Pie);
			chart1.Titles["Title1"].Text = "Bike thefts by brand";
			addToChart(chart1, "fietsdiefstallen", csvFD.getPiechartBrandFull());
			byColorToolStripMenuItem.Enabled = true;
			bikeTheftsToolStripMenuItem.Enabled = true;
			button2.Enabled = false;
			byBrandToolStripMenuItem.Enabled = false;
			bikeTheftsToolStripMenuItem1.Enabled = true;
			bikeTheftsPerNeighborhoodToolStripMenuItem.Enabled = true;
		}

		private void bikeTheftsToolStripMenuItem1_Click(object sender, EventArgs e) { //Creates a line chart of overall bikes stolen
			chart1.Series.Clear();
			comboBox1.Items.Clear();
			seriesAdaptor.adapt(chart1, new string[] { "Stolen bikes" }, SeriesChartType.Line);
			chart1.Titles["Title1"].Text = "Bike thefts in Rijnmond region per month";
			addToChart(chart1, "Stolen bikes", csvFD.getLinechart());
			bikeTheftsToolStripMenuItem1.Enabled = false;
			byColorToolStripMenuItem.Enabled = true;
			bikeTheftsToolStripMenuItem.Enabled = true;
			byBrandToolStripMenuItem.Enabled = true;
			button2.Enabled = false;
			bikeTheftsPerNeighborhoodToolStripMenuItem.Enabled = true;
			changeAxisTitle(chart1, "months", "bikes stolen");
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) { //Opens the about Form
			Form2 form = new Form2();
			form.Show();
		}

		private string getQualityName(string oldname) { //Transforms a CSV name in format [XX NAMEHERE] where XX are numbers, to format [XX Namehere] where XX are numbers
			string getname = oldname.Substring(3);
			return oldname.Substring(0, 3) + getname.First().ToString().ToUpper() + getname.ToLower().Substring(1); //returns edited string
		}

		private void button2_Click(object sender, EventArgs e) { //Sets or removes neighborhoods to current active chart
			string name;
			if (comboBox1.SelectedItem != null) {
				int count = comboBox1.SelectedItem.ToString().Count();
				if (count >= 4) {
					name = "Diefstal: " +  getQualityName(comboBox1.SelectedItem.ToString());
				}
				else {
					name = comboBox1.SelectedItem.ToString();
				}
				Console.WriteLine(name);
				if (name != "") { //Checks if comboboxitem is none

					if (csvFD.getBarchartGroupFD(comboBox1.SelectedItem.ToString()).Count != 0) {
						if (chart1.Series.IsUniqueName(name)) {
							seriesAdaptor.adapt(chart1, new string[] { name }, status);
							addToChart(chart1, name, csvFD.getBarchartGroupFD(comboBox1.SelectedItem.ToString()));
						}
						else {
							List<Series> saveSeries = new List<Series>();
							foreach (Series serie in chart1.Series) {
								if (serie.Name != name) {
									saveSeries.Add(serie);
								}
							}
							chart1.Series.Clear();
							foreach (Series serie in saveSeries) {
								chart1.Series.Add(serie);
							}
						}
					}
				}
			}		
		}

		private void bikeTheftsPerNeighborhoodToolStripMenuItem_Click(object sender, EventArgs e) { //Creates a line chart with customizable neighborhoods
			chart1.Series.Clear();
			status = SeriesChartType.Line;
			List<string> buurten = csvFD.getBuurten();
			foreach (string buurt in buurten) {
				comboBox1.Items.Add(buurt);
			}
			button2.Enabled = true;
			chart1.Titles["Title1"].Text = "Bike thefts in certain neigborhoods per month";
			changeAxisTitle(chart1, "months", "bikes stolen");
			bikeTheftsPerNeighborhoodToolStripMenuItem.Enabled = false;
      neighborhoodsWithMostBikeContainersToolStripMenuItem.Enabled = true;
      groupedBarchartOfTheftsAndContainersToolStripMenuItem.Enabled = true;
      bikeTheftsToolStripMenuItem1.Enabled = true;
			byColorToolStripMenuItem.Enabled = true;
			bikeTheftsToolStripMenuItem.Enabled = true;
			byBrandToolStripMenuItem.Enabled = true;
		}

    private void neighborhoodsWithMostBikeContainersToolStripMenuItem_Click(object sender, EventArgs e) {//Creates a barchart with bike containers
      chart1.Series.Clear();
      status = SeriesChartType.Column;
      seriesAdaptor.adapt(chart1, new string[] { "Centrum", "Delfshaven" , "Feijenoord" ,"Kralingen/Crooswijk", "Noord" }, SeriesChartType.Column);
      addToChart(chart1, "Centrum", csvFT.getBarchartGroupFT("centrum"));
      addToChart(chart1, "Delfshaven", csvFT.getBarchartGroupFT("delfshaven"));
      addToChart(chart1, "Feijenoord", csvFT.getBarchartGroupFT("feijenoord"));
      addToChart(chart1, "Kralingen/Crooswijk", csvFT.getBarchartGroupFT("kralingen/crooswijk"));
      addToChart(chart1, "Noord", csvFT.getBarchartGroupFT("noord"));
      changeAxisTitle(chart1, "months", "Bike container erected");
      chart1.Titles["Title1"].Text = "Bike containers erected per month per borough";
      button2.Enabled = false;
      groupedBarchartOfTheftsAndContainersToolStripMenuItem.Enabled = true;
      neighborhoodsWithMostBikeContainersToolStripMenuItem.Enabled = false;
      bikeTheftsToolStripMenuItem1.Enabled = true;
      byColorToolStripMenuItem.Enabled = true;
      bikeTheftsToolStripMenuItem.Enabled = true;
      byBrandToolStripMenuItem.Enabled = true;
    }

    private void groupedBarchartOfTheftsAndContainersToolStripMenuItem_Click(object sender, EventArgs e) { //Creates a barchart with bike containers and 
      chart1.Series.Clear();
      status = SeriesChartType.Column;
      seriesAdaptor.adapt(chart1, new string[] { "Container: Centrum", "Container: Delfshaven", "Container: Feijenoord", "Container: Kralingen/Crooswijk", "Container: Noord" }, SeriesChartType.Column);
      addToChart(chart1, "Container: Centrum", csvFT.getBarchartGroupFT("centrum"));
      addToChart(chart1, "Container: Delfshaven", csvFT.getBarchartGroupFT("delfshaven"));
      addToChart(chart1, "Container: Feijenoord", csvFT.getBarchartGroupFT("feijenoord"));
      addToChart(chart1, "Container: Kralingen/Crooswijk", csvFT.getBarchartGroupFT("kralingen/crooswijk"));
      addToChart(chart1, "Container: Noord", csvFT.getBarchartGroupFT("noord"));
      List<string> buurten = csvFD.getBuurten();
      foreach (string buurt in buurten)
      {
        comboBox1.Items.Add(buurt);
      }
      changeAxisTitle(chart1, "months", "bikes stolen / containers erected");
      chart1.Titles["Title1"].Text = "Amount of thefts and containers in each neighborhood";
      bikeTheftsToolStripMenuItem.Enabled = true;
      byColorToolStripMenuItem.Enabled = true;
      byBrandToolStripMenuItem.Enabled = true;
      button2.Enabled = true;
      bikeTheftsToolStripMenuItem1.Enabled = true;
      bikeTheftsPerNeighborhoodToolStripMenuItem.Enabled = true;
      neighborhoodsWithMostBikeContainersToolStripMenuItem.Enabled = true;
      groupedBarchartOfTheftsAndContainersToolStripMenuItem.Enabled = false;
    }
  }
}
