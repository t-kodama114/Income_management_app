namespace HouseholdAccountBook_Mock.User_Control
{
    partial class UCStatistics
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.DTPickerBreakdown = new System.Windows.Forms.DateTimePicker();
            this.CbPeriod = new System.Windows.Forms.ComboBox();
            this.LvRecord = new System.Windows.Forms.ListView();
            this.BtnPDFCreateor = new System.Windows.Forms.Button();
            this.BtnImageCreateor = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.pChartStatistics = new LiveCharts.WinForms.PieChart();
            this.DTPickerBreakdown02 = new System.Windows.Forms.DateTimePicker();
            this.CbClassification = new System.Windows.Forms.ComboBox();
            this.txtClassification = new System.Windows.Forms.Label();
            this.txtPeriodType = new System.Windows.Forms.Label();
            this.BtnDateUpdate = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.pChartStatistics2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pChartStatistics2)).BeginInit();
            this.SuspendLayout();
            // 
            // DTPickerBreakdown
            // 
            this.DTPickerBreakdown.CalendarFont = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPickerBreakdown.CustomFormat = "yyyy年MM月dd日";
            this.DTPickerBreakdown.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPickerBreakdown.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPickerBreakdown.Location = new System.Drawing.Point(3, 16);
            this.DTPickerBreakdown.Name = "DTPickerBreakdown";
            this.DTPickerBreakdown.ShowUpDown = true;
            this.DTPickerBreakdown.Size = new System.Drawing.Size(307, 40);
            this.DTPickerBreakdown.TabIndex = 3;
            this.DTPickerBreakdown.Value = new System.DateTime(2020, 12, 5, 0, 0, 0, 0);
            // 
            // CbPeriod
            // 
            this.CbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPeriod.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CbPeriod.FormattingEnabled = true;
            this.CbPeriod.Location = new System.Drawing.Point(646, 76);
            this.CbPeriod.Name = "CbPeriod";
            this.CbPeriod.Size = new System.Drawing.Size(155, 45);
            this.CbPeriod.TabIndex = 4;
            this.CbPeriod.SelectedIndexChanged += new System.EventHandler(this.CbPeriod_SelectedIndexChanged);
            // 
            // LvRecord
            // 
            this.LvRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvRecord.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LvRecord.HideSelection = false;
            this.LvRecord.Location = new System.Drawing.Point(24, 538);
            this.LvRecord.Name = "LvRecord";
            this.LvRecord.Size = new System.Drawing.Size(763, 236);
            this.LvRecord.TabIndex = 8;
            this.LvRecord.UseCompatibleStateImageBehavior = false;
            this.LvRecord.View = System.Windows.Forms.View.Details;
            // 
            // BtnPDFCreateor
            // 
            this.BtnPDFCreateor.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnPDFCreateor.Location = new System.Drawing.Point(24, 802);
            this.BtnPDFCreateor.Name = "BtnPDFCreateor";
            this.BtnPDFCreateor.Size = new System.Drawing.Size(213, 56);
            this.BtnPDFCreateor.TabIndex = 9;
            this.BtnPDFCreateor.Text = "PDF作成";
            this.BtnPDFCreateor.UseVisualStyleBackColor = true;
            this.BtnPDFCreateor.Click += new System.EventHandler(this.BtnPDFCreateor_Click);
            // 
            // BtnImageCreateor
            // 
            this.BtnImageCreateor.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnImageCreateor.Location = new System.Drawing.Point(243, 802);
            this.BtnImageCreateor.Name = "BtnImageCreateor";
            this.BtnImageCreateor.Size = new System.Drawing.Size(208, 56);
            this.BtnImageCreateor.TabIndex = 10;
            this.BtnImageCreateor.Text = "画像作成";
            this.BtnImageCreateor.UseVisualStyleBackColor = true;
            this.BtnImageCreateor.Click += new System.EventHandler(this.BtnImageCreateor_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnPrint.Location = new System.Drawing.Point(623, 802);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(178, 56);
            this.BtnPrint.TabIndex = 11;
            this.BtnPrint.Text = "プレビュー";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // pChartStatistics
            // 
            this.pChartStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pChartStatistics.BackColor = System.Drawing.SystemColors.Info;
            this.pChartStatistics.Enabled = false;
            this.pChartStatistics.Location = new System.Drawing.Point(24, 144);
            this.pChartStatistics.Name = "pChartStatistics";
            this.pChartStatistics.Size = new System.Drawing.Size(763, 388);
            this.pChartStatistics.TabIndex = 13;
            this.pChartStatistics.TabStop = false;
            this.pChartStatistics.Text = "pChartStatistics";
            this.pChartStatistics.Visible = false;
            // 
            // DTPickerBreakdown02
            // 
            this.DTPickerBreakdown02.CalendarFont = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPickerBreakdown02.CustomFormat = "yyyy年MM月dd日";
            this.DTPickerBreakdown02.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPickerBreakdown02.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPickerBreakdown02.Location = new System.Drawing.Point(316, 16);
            this.DTPickerBreakdown02.Name = "DTPickerBreakdown02";
            this.DTPickerBreakdown02.ShowUpDown = true;
            this.DTPickerBreakdown02.Size = new System.Drawing.Size(301, 40);
            this.DTPickerBreakdown02.TabIndex = 15;
            this.DTPickerBreakdown02.Value = new System.DateTime(2020, 12, 5, 0, 0, 0, 0);
            this.DTPickerBreakdown02.Visible = false;
            // 
            // CbClassification
            // 
            this.CbClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbClassification.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CbClassification.FormattingEnabled = true;
            this.CbClassification.Items.AddRange(new object[] {
            "収入",
            "支出"});
            this.CbClassification.Location = new System.Drawing.Point(135, 76);
            this.CbClassification.Name = "CbClassification";
            this.CbClassification.Size = new System.Drawing.Size(169, 45);
            this.CbClassification.TabIndex = 16;
            this.CbClassification.SelectedIndexChanged += new System.EventHandler(this.CbClassification_SelectedIndexChanged);
            // 
            // txtClassification
            // 
            this.txtClassification.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtClassification.Location = new System.Drawing.Point(9, 76);
            this.txtClassification.Name = "txtClassification";
            this.txtClassification.Size = new System.Drawing.Size(120, 42);
            this.txtClassification.TabIndex = 17;
            this.txtClassification.Text = "分類 :";
            // 
            // txtPeriodType
            // 
            this.txtPeriodType.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPeriodType.Location = new System.Drawing.Point(439, 76);
            this.txtPeriodType.Name = "txtPeriodType";
            this.txtPeriodType.Size = new System.Drawing.Size(201, 42);
            this.txtPeriodType.TabIndex = 7;
            this.txtPeriodType.Text = "期間種類 :";
            // 
            // BtnDateUpdate
            // 
            this.BtnDateUpdate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnDateUpdate.Location = new System.Drawing.Point(623, 11);
            this.BtnDateUpdate.Name = "BtnDateUpdate";
            this.BtnDateUpdate.Size = new System.Drawing.Size(194, 51);
            this.BtnDateUpdate.TabIndex = 19;
            this.BtnDateUpdate.Text = "日付更新";
            this.BtnDateUpdate.UseVisualStyleBackColor = true;
            this.BtnDateUpdate.Click += new System.EventHandler(this.BtnDateUpdate_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.CbClassification);
            this.panelMain.Controls.Add(this.CbPeriod);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(820, 146);
            this.panelMain.TabIndex = 21;
            // 
            // pChartStatistics2
            // 
            this.pChartStatistics2.BackColor = System.Drawing.Color.Moccasin;
            this.pChartStatistics2.BorderlineColor = System.Drawing.Color.Black;
            chartArea6.Name = "ChartArea1";
            this.pChartStatistics2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            legend6.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pChartStatistics2.Legends.Add(legend6);
            this.pChartStatistics2.Location = new System.Drawing.Point(24, 144);
            this.pChartStatistics2.Name = "pChartStatistics2";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series6.Legend = "Legend1";
            series6.LegendText = "Test1";
            series6.Name = "Series1";
            this.pChartStatistics2.Series.Add(series6);
            this.pChartStatistics2.Size = new System.Drawing.Size(763, 388);
            this.pChartStatistics2.TabIndex = 22;
            this.pChartStatistics2.Text = "chart2";
            // 
            // UCStatistics
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pChartStatistics2);
            this.Controls.Add(this.BtnDateUpdate);
            this.Controls.Add(this.txtClassification);
            this.Controls.Add(this.DTPickerBreakdown02);
            this.Controls.Add(this.pChartStatistics);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.BtnImageCreateor);
            this.Controls.Add(this.BtnPDFCreateor);
            this.Controls.Add(this.LvRecord);
            this.Controls.Add(this.txtPeriodType);
            this.Controls.Add(this.DTPickerBreakdown);
            this.Controls.Add(this.panelMain);
            this.Name = "UCStatistics";
            this.Size = new System.Drawing.Size(820, 890);
            this.Load += new System.EventHandler(this.UCStatistics_Load);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pChartStatistics2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPickerBreakdown;
        private System.Windows.Forms.ComboBox CbPeriod;
        private System.Windows.Forms.ListView LvRecord;
        private System.Windows.Forms.Button BtnPDFCreateor;
        private System.Windows.Forms.Button BtnImageCreateor;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.DateTimePicker DTPickerBreakdown02;
        private System.Windows.Forms.ComboBox CbClassification;
        private System.Windows.Forms.Label txtClassification;
        private System.Windows.Forms.Label txtPeriodType;
        private System.Windows.Forms.Button BtnDateUpdate;
        private System.Windows.Forms.Panel panelMain;
        private LiveCharts.WinForms.PieChart pChartStatistics;
        private System.Windows.Forms.DataVisualization.Charting.Chart pChartStatistics2;
    }
}
