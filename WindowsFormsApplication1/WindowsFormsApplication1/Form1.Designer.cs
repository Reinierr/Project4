namespace WindowsFormsApplication1 {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel3 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel4 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel5 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel6 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel7 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel8 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel9 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel10 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel11 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel12 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.button2 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.graphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.barchartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bikeTheftsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.pieChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.byColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.byBrandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chart1
			// 
			this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			customLabel1.FromPosition = 0.5D;
			customLabel1.Text = "Jan";
			customLabel1.ToPosition = 1.5D;
			customLabel2.FromPosition = 1.5D;
			customLabel2.Text = "Feb";
			customLabel2.ToPosition = 2.5D;
			customLabel3.FromPosition = 2.5D;
			customLabel3.Text = "Mar";
			customLabel3.ToPosition = 3.5D;
			customLabel4.FromPosition = 3.5D;
			customLabel4.Text = "Apr";
			customLabel4.ToPosition = 4.5D;
			customLabel5.FromPosition = 4.5D;
			customLabel5.Text = "May";
			customLabel5.ToPosition = 5.5D;
			customLabel6.FromPosition = 5.5D;
			customLabel6.Text = "Jun";
			customLabel6.ToPosition = 6.5D;
			customLabel7.FromPosition = 6.5D;
			customLabel7.Text = "Jul";
			customLabel7.ToPosition = 7.5D;
			customLabel8.FromPosition = 7.5D;
			customLabel8.Text = "Aug";
			customLabel8.ToPosition = 8.5D;
			customLabel9.FromPosition = 8.5D;
			customLabel9.Text = "Sep";
			customLabel9.ToPosition = 9.5D;
			customLabel10.FromPosition = 9.5D;
			customLabel10.Text = "Oct";
			customLabel10.ToPosition = 10.5D;
			customLabel11.FromPosition = 10.5D;
			customLabel11.Text = "Nov";
			customLabel11.ToPosition = 11.5D;
			customLabel12.FromPosition = 11.5D;
			customLabel12.Text = "Dec";
			customLabel12.ToPosition = 12.5D;
			chartArea1.AxisX.CustomLabels.Add(customLabel1);
			chartArea1.AxisX.CustomLabels.Add(customLabel2);
			chartArea1.AxisX.CustomLabels.Add(customLabel3);
			chartArea1.AxisX.CustomLabels.Add(customLabel4);
			chartArea1.AxisX.CustomLabels.Add(customLabel5);
			chartArea1.AxisX.CustomLabels.Add(customLabel6);
			chartArea1.AxisX.CustomLabels.Add(customLabel7);
			chartArea1.AxisX.CustomLabels.Add(customLabel8);
			chartArea1.AxisX.CustomLabels.Add(customLabel9);
			chartArea1.AxisX.CustomLabels.Add(customLabel10);
			chartArea1.AxisX.CustomLabels.Add(customLabel11);
			chartArea1.AxisX.CustomLabels.Add(customLabel12);
			chartArea1.Name = "Default";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(12, 31);
			this.chart1.Name = "chart1";
			this.chart1.Size = new System.Drawing.Size(745, 434);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			title1.Name = "Title1";
			this.chart1.Titles.Add(title1);
			this.chart1.Click += new System.EventHandler(this.chart1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(682, 473);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 21);
			this.button2.TabIndex = 5;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(769, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// graphsToolStripMenuItem
			// 
			this.graphsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barchartToolStripMenuItem,
            this.pieChartToolStripMenuItem});
			this.graphsToolStripMenuItem.Name = "graphsToolStripMenuItem";
			this.graphsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.graphsToolStripMenuItem.Text = "Graphs";
			// 
			// barchartToolStripMenuItem
			// 
			this.barchartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bikeTheftsToolStripMenuItem});
			this.barchartToolStripMenuItem.Name = "barchartToolStripMenuItem";
			this.barchartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.barchartToolStripMenuItem.Text = "Barchart";
			// 
			// bikeTheftsToolStripMenuItem
			// 
			this.bikeTheftsToolStripMenuItem.Name = "bikeTheftsToolStripMenuItem";
			this.bikeTheftsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.bikeTheftsToolStripMenuItem.Text = "Bike thefts";
			this.bikeTheftsToolStripMenuItem.Click += new System.EventHandler(this.bikeTheftsToolStripMenuItem_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(12, 473);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(664, 21);
			this.comboBox1.TabIndex = 7;
			// 
			// pieChartToolStripMenuItem
			// 
			this.pieChartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byColorToolStripMenuItem,
            this.byBrandToolStripMenuItem});
			this.pieChartToolStripMenuItem.Name = "pieChartToolStripMenuItem";
			this.pieChartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.pieChartToolStripMenuItem.Text = "Pie chart";
			// 
			// byColorToolStripMenuItem
			// 
			this.byColorToolStripMenuItem.Name = "byColorToolStripMenuItem";
			this.byColorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.byColorToolStripMenuItem.Text = "By Color";
			this.byColorToolStripMenuItem.Click += new System.EventHandler(this.byColorToolStripMenuItem_Click);
			// 
			// byBrandToolStripMenuItem
			// 
			this.byBrandToolStripMenuItem.Name = "byBrandToolStripMenuItem";
			this.byBrandToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.byBrandToolStripMenuItem.Text = "By Brand";
			this.byBrandToolStripMenuItem.Click += new System.EventHandler(this.byBrandToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(769, 506);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem graphsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem barchartToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bikeTheftsToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ToolStripMenuItem pieChartToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem byColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem byBrandToolStripMenuItem;
	}
}

