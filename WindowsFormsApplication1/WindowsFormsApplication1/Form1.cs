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
		CSVConnection csvFD;
		public Form1() {
			InitializeComponent();
			csvFD = new CSVConnection("fietsdiefstal", new StreamReader("Contents/fietsdiefstal.csv"));
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

		private void createSeries(Chart chart, string[] name, SeriesChartType type) {
			foreach(string individualName in name) {
				chart.Series.Add(individualName);
				chart.Series[individualName].ChartType = type;
			}			
		}
		private void changeAxisTitle(Chart chart, string x, string y) {
			chart.ChartAreas["Default"].AxisX.Title = x;
			chart.ChartAreas["Default"].AxisY.Title = y;
		}

		private void changeAxisText(Chart chart, string action) {
			if (action == "months") {

			}
		}

		private void addToChart<t>(Chart chart, string Series, Dictionary<t, int> yValue) {
			Console.WriteLine("AAAAAAAAA");
			int i = 0;
			int items = 10;
			foreach (KeyValuePair<t, int> a in yValue) {
				if (chart.Series[Series].ChartType == SeriesChartType.Pie) {
					if (i != items) {
						DataPoint dataPoint = new DataPoint();
						if (a.Key.ToString() == "") {
							dataPoint.LegendText = "Unknown";
							dataPoint.ToolTip = "Unknown";
						}
						else {
							dataPoint.LegendText = a.Key.ToString().First().ToString().ToUpper() + a.Key.ToString().ToLower().Substring(1);
							dataPoint.ToolTip = a.Key.ToString().First().ToString().ToUpper() + a.Key.ToString().ToLower().Substring(1);
						}
						dataPoint.XValue = 0;
						dataPoint.YValues = new double[] { a.Value };
						chart.Series[Series].Points.Add(dataPoint);
						i++;
					}
					
				}
				else {
					chart.Series[Series].Points.AddXY(0, a.Value);
				}
					
				}
				//Console.WriteLine(a.Value.ToString());
			}			

		//private void button2_Click(object sender, EventArgs e) {
		//	if (comboBox1.Text != "") {
		//		if (csvFD.getBarchartGroupFD(comboBox1.Text).Count != 0) {
		//			if (chart1.Series.IsUniqueName(comboBox1.Text)) {
		//				createSeries(chart1, new string[] { comboBox1.Text }, SeriesChartType.Column);
		//				addToChart(chart1, comboBox1.Text, csvFD.getBarchartGroupFD(comboBox1.Text));
		//			}
		//		}
		//	}				
		//}

		private void bikeTheftsToolStripMenuItem_Click(object sender, EventArgs e) {
			chart1.Series.Clear();

			createSeries(chart1, new string[] { "Centrum", "Vreewijk", "Tarwewijk" }, SeriesChartType.Column);
			changeAxisTitle(chart1, "months", "bikes stolen");
			chart1.Titles["Title1"].Text = "Barchart";
			addToChart(chart1, "Centrum", csvFD.getBarchartGroupFD("01 CENTRUM"));
			addToChart(chart1, "Vreewijk", csvFD.getBarchartGroupFD("80 VREEWIJK"));
			var a = csvFD.getBarchartGroupFD("71 TARWEWIJK");
			addToChart(chart1, "Tarwewijk", csvFD.getBarchartGroupFD("71 TARWEWIJK"));
			chart1.ChartAreas["Default"].AxisX.Maximum = 13;

			bikeTheftsToolStripMenuItem.Enabled = false;
			byColorToolStripMenuItem.Enabled = true;
			byBrandToolStripMenuItem.Enabled = true;
		}

		private void byColorToolStripMenuItem_Click(object sender, EventArgs e) {
			chart1.Series.Clear();

			createSeries(chart1, new string[] { "fietsdiefstallen" }, SeriesChartType.Pie);
			chart1.Titles["Title1"].Text = "Bike thefts by color";
			addToChart(chart1, "fietsdiefstallen", csvFD.getPiechartColorFull());
			byColorToolStripMenuItem.Enabled = false;
			bikeTheftsToolStripMenuItem.Enabled = true;
			byBrandToolStripMenuItem.Enabled = true;
		}

		private void byBrandToolStripMenuItem_Click(object sender, EventArgs e) {
			chart1.Series.Clear();

			createSeries(chart1, new string[] { "fietsdiefstallen" }, SeriesChartType.Pie);
			chart1.Titles["Title1"].Text = "Bike thefts by brand";
			addToChart(chart1, "fietsdiefstallen", csvFD.getPiechartBrandFull());
			byColorToolStripMenuItem.Enabled = true;
			bikeTheftsToolStripMenuItem.Enabled = true;
			byBrandToolStripMenuItem.Enabled = false;
		}
	}
	
}
