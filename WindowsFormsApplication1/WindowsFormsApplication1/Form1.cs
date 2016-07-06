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
		public Form1() {
			InitializeComponent();
			csvFD = new CSVConnection("fietsdiefstal", new StreamReader("Contents/fietsdiefstal.csv"));
			csvFT = new CSVConnection("fietstrommel", new StreamReader("Contents/fietstrommels.csv"));
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
			int i = 0;
			int items = 7;
			foreach (KeyValuePair<t, int> a in yValue) {
				if (chart.Series[Series].ChartType == SeriesChartType.Pie) {
					if (i != items) {
						DataPoint dataPoint = new DataPoint();
						string var;
						if (a.Key.ToString() == "") {
							dataPoint.LegendText = "Unknown";
							dataPoint.ToolTip = "Unknown";
							dataPoint.Name = "Unknown";
						}
						else {
							dataPoint.Name = a.Key.ToString();
							dataPoint.LegendText = a.Key.ToString().First().ToString().ToUpper() + a.Key.ToString().ToLower().Substring(1) + " - " + a.Value.ToString() + " bikes";
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

		private void addToChart_CustomColors(Chart chart, string Series, Dictionary<string, int> yValue) {
			int i = 0;
			int items = 8;
			Console.WriteLine("Dank Maymes");
			foreach (KeyValuePair<string, int> a in yValue) {

				if (i != items) {
					DataPoint dataPoint = new DataPoint();
					string var;
					if (a.Key.ToString() == "") {
						dataPoint.LegendText = "Unknown";
						dataPoint.ToolTip = "Unknown";
						dataPoint.Name = "Unknown";
					}
					else {
						dataPoint.Name = a.Key.ToString();
						dataPoint.LegendText = a.Key.ToString().First().ToString().ToUpper() + a.Key.ToString().ToLower().Substring(1) + " - " + a.Value.ToString() + " bikes";
						dataPoint.ToolTip = a.Key.ToString().First().ToString().ToUpper() + a.Key.ToString().ToLower().Substring(1);
						Console.WriteLine(a.Key.ToString());
						if (getColor(a.Key.ToString()) != Color.Empty) {
							dataPoint.Color = getColor(a.Key.ToString());
						}						
					}

					dataPoint.XValue = 0;
					dataPoint.YValues = new double[] { a.Value };
					chart.Series[Series].Points.Add(dataPoint);

					i++;
				}
			}
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
		private Color getColor(string dC) {
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
				return Color.Empty;
			}
		}


		private void bikeTheftsToolStripMenuItem_Click(object sender, EventArgs e) {
			chart1.Series.Clear();
			status = SeriesChartType.Column;
			List<string> buurten = csvFD.getBuurten();
			foreach (string buurt in buurten) {
				comboBox1.Items.Add(buurt);
			}

			//createSeries(chart1, new string[] { "Centrum", "Vreewijk", "Tarwewijk" }, SeriesChartType.Column);
			changeAxisTitle(chart1, "months", "bikes stolen");
			chart1.Titles["Title1"].Text = "Bike thefts in certain neigborhoods per month";
			//addToChart(chart1, "Centrum", csvFD.getBarchartGroupFD("01 CENTRUM"));
			//addToChart(chart1, "Vreewijk", csvFD.getBarchartGroupFD("80 VREEWIJK"));
			//var a = csvFD.getBarchartGroupFD("71 TARWEWIJK");
			//addToChart(chart1, "Tarwewijk", csvFD.getBarchartGroupFD("71 TARWEWIJK"));
			

			bikeTheftsToolStripMenuItem.Enabled = false;
			byColorToolStripMenuItem.Enabled = true;
			byBrandToolStripMenuItem.Enabled = true;
			button2.Enabled = true;
			bikeTheftsToolStripMenuItem1.Enabled = true;
			bikeTheftsPerNeighborhoodToolStripMenuItem.Enabled = true;
		}

		private void byColorToolStripMenuItem_Click(object sender, EventArgs e) {
			chart1.Series.Clear();
			comboBox1.Items.Clear();
			createSeries(chart1, new string[] { "fietsdiefstallen" }, SeriesChartType.Pie);
			chart1.Titles["Title1"].Text = "Bike thefts by color";
			addToChart_CustomColors(chart1, "fietsdiefstallen", csvFD.getPiechartColorFull());
			byColorToolStripMenuItem.Enabled = false;
			bikeTheftsToolStripMenuItem.Enabled = true;
			byBrandToolStripMenuItem.Enabled = true;
			button2.Enabled = false;
			bikeTheftsToolStripMenuItem1.Enabled = true;
			bikeTheftsPerNeighborhoodToolStripMenuItem.Enabled = true;
		}

		private void byBrandToolStripMenuItem_Click(object sender, EventArgs e) {
			chart1.Series.Clear();
			comboBox1.Items.Clear();
			createSeries(chart1, new string[] { "fietsdiefstallen" }, SeriesChartType.Pie);
			chart1.Titles["Title1"].Text = "Bike thefts by brand";
			addToChart(chart1, "fietsdiefstallen", csvFD.getPiechartBrandFull());
			byColorToolStripMenuItem.Enabled = true;
			bikeTheftsToolStripMenuItem.Enabled = true;
			button2.Enabled = false;
			byBrandToolStripMenuItem.Enabled = false;
			bikeTheftsToolStripMenuItem1.Enabled = true;
			bikeTheftsPerNeighborhoodToolStripMenuItem.Enabled = true;
		}

		private void bikeTheftsToolStripMenuItem1_Click(object sender, EventArgs e) {
			chart1.Series.Clear();
			comboBox1.Items.Clear();
			createSeries(chart1, new string[] { "Stolen bikes" }, SeriesChartType.Line);
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

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			Form2 form = new Form2();
			form.Show();
		}

		private string getQualityName(string oldname) {
			string getname = oldname.Substring(3);
			return oldname.Substring(0, 3) + getname.First().ToString().ToUpper() + getname.ToLower().Substring(1);
		}

		private void button2_Click(object sender, EventArgs e) {
			string name;
			if (comboBox1.SelectedItem != null) {
				int count = comboBox1.SelectedItem.ToString().Count();
				if (count >= 4) {
					name = getQualityName(comboBox1.SelectedItem.ToString());
				}
				else {
					name = comboBox1.SelectedItem.ToString();
				}
				Console.WriteLine(name);
				//Console.WriteLine("'" + name + "'");
				if (name != "") {

					if (csvFD.getBarchartGroupFD(comboBox1.SelectedItem.ToString()).Count != 0) {
						if (chart1.Series.IsUniqueName(name)) {
							Console.WriteLine(name + "'");
							createSeries(chart1, new string[] { name }, status);
							addToChart(chart1, name, csvFD.getBarchartGroupFD(comboBox1.SelectedItem.ToString()));

						}
						else {
							Console.WriteLine("A");
							List<Series> saveSeries = new List<Series>();
							foreach (Series serie in chart1.Series) {
								//Console.WriteLine(serie.Name + "'" + name);
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

		private void bikeTheftsPerNeighborhoodToolStripMenuItem_Click(object sender, EventArgs e) {
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
			
			bikeTheftsToolStripMenuItem1.Enabled = true;
			byColorToolStripMenuItem.Enabled = true;
			bikeTheftsToolStripMenuItem.Enabled = true;
			byBrandToolStripMenuItem.Enabled = true;

		}
	}
}
