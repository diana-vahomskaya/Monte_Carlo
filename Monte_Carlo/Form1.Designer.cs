
namespace Monte_Carlo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PIC = new System.Windows.Forms.PictureBox();
            this.GENERATE = new System.Windows.Forms.Button();
            this.NodeCountY = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Maximum_MKSH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WindowCheck = new System.Windows.Forms.CheckBox();
            this.isAutoStop = new System.Windows.Forms.CheckBox();
            this.Start = new System.Windows.Forms.Button();
            this.NodeCountX = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_main = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.PIC)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // PIC
            // 
            this.PIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PIC.Location = new System.Drawing.Point(23, 13);
            this.PIC.Margin = new System.Windows.Forms.Padding(4);
            this.PIC.Name = "PIC";
            this.PIC.Size = new System.Drawing.Size(750, 750);
            this.PIC.TabIndex = 0;
            this.PIC.TabStop = false;
            // 
            // GENERATE
            // 
            this.GENERATE.Location = new System.Drawing.Point(28, 211);
            this.GENERATE.Margin = new System.Windows.Forms.Padding(4);
            this.GENERATE.Name = "GENERATE";
            this.GENERATE.Size = new System.Drawing.Size(120, 39);
            this.GENERATE.TabIndex = 1;
            this.GENERATE.Text = "Generate";
            this.GENERATE.UseVisualStyleBackColor = true;
            this.GENERATE.Click += new System.EventHandler(this.GENERATE_Click);
            // 
            // NodeCountY
            // 
            this.NodeCountY.FormattingEnabled = true;
            this.NodeCountY.Items.AddRange(new object[] {
            "100",
            "150",
            "200"});
            this.NodeCountY.Location = new System.Drawing.Point(143, 32);
            this.NodeCountY.Name = "NodeCountY";
            this.NodeCountY.Size = new System.Drawing.Size(121, 24);
            this.NodeCountY.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Maximum_MKSH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.WindowCheck);
            this.groupBox1.Controls.Add(this.isAutoStop);
            this.groupBox1.Controls.Add(this.Start);
            this.groupBox1.Controls.Add(this.NodeCountX);
            this.groupBox1.Controls.Add(this.GENERATE);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NodeCountY);
            this.groupBox1.Location = new System.Drawing.Point(1371, 321);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 339);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Начальная инициализация";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Макс. МКШ";
            // 
            // Maximum_MKSH
            // 
            this.Maximum_MKSH.Location = new System.Drawing.Point(143, 108);
            this.Maximum_MKSH.Name = "Maximum_MKSH";
            this.Maximum_MKSH.Size = new System.Drawing.Size(121, 23);
            this.Maximum_MKSH.TabIndex = 10;
            this.Maximum_MKSH.Text = "1024";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Шаг Монте-Карло: 0";
            // 
            // WindowCheck
            // 
            this.WindowCheck.AutoSize = true;
            this.WindowCheck.Location = new System.Drawing.Point(77, 183);
            this.WindowCheck.Name = "WindowCheck";
            this.WindowCheck.Size = new System.Drawing.Size(172, 21);
            this.WindowCheck.TabIndex = 8;
            this.WindowCheck.Text = "Движение через окно";
            this.WindowCheck.UseVisualStyleBackColor = true;
            // 
            // isAutoStop
            // 
            this.isAutoStop.AutoSize = true;
            this.isAutoStop.Checked = true;
            this.isAutoStop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAutoStop.Location = new System.Drawing.Point(114, 257);
            this.isAutoStop.Name = "isAutoStop";
            this.isAutoStop.Size = new System.Drawing.Size(95, 21);
            this.isAutoStop.TabIndex = 7;
            this.isAutoStop.Text = "isAutoStop";
            this.isAutoStop.UseVisualStyleBackColor = true;
            this.isAutoStop.CheckedChanged += new System.EventHandler(this.isAutoStop_CheckedChanged);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(173, 211);
            this.Start.Margin = new System.Windows.Forms.Padding(4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(120, 39);
            this.Start.TabIndex = 6;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // NodeCountX
            // 
            this.NodeCountX.FormattingEnabled = true;
            this.NodeCountX.Items.AddRange(new object[] {
            "100",
            "150",
            "200"});
            this.NodeCountX.Location = new System.Drawing.Point(143, 66);
            this.NodeCountX.Name = "NodeCountX";
            this.NodeCountX.Size = new System.Drawing.Size(121, 24);
            this.NodeCountX.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Кол-во узлов x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кол-во узлов y";
            // 
            // timer_main
            // 
            this.timer_main.Interval = 10;
            this.timer_main.Tick += new System.EventHandler(this.timer_main_Tick);
            // 
            // chart1
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(803, 13);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.DarkOrchid;
            series1.Legend = "Legend1";
            series1.Name = "МКШ/9";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Crimson;
            series2.Legend = "Legend1";
            series2.Name = "МКШ*4/9";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.MediumSeaGreen;
            series3.Legend = "Legend1";
            series3.Name = "МКШ";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(820, 300);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1734, 808);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PIC);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate";
            ((System.ComponentModel.ISupportInitialize)(this.PIC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PIC;
        private System.Windows.Forms.Button GENERATE;
        private System.Windows.Forms.ComboBox NodeCountY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox NodeCountX;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Timer timer_main;
        private System.Windows.Forms.CheckBox isAutoStop;
        private System.Windows.Forms.CheckBox WindowCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Maximum_MKSH;
    }
}

