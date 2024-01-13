namespace HouseholdAccountBook_Mock
{
    partial class ToastManager
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
            this.BtnToastTestSend = new System.Windows.Forms.Button();
            this.BtnToastSend = new System.Windows.Forms.Button();
            this.Txt_Toast = new System.Windows.Forms.Label();
            this.DTPickerToast = new System.Windows.Forms.DateTimePicker();
            this.Txt_ToastDate = new System.Windows.Forms.Label();
            this.TxtToastUseFlg = new System.Windows.Forms.Label();
            this.CbToastUseFlg = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TxtAddTime = new System.Windows.Forms.Label();
            this.TbAddHour = new System.Windows.Forms.TextBox();
            this.TxtAddHour = new System.Windows.Forms.Label();
            this.TxtAddMinute = new System.Windows.Forms.Label();
            this.TbAddMinute = new System.Windows.Forms.TextBox();
            this.panelToast = new System.Windows.Forms.Panel();
            this.ToastNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelToast.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnToastTestSend
            // 
            this.BtnToastTestSend.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnToastTestSend.Location = new System.Drawing.Point(60, 351);
            this.BtnToastTestSend.Name = "BtnToastTestSend";
            this.BtnToastTestSend.Size = new System.Drawing.Size(160, 50);
            this.BtnToastTestSend.TabIndex = 0;
            this.BtnToastTestSend.Text = "通知テスト";
            this.BtnToastTestSend.UseVisualStyleBackColor = true;
            this.BtnToastTestSend.Click += new System.EventHandler(this.BtnToastTestSend_Click);
            // 
            // BtnToastSend
            // 
            this.BtnToastSend.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnToastSend.Location = new System.Drawing.Point(310, 351);
            this.BtnToastSend.Name = "BtnToastSend";
            this.BtnToastSend.Size = new System.Drawing.Size(160, 50);
            this.BtnToastSend.TabIndex = 1;
            this.BtnToastSend.Text = "通知設定";
            this.BtnToastSend.UseVisualStyleBackColor = true;
            this.BtnToastSend.Click += new System.EventHandler(this.BtnToastSend_Click);
            // 
            // Txt_Toast
            // 
            this.Txt_Toast.AutoSize = true;
            this.Txt_Toast.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Txt_Toast.Location = new System.Drawing.Point(187, 28);
            this.Txt_Toast.Name = "Txt_Toast";
            this.Txt_Toast.Size = new System.Drawing.Size(324, 30);
            this.Txt_Toast.TabIndex = 2;
            this.Txt_Toast.Text = "通知を送信する日時指定";
            // 
            // DTPickerToast
            // 
            this.DTPickerToast.CalendarFont = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPickerToast.CustomFormat = "yyyy年MM月dd日";
            this.DTPickerToast.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPickerToast.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPickerToast.Location = new System.Drawing.Point(316, 176);
            this.DTPickerToast.Name = "DTPickerToast";
            this.DTPickerToast.Size = new System.Drawing.Size(344, 44);
            this.DTPickerToast.TabIndex = 3;
            this.DTPickerToast.Value = new System.DateTime(2021, 2, 11, 0, 0, 0, 0);
            // 
            // Txt_ToastDate
            // 
            this.Txt_ToastDate.AutoSize = true;
            this.Txt_ToastDate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Txt_ToastDate.Location = new System.Drawing.Point(126, 188);
            this.Txt_ToastDate.Name = "Txt_ToastDate";
            this.Txt_ToastDate.Size = new System.Drawing.Size(133, 30);
            this.Txt_ToastDate.TabIndex = 4;
            this.Txt_ToastDate.Text = "通知日時";
            // 
            // TxtToastUseFlg
            // 
            this.TxtToastUseFlg.AutoSize = true;
            this.TxtToastUseFlg.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtToastUseFlg.Location = new System.Drawing.Point(126, 105);
            this.TxtToastUseFlg.Name = "TxtToastUseFlg";
            this.TxtToastUseFlg.Size = new System.Drawing.Size(133, 30);
            this.TxtToastUseFlg.TabIndex = 5;
            this.TxtToastUseFlg.Text = "通知有無";
            // 
            // CbToastUseFlg
            // 
            this.CbToastUseFlg.AutoSize = true;
            this.CbToastUseFlg.Location = new System.Drawing.Point(316, 118);
            this.CbToastUseFlg.Name = "CbToastUseFlg";
            this.CbToastUseFlg.Size = new System.Drawing.Size(18, 17);
            this.CbToastUseFlg.TabIndex = 6;
            this.CbToastUseFlg.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnCancel.Location = new System.Drawing.Point(560, 351);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TxtAddTime
            // 
            this.TxtAddTime.AutoSize = true;
            this.TxtAddTime.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtAddTime.Location = new System.Drawing.Point(126, 271);
            this.TxtAddTime.Name = "TxtAddTime";
            this.TxtAddTime.Size = new System.Drawing.Size(133, 30);
            this.TxtAddTime.TabIndex = 8;
            this.TxtAddTime.Text = "追加時刻";
            // 
            // TbAddHour
            // 
            this.TbAddHour.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbAddHour.Location = new System.Drawing.Point(316, 271);
            this.TbAddHour.MaxLength = 2;
            this.TbAddHour.Name = "TbAddHour";
            this.TbAddHour.Size = new System.Drawing.Size(76, 34);
            this.TbAddHour.TabIndex = 9;
            this.TbAddHour.Text = "0";
            this.TbAddHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtAddHour
            // 
            this.TxtAddHour.AutoSize = true;
            this.TxtAddHour.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtAddHour.Location = new System.Drawing.Point(400, 275);
            this.TxtAddHour.Name = "TxtAddHour";
            this.TxtAddHour.Size = new System.Drawing.Size(73, 30);
            this.TxtAddHour.TabIndex = 10;
            this.TxtAddHour.Text = "時間";
            // 
            // TxtAddMinute
            // 
            this.TxtAddMinute.AutoSize = true;
            this.TxtAddMinute.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtAddMinute.Location = new System.Drawing.Point(577, 275);
            this.TxtAddMinute.Name = "TxtAddMinute";
            this.TxtAddMinute.Size = new System.Drawing.Size(43, 30);
            this.TxtAddMinute.TabIndex = 12;
            this.TxtAddMinute.Text = "分";
            // 
            // TbAddMinute
            // 
            this.TbAddMinute.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbAddMinute.Location = new System.Drawing.Point(485, 271);
            this.TbAddMinute.MaxLength = 2;
            this.TbAddMinute.Name = "TbAddMinute";
            this.TbAddMinute.Size = new System.Drawing.Size(76, 34);
            this.TbAddMinute.TabIndex = 11;
            this.TbAddMinute.Text = "0";
            this.TbAddMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panelToast
            // 
            this.panelToast.Controls.Add(this.Txt_Toast);
            this.panelToast.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToast.Location = new System.Drawing.Point(0, 0);
            this.panelToast.Name = "panelToast";
            this.panelToast.Size = new System.Drawing.Size(780, 91);
            this.panelToast.TabIndex = 13;
            // 
            // ToastNotifyIcon
            // 
            this.ToastNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToastNotifyIcon.Text = "テスト";
            this.ToastNotifyIcon.Visible = true;
            // 
            // ToastManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 482);
            this.ControlBox = false;
            this.Controls.Add(this.TxtAddMinute);
            this.Controls.Add(this.TbAddMinute);
            this.Controls.Add(this.TxtAddHour);
            this.Controls.Add(this.TbAddHour);
            this.Controls.Add(this.TxtAddTime);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.CbToastUseFlg);
            this.Controls.Add(this.TxtToastUseFlg);
            this.Controls.Add(this.Txt_ToastDate);
            this.Controls.Add(this.DTPickerToast);
            this.Controls.Add(this.BtnToastSend);
            this.Controls.Add(this.BtnToastTestSend);
            this.Controls.Add(this.panelToast);
            this.Name = "ToastManager";
            this.Text = "ToastManager";
            this.Load += new System.EventHandler(this.ToastManager_Load);
            this.panelToast.ResumeLayout(false);
            this.panelToast.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnToastTestSend;
        private System.Windows.Forms.Button BtnToastSend;
        private System.Windows.Forms.Label Txt_Toast;
        private System.Windows.Forms.DateTimePicker DTPickerToast;
        private System.Windows.Forms.Label Txt_ToastDate;
        private System.Windows.Forms.Label TxtToastUseFlg;
        private System.Windows.Forms.CheckBox CbToastUseFlg;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label TxtAddTime;
        private System.Windows.Forms.TextBox TbAddHour;
        private System.Windows.Forms.Label TxtAddHour;
        private System.Windows.Forms.Label TxtAddMinute;
        private System.Windows.Forms.TextBox TbAddMinute;
        private System.Windows.Forms.Panel panelToast;
        private System.Windows.Forms.NotifyIcon ToastNotifyIcon;
    }
}