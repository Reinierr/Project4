using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1 {
	interface Adaptor {
		void adapt(Chart chart, string[] names, SeriesChartType a);
	}

	class SeriesAdaptor : Adaptor {
		public void adapt(Chart chart, string[] names, SeriesChartType a) {
			foreach (string name in names) {
				chart.Series.Add(name);
				chart.Series[name].ChartType = a;
				if (a == SeriesChartType.Line) { //Do on creation of Line Series
					chart.Series[name].BorderWidth = 3; //Thicken border line
				}
			}
		}
	}
}
