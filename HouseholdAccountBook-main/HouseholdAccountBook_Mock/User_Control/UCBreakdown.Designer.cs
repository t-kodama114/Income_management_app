namespace HouseholdAccountBook_Mock.User_Control
{
    partial class UCBreakdown
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
            this.TCBreakdown = new System.Windows.Forms.TabControl();
            this.TPBreakdownOneDay = new System.Windows.Forms.TabPage();
            this.LvRecord = new System.Windows.Forms.ListView();
            this.BtnNewData = new System.Windows.Forms.Button();
            this.FLPanelResult = new System.Windows.Forms.FlowLayoutPanel();
            this.LbIncome = new System.Windows.Forms.ListBox();
            this.LbSpending = new System.Windows.Forms.ListBox();
            this.LbSettlement = new System.Windows.Forms.ListBox();
            this.TPBreakdownByDay = new System.Windows.Forms.TabPage();
            this.TPBreakdownByWeek = new System.Windows.Forms.TabPage();
            this.TPBreakdownByMonth = new System.Windows.Forms.TabPage();
            this.DTPickerBreakdown = new System.Windows.Forms.DateTimePicker();
            this.panelMain = new System.Windows.Forms.Panel();
            this.TCBreakdown.SuspendLayout();
            this.TPBreakdownOneDay.SuspendLayout();
            this.FLPanelResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCBreakdown
            // 
            this.TCBreakdown.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.TCBreakdown.Controls.Add(this.TPBreakdownOneDay);
            this.TCBreakdown.Controls.Add(this.TPBreakdownByDay);
            this.TCBreakdown.Controls.Add(this.TPBreakdownByWeek);
            this.TCBreakdown.Controls.Add(this.TPBreakdownByMonth);
            this.TCBreakdown.Location = new System.Drawing.Point(6, 67);
            this.TCBreakdown.Name = "TCBreakdown";
            this.TCBreakdown.SelectedIndex = 0;
            this.TCBreakdown.Size = new System.Drawing.Size(734, 699);
            this.TCBreakdown.TabIndex = 1;
            this.TCBreakdown.Selected += new System.Windows.Forms.TabControlEventHandler(this.TCBreakdown_Selected);
            // 
            // TPBreakdownOneDay
            // 
            this.TPBreakdownOneDay.Controls.Add(this.LvRecord);
            this.TPBreakdownOneDay.Controls.Add(this.BtnNewData);
            this.TPBreakdownOneDay.Controls.Add(this.FLPanelResult);
            this.TPBreakdownOneDay.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TPBreakdownOneDay.Location = new System.Drawing.Point(4, 25);
            this.TPBreakdownOneDay.Name = "TPBreakdownOneDay";
            this.TPBreakdownOneDay.Padding = new System.Windows.Forms.Padding(3);
            this.TPBreakdownOneDay.Size = new System.Drawing.Size(726, 670);
            this.TPBreakdownOneDay.TabIndex = 0;
            this.TPBreakdownOneDay.Text = "1日";
            this.TPBreakdownOneDay.UseVisualStyleBackColor = true;
            // 
            // LvRecord
            // 
            this.LvRecord.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LvRecord.HideSelection = false;
            this.LvRecord.Location = new System.Drawing.Point(7, 90);
            this.LvRecord.Name = "LvRecord";
            this.LvRecord.Size = new System.Drawing.Size(713, 484);
            this.LvRecord.TabIndex = 2;
            this.LvRecord.UseCompatibleStateImageBehavior = false;
            this.LvRecord.View = System.Windows.Forms.View.Details;
            // 
            // BtnNewData
            // 
            this.BtnNewData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNewData.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnNewData.Location = new System.Drawing.Point(493, 604);
            this.BtnNewData.Name = "BtnNewData";
            this.BtnNewData.Size = new System.Drawing.Size(227, 60);
            this.BtnNewData.TabIndex = 1;
            this.BtnNewData.Text = "新規データ作成";
            this.BtnNewData.UseVisualStyleBackColor = true;
            this.BtnNewData.Click += new System.EventHandler(this.BtnNewData_Click);
            // 
            // FLPanelResult
            // 
            this.FLPanelResult.Controls.Add(this.LbIncome);
            this.FLPanelResult.Controls.Add(this.LbSpending);
            this.FLPanelResult.Controls.Add(this.LbSettlement);
            this.FLPanelResult.Location = new System.Drawing.Point(7, 7);
            this.FLPanelResult.Name = "FLPanelResult";
            this.FLPanelResult.Size = new System.Drawing.Size(713, 76);
            this.FLPanelResult.TabIndex = 0;
            // 
            // LbIncome
            // 
            this.LbIncome.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbIncome.FormattingEnabled = true;
            this.LbIncome.ItemHeight = 30;
            this.LbIncome.Items.AddRange(new object[] {
            "　　　　収入",
            "　　   　　0"});
            this.LbIncome.Location = new System.Drawing.Point(3, 3);
            this.LbIncome.Name = "LbIncome";
            this.LbIncome.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LbIncome.Size = new System.Drawing.Size(230, 64);
            this.LbIncome.TabIndex = 1;
            this.LbIncome.Click += new System.EventHandler(this.LbIncome_Click);
            // 
            // LbSpending
            // 
            this.LbSpending.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbSpending.FormattingEnabled = true;
            this.LbSpending.ItemHeight = 30;
            this.LbSpending.Items.AddRange(new object[] {
            "　　　　支出",
            "　　   　　0"});
            this.LbSpending.Location = new System.Drawing.Point(239, 3);
            this.LbSpending.Name = "LbSpending";
            this.LbSpending.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LbSpending.Size = new System.Drawing.Size(230, 64);
            this.LbSpending.TabIndex = 2;
            this.LbSpending.Click += new System.EventHandler(this.LbSpending_Click);
            // 
            // LbSettlement
            // 
            this.LbSettlement.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbSettlement.FormattingEnabled = true;
            this.LbSettlement.ItemHeight = 30;
            this.LbSettlement.Items.AddRange(new object[] {
            "　　　　合計",
            "　　   　　0"});
            this.LbSettlement.Location = new System.Drawing.Point(475, 3);
            this.LbSettlement.Name = "LbSettlement";
            this.LbSettlement.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LbSettlement.Size = new System.Drawing.Size(230, 64);
            this.LbSettlement.TabIndex = 3;
            this.LbSettlement.Click += new System.EventHandler(this.LbSettlement_Click);
            // 
            // TPBreakdownByDay
            // 
            this.TPBreakdownByDay.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TPBreakdownByDay.Location = new System.Drawing.Point(4, 25);
            this.TPBreakdownByDay.Name = "TPBreakdownByDay";
            this.TPBreakdownByDay.Padding = new System.Windows.Forms.Padding(3);
            this.TPBreakdownByDay.Size = new System.Drawing.Size(726, 670);
            this.TPBreakdownByDay.TabIndex = 1;
            this.TPBreakdownByDay.Text = "日別";
            this.TPBreakdownByDay.UseVisualStyleBackColor = true;
            // 
            // TPBreakdownByWeek
            // 
            this.TPBreakdownByWeek.Location = new System.Drawing.Point(4, 25);
            this.TPBreakdownByWeek.Name = "TPBreakdownByWeek";
            this.TPBreakdownByWeek.Padding = new System.Windows.Forms.Padding(3);
            this.TPBreakdownByWeek.Size = new System.Drawing.Size(726, 670);
            this.TPBreakdownByWeek.TabIndex = 2;
            this.TPBreakdownByWeek.Text = "週別";
            this.TPBreakdownByWeek.UseVisualStyleBackColor = true;
            // 
            // TPBreakdownByMonth
            // 
            this.TPBreakdownByMonth.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TPBreakdownByMonth.Location = new System.Drawing.Point(4, 25);
            this.TPBreakdownByMonth.Name = "TPBreakdownByMonth";
            this.TPBreakdownByMonth.Size = new System.Drawing.Size(726, 670);
            this.TPBreakdownByMonth.TabIndex = 3;
            this.TPBreakdownByMonth.Text = "月別";
            this.TPBreakdownByMonth.UseVisualStyleBackColor = true;
            // 
            // DTPickerBreakdown
            // 
            this.DTPickerBreakdown.CalendarFont = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPickerBreakdown.CustomFormat = "yyyy年MM月";
            this.DTPickerBreakdown.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPickerBreakdown.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPickerBreakdown.Location = new System.Drawing.Point(17, 17);
            this.DTPickerBreakdown.Name = "DTPickerBreakdown";
            this.DTPickerBreakdown.ShowUpDown = true;
            this.DTPickerBreakdown.Size = new System.Drawing.Size(240, 44);
            this.DTPickerBreakdown.TabIndex = 2;
            this.DTPickerBreakdown.Value = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(750, 176);
            this.panelMain.TabIndex = 10;
            // 
            // UCBreakdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DTPickerBreakdown);
            this.Controls.Add(this.TCBreakdown);
            this.Controls.Add(this.panelMain);
            this.Name = "UCBreakdown";
            this.Size = new System.Drawing.Size(750, 780);
            this.Load += new System.EventHandler(this.UCBreakdown_Load);
            this.TCBreakdown.ResumeLayout(false);
            this.TPBreakdownOneDay.ResumeLayout(false);
            this.FLPanelResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TCBreakdown;
        private System.Windows.Forms.TabPage TPBreakdownOneDay;
        private System.Windows.Forms.TabPage TPBreakdownByDay;
        private System.Windows.Forms.TabPage TPBreakdownByWeek;
        private System.Windows.Forms.TabPage TPBreakdownByMonth;
        private System.Windows.Forms.FlowLayoutPanel FLPanelResult;
        private System.Windows.Forms.ListBox LbSpending;
        private System.Windows.Forms.ListBox LbSettlement;
        private System.Windows.Forms.Button BtnNewData;
        private System.Windows.Forms.ListView LvRecord;
        private System.Windows.Forms.DateTimePicker DTPickerBreakdown;
        private System.Windows.Forms.ListBox LbIncome;
        private System.Windows.Forms.Panel panelMain;
    }
}
