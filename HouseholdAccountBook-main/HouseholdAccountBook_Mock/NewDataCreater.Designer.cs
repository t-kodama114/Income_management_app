namespace HouseholdAccountBook_Mock
{
    partial class NewDataCreater
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
            this.TCNewDataCreater = new System.Windows.Forms.TabControl();
            this.TPIncome = new System.Windows.Forms.TabPage();
            this.TLPanelContent = new System.Windows.Forms.TableLayoutPanel();
            this.ContentTxt = new System.Windows.Forms.Label();
            this.FLPanelSetDate = new System.Windows.Forms.FlowLayoutPanel();
            this.McSelect = new System.Windows.Forms.MonthCalendar();
            this.BtnOk = new System.Windows.Forms.Button();
            this.TLPanelSave = new System.Windows.Forms.TableLayoutPanel();
            this.BtnContinue = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TLPanelInfo = new System.Windows.Forms.TableLayoutPanel();
            this.TxtContent = new System.Windows.Forms.Label();
            this.TbContent = new System.Windows.Forms.TextBox();
            this.TxtMoney = new System.Windows.Forms.Label();
            this.TbMoney = new System.Windows.Forms.TextBox();
            this.TxtClassification = new System.Windows.Forms.Label();
            this.TbClassification = new System.Windows.Forms.TextBox();
            this.TxtAssets = new System.Windows.Forms.Label();
            this.TbAssets = new System.Windows.Forms.TextBox();
            this.TxtDate = new System.Windows.Forms.Label();
            this.TbDate = new System.Windows.Forms.TextBox();
            this.TLPanelBtnSpace = new System.Windows.Forms.TableLayoutPanel();
            this.Btn12 = new System.Windows.Forms.Button();
            this.Btn11 = new System.Windows.Forms.Button();
            this.Btn10 = new System.Windows.Forms.Button();
            this.Btn9 = new System.Windows.Forms.Button();
            this.Btn8 = new System.Windows.Forms.Button();
            this.Btn7 = new System.Windows.Forms.Button();
            this.Btn5 = new System.Windows.Forms.Button();
            this.Btn4 = new System.Windows.Forms.Button();
            this.Btn3 = new System.Windows.Forms.Button();
            this.Btn2 = new System.Windows.Forms.Button();
            this.Btn1 = new System.Windows.Forms.Button();
            this.Btn6 = new System.Windows.Forms.Button();
            this.TPSpending = new System.Windows.Forms.TabPage();
            this.panelNewData = new System.Windows.Forms.Panel();
            this.TCNewDataCreater.SuspendLayout();
            this.TPIncome.SuspendLayout();
            this.TLPanelContent.SuspendLayout();
            this.FLPanelSetDate.SuspendLayout();
            this.TLPanelSave.SuspendLayout();
            this.TLPanelInfo.SuspendLayout();
            this.TLPanelBtnSpace.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCNewDataCreater
            // 
            this.TCNewDataCreater.Controls.Add(this.TPIncome);
            this.TCNewDataCreater.Controls.Add(this.TPSpending);
            this.TCNewDataCreater.Location = new System.Drawing.Point(12, 13);
            this.TCNewDataCreater.Name = "TCNewDataCreater";
            this.TCNewDataCreater.SelectedIndex = 0;
            this.TCNewDataCreater.Size = new System.Drawing.Size(745, 945);
            this.TCNewDataCreater.TabIndex = 0;
            this.TCNewDataCreater.Selected += new System.Windows.Forms.TabControlEventHandler(this.TCNewDataCreater_Selected);
            // 
            // TPIncome
            // 
            this.TPIncome.Controls.Add(this.FLPanelSetDate);
            this.TPIncome.Controls.Add(this.TLPanelContent);
            this.TPIncome.Controls.Add(this.TLPanelSave);
            this.TPIncome.Controls.Add(this.TLPanelInfo);
            this.TPIncome.Controls.Add(this.TLPanelBtnSpace);
            this.TPIncome.Location = new System.Drawing.Point(4, 25);
            this.TPIncome.Name = "TPIncome";
            this.TPIncome.Padding = new System.Windows.Forms.Padding(3);
            this.TPIncome.Size = new System.Drawing.Size(737, 916);
            this.TPIncome.TabIndex = 0;
            this.TPIncome.Text = "収入";
            this.TPIncome.UseVisualStyleBackColor = true;
            // 
            // TLPanelContent
            // 
            this.TLPanelContent.ColumnCount = 1;
            this.TLPanelContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPanelContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPanelContent.Controls.Add(this.ContentTxt, 0, 0);
            this.TLPanelContent.Location = new System.Drawing.Point(10, 343);
            this.TLPanelContent.Name = "TLPanelContent";
            this.TLPanelContent.RowCount = 1;
            this.TLPanelContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPanelContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.TLPanelContent.Size = new System.Drawing.Size(721, 65);
            this.TLPanelContent.TabIndex = 7;
            // 
            // ContentTxt
            // 
            this.ContentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ContentTxt.AutoSize = true;
            this.ContentTxt.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ContentTxt.Location = new System.Drawing.Point(3, 3);
            this.ContentTxt.Margin = new System.Windows.Forms.Padding(3);
            this.ContentTxt.Name = "ContentTxt";
            this.ContentTxt.Size = new System.Drawing.Size(97, 59);
            this.ContentTxt.TabIndex = 9;
            this.ContentTxt.Text = "内容";
            this.ContentTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FLPanelSetDate
            // 
            this.FLPanelSetDate.Controls.Add(this.McSelect);
            this.FLPanelSetDate.Controls.Add(this.BtnOk);
            this.FLPanelSetDate.Location = new System.Drawing.Point(14, 416);
            this.FLPanelSetDate.Name = "FLPanelSetDate";
            this.FLPanelSetDate.Size = new System.Drawing.Size(352, 494);
            this.FLPanelSetDate.TabIndex = 3;
            this.FLPanelSetDate.Visible = false;
            // 
            // McSelect
            // 
            this.McSelect.Location = new System.Drawing.Point(9, 9);
            this.McSelect.Name = "McSelect";
            this.McSelect.ShowToday = false;
            this.McSelect.TabIndex = 2;
            this.McSelect.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.McSelect_DateSelected);
            // 
            // BtnOk
            // 
            this.BtnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnOk.Font = new System.Drawing.Font("MS UI Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnOk.Location = new System.Drawing.Point(3, 225);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(254, 70);
            this.BtnOk.TabIndex = 5;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // TLPanelSave
            // 
            this.TLPanelSave.ColumnCount = 2;
            this.TLPanelSave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLPanelSave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelSave.Controls.Add(this.BtnContinue, 1, 0);
            this.TLPanelSave.Controls.Add(this.BtnSave, 0, 0);
            this.TLPanelSave.Location = new System.Drawing.Point(7, 274);
            this.TLPanelSave.Name = "TLPanelSave";
            this.TLPanelSave.RowCount = 1;
            this.TLPanelSave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPanelSave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.TLPanelSave.Size = new System.Drawing.Size(724, 62);
            this.TLPanelSave.TabIndex = 1;
            // 
            // BtnContinue
            // 
            this.BtnContinue.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnContinue.Location = new System.Drawing.Point(582, 3);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.Size = new System.Drawing.Size(139, 56);
            this.BtnContinue.TabIndex = 0;
            this.BtnContinue.Text = "続ける";
            this.BtnContinue.UseVisualStyleBackColor = true;
            this.BtnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnSave.Location = new System.Drawing.Point(3, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(573, 56);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TLPanelInfo
            // 
            this.TLPanelInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TLPanelInfo.ColumnCount = 2;
            this.TLPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.23204F));
            this.TLPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.76796F));
            this.TLPanelInfo.Controls.Add(this.TxtContent, 0, 4);
            this.TLPanelInfo.Controls.Add(this.TbContent, 1, 4);
            this.TLPanelInfo.Controls.Add(this.TxtMoney, 0, 3);
            this.TLPanelInfo.Controls.Add(this.TbMoney, 1, 3);
            this.TLPanelInfo.Controls.Add(this.TxtClassification, 0, 2);
            this.TLPanelInfo.Controls.Add(this.TbClassification, 1, 2);
            this.TLPanelInfo.Controls.Add(this.TxtAssets, 0, 1);
            this.TLPanelInfo.Controls.Add(this.TbAssets, 1, 1);
            this.TLPanelInfo.Controls.Add(this.TxtDate, 0, 0);
            this.TLPanelInfo.Controls.Add(this.TbDate, 1, 0);
            this.TLPanelInfo.Location = new System.Drawing.Point(7, 6);
            this.TLPanelInfo.Name = "TLPanelInfo";
            this.TLPanelInfo.RowCount = 5;
            this.TLPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelInfo.Size = new System.Drawing.Size(724, 261);
            this.TLPanelInfo.TabIndex = 0;
            // 
            // TxtContent
            // 
            this.TxtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtContent.AutoSize = true;
            this.TxtContent.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtContent.Location = new System.Drawing.Point(3, 211);
            this.TxtContent.Margin = new System.Windows.Forms.Padding(3);
            this.TxtContent.Name = "TxtContent";
            this.TxtContent.Size = new System.Drawing.Size(125, 47);
            this.TxtContent.TabIndex = 8;
            this.TxtContent.Text = "内容";
            this.TxtContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbContent
            // 
            this.TbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbContent.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbContent.Location = new System.Drawing.Point(134, 211);
            this.TbContent.MaxLength = 50;
            this.TbContent.Name = "TbContent";
            this.TbContent.Size = new System.Drawing.Size(587, 47);
            this.TbContent.TabIndex = 9;
            this.TbContent.Click += new System.EventHandler(this.TbContent_Click);
            // 
            // TxtMoney
            // 
            this.TxtMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMoney.AutoSize = true;
            this.TxtMoney.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtMoney.Location = new System.Drawing.Point(3, 159);
            this.TxtMoney.Margin = new System.Windows.Forms.Padding(3);
            this.TxtMoney.Name = "TxtMoney";
            this.TxtMoney.Size = new System.Drawing.Size(125, 46);
            this.TxtMoney.TabIndex = 6;
            this.TxtMoney.Text = "金額";
            this.TxtMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbMoney
            // 
            this.TbMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMoney.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbMoney.Location = new System.Drawing.Point(134, 159);
            this.TbMoney.MaxLength = 20;
            this.TbMoney.Name = "TbMoney";
            this.TbMoney.Size = new System.Drawing.Size(587, 47);
            this.TbMoney.TabIndex = 7;
            this.TbMoney.Click += new System.EventHandler(this.TbMoney_Click);
            this.TbMoney.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbMoney_KeyDown);
            // 
            // TxtClassification
            // 
            this.TxtClassification.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtClassification.AutoSize = true;
            this.TxtClassification.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtClassification.Location = new System.Drawing.Point(3, 107);
            this.TxtClassification.Margin = new System.Windows.Forms.Padding(3);
            this.TxtClassification.Name = "TxtClassification";
            this.TxtClassification.Size = new System.Drawing.Size(125, 46);
            this.TxtClassification.TabIndex = 4;
            this.TxtClassification.Text = "分類";
            this.TxtClassification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbClassification
            // 
            this.TbClassification.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbClassification.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbClassification.Location = new System.Drawing.Point(134, 107);
            this.TbClassification.Multiline = true;
            this.TbClassification.Name = "TbClassification";
            this.TbClassification.ReadOnly = true;
            this.TbClassification.Size = new System.Drawing.Size(587, 46);
            this.TbClassification.TabIndex = 5;
            this.TbClassification.Click += new System.EventHandler(this.TbClassification_Click);
            // 
            // TxtAssets
            // 
            this.TxtAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAssets.AutoSize = true;
            this.TxtAssets.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtAssets.Location = new System.Drawing.Point(3, 55);
            this.TxtAssets.Margin = new System.Windows.Forms.Padding(3);
            this.TxtAssets.Name = "TxtAssets";
            this.TxtAssets.Size = new System.Drawing.Size(125, 46);
            this.TxtAssets.TabIndex = 2;
            this.TxtAssets.Text = "資産";
            this.TxtAssets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbAssets
            // 
            this.TbAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbAssets.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbAssets.Location = new System.Drawing.Point(134, 55);
            this.TbAssets.Multiline = true;
            this.TbAssets.Name = "TbAssets";
            this.TbAssets.ReadOnly = true;
            this.TbAssets.Size = new System.Drawing.Size(587, 46);
            this.TbAssets.TabIndex = 3;
            this.TbAssets.Click += new System.EventHandler(this.TbAssets_Click);
            // 
            // TxtDate
            // 
            this.TxtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDate.AutoSize = true;
            this.TxtDate.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtDate.Location = new System.Drawing.Point(3, 3);
            this.TxtDate.Margin = new System.Windows.Forms.Padding(3);
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Size = new System.Drawing.Size(125, 46);
            this.TxtDate.TabIndex = 0;
            this.TxtDate.Text = "日付";
            this.TxtDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbDate
            // 
            this.TbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbDate.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbDate.Location = new System.Drawing.Point(134, 3);
            this.TbDate.Multiline = true;
            this.TbDate.Name = "TbDate";
            this.TbDate.Size = new System.Drawing.Size(587, 46);
            this.TbDate.TabIndex = 1;
            this.TbDate.Click += new System.EventHandler(this.TbDate_Click);
            // 
            // TLPanelBtnSpace
            // 
            this.TLPanelBtnSpace.ColumnCount = 4;
            this.TLPanelBtnSpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPanelBtnSpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPanelBtnSpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPanelBtnSpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPanelBtnSpace.Controls.Add(this.Btn12, 3, 2);
            this.TLPanelBtnSpace.Controls.Add(this.Btn11, 2, 2);
            this.TLPanelBtnSpace.Controls.Add(this.Btn10, 1, 2);
            this.TLPanelBtnSpace.Controls.Add(this.Btn9, 0, 2);
            this.TLPanelBtnSpace.Controls.Add(this.Btn8, 3, 1);
            this.TLPanelBtnSpace.Controls.Add(this.Btn7, 2, 1);
            this.TLPanelBtnSpace.Controls.Add(this.Btn5, 0, 1);
            this.TLPanelBtnSpace.Controls.Add(this.Btn4, 3, 0);
            this.TLPanelBtnSpace.Controls.Add(this.Btn3, 2, 0);
            this.TLPanelBtnSpace.Controls.Add(this.Btn2, 1, 0);
            this.TLPanelBtnSpace.Controls.Add(this.Btn1, 0, 0);
            this.TLPanelBtnSpace.Controls.Add(this.Btn6, 1, 1);
            this.TLPanelBtnSpace.Location = new System.Drawing.Point(7, 411);
            this.TLPanelBtnSpace.Name = "TLPanelBtnSpace";
            this.TLPanelBtnSpace.RowCount = 5;
            this.TLPanelBtnSpace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelBtnSpace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelBtnSpace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelBtnSpace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelBtnSpace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPanelBtnSpace.Size = new System.Drawing.Size(724, 499);
            this.TLPanelBtnSpace.TabIndex = 6;
            this.TLPanelBtnSpace.Visible = false;
            // 
            // Btn12
            // 
            this.Btn12.Location = new System.Drawing.Point(546, 201);
            this.Btn12.Name = "Btn12";
            this.Btn12.Size = new System.Drawing.Size(175, 92);
            this.Btn12.TabIndex = 11;
            this.Btn12.Text = "button12";
            this.Btn12.UseVisualStyleBackColor = true;
            this.Btn12.Visible = false;
            this.Btn12.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn11
            // 
            this.Btn11.Location = new System.Drawing.Point(365, 201);
            this.Btn11.Name = "Btn11";
            this.Btn11.Size = new System.Drawing.Size(175, 92);
            this.Btn11.TabIndex = 10;
            this.Btn11.Text = "button11";
            this.Btn11.UseVisualStyleBackColor = true;
            this.Btn11.Visible = false;
            this.Btn11.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn10
            // 
            this.Btn10.Location = new System.Drawing.Point(184, 201);
            this.Btn10.Name = "Btn10";
            this.Btn10.Size = new System.Drawing.Size(175, 92);
            this.Btn10.TabIndex = 9;
            this.Btn10.Text = "button10";
            this.Btn10.UseVisualStyleBackColor = true;
            this.Btn10.Visible = false;
            this.Btn10.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn9
            // 
            this.Btn9.Location = new System.Drawing.Point(3, 201);
            this.Btn9.Name = "Btn9";
            this.Btn9.Size = new System.Drawing.Size(175, 92);
            this.Btn9.TabIndex = 8;
            this.Btn9.Text = "button9";
            this.Btn9.UseVisualStyleBackColor = true;
            this.Btn9.Visible = false;
            this.Btn9.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn8
            // 
            this.Btn8.Location = new System.Drawing.Point(546, 102);
            this.Btn8.Name = "Btn8";
            this.Btn8.Size = new System.Drawing.Size(175, 92);
            this.Btn8.TabIndex = 7;
            this.Btn8.Text = "button8";
            this.Btn8.UseVisualStyleBackColor = true;
            this.Btn8.Visible = false;
            this.Btn8.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn7
            // 
            this.Btn7.Location = new System.Drawing.Point(365, 102);
            this.Btn7.Name = "Btn7";
            this.Btn7.Size = new System.Drawing.Size(175, 92);
            this.Btn7.TabIndex = 6;
            this.Btn7.Text = "button7";
            this.Btn7.UseVisualStyleBackColor = true;
            this.Btn7.Visible = false;
            this.Btn7.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn5
            // 
            this.Btn5.Location = new System.Drawing.Point(3, 102);
            this.Btn5.Name = "Btn5";
            this.Btn5.Size = new System.Drawing.Size(175, 92);
            this.Btn5.TabIndex = 4;
            this.Btn5.Text = "button5";
            this.Btn5.UseVisualStyleBackColor = true;
            this.Btn5.Visible = false;
            this.Btn5.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn4
            // 
            this.Btn4.Location = new System.Drawing.Point(546, 3);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(175, 92);
            this.Btn4.TabIndex = 3;
            this.Btn4.Text = "button4";
            this.Btn4.UseVisualStyleBackColor = true;
            this.Btn4.Visible = false;
            this.Btn4.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn3
            // 
            this.Btn3.Location = new System.Drawing.Point(365, 3);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(175, 92);
            this.Btn3.TabIndex = 2;
            this.Btn3.Text = "button3";
            this.Btn3.UseVisualStyleBackColor = true;
            this.Btn3.Visible = false;
            this.Btn3.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn2
            // 
            this.Btn2.Location = new System.Drawing.Point(184, 3);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(175, 92);
            this.Btn2.TabIndex = 1;
            this.Btn2.Text = "button2";
            this.Btn2.UseVisualStyleBackColor = true;
            this.Btn2.Visible = false;
            this.Btn2.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn1
            // 
            this.Btn1.Location = new System.Drawing.Point(3, 3);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(175, 92);
            this.Btn1.TabIndex = 0;
            this.Btn1.Text = "button1";
            this.Btn1.UseVisualStyleBackColor = true;
            this.Btn1.Visible = false;
            this.Btn1.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn6
            // 
            this.Btn6.Location = new System.Drawing.Point(184, 102);
            this.Btn6.Name = "Btn6";
            this.Btn6.Size = new System.Drawing.Size(175, 92);
            this.Btn6.TabIndex = 5;
            this.Btn6.Text = "button6";
            this.Btn6.UseVisualStyleBackColor = true;
            this.Btn6.Visible = false;
            this.Btn6.Click += new System.EventHandler(this.Btn_Click);
            // 
            // TPSpending
            // 
            this.TPSpending.Location = new System.Drawing.Point(4, 25);
            this.TPSpending.Name = "TPSpending";
            this.TPSpending.Padding = new System.Windows.Forms.Padding(3);
            this.TPSpending.Size = new System.Drawing.Size(737, 916);
            this.TPSpending.TabIndex = 1;
            this.TPSpending.Text = "支出";
            this.TPSpending.UseVisualStyleBackColor = true;
            // 
            // panelNewData
            // 
            this.panelNewData.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNewData.Location = new System.Drawing.Point(0, 0);
            this.panelNewData.Name = "panelNewData";
            this.panelNewData.Size = new System.Drawing.Size(772, 145);
            this.panelNewData.TabIndex = 10;
            // 
            // NewDataCreater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 973);
            this.Controls.Add(this.TCNewDataCreater);
            this.Controls.Add(this.panelNewData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewDataCreater";
            this.Text = "収入作成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewDataCreater_FormClosing);
            this.Load += new System.EventHandler(this.NewDataCreater_Load);
            this.TCNewDataCreater.ResumeLayout(false);
            this.TPIncome.ResumeLayout(false);
            this.TLPanelContent.ResumeLayout(false);
            this.TLPanelContent.PerformLayout();
            this.FLPanelSetDate.ResumeLayout(false);
            this.TLPanelSave.ResumeLayout(false);
            this.TLPanelInfo.ResumeLayout(false);
            this.TLPanelInfo.PerformLayout();
            this.TLPanelBtnSpace.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TCNewDataCreater;
        private System.Windows.Forms.TabPage TPIncome;
        private System.Windows.Forms.TabPage TPSpending;
        private System.Windows.Forms.TableLayoutPanel TLPanelInfo;
        private System.Windows.Forms.Label TxtDate;
        private System.Windows.Forms.TextBox TbDate;
        private System.Windows.Forms.Label TxtContent;
        private System.Windows.Forms.TextBox TbContent;
        private System.Windows.Forms.Label TxtMoney;
        private System.Windows.Forms.TextBox TbMoney;
        private System.Windows.Forms.Label TxtClassification;
        private System.Windows.Forms.TextBox TbClassification;
        private System.Windows.Forms.Label TxtAssets;
        private System.Windows.Forms.TextBox TbAssets;
        private System.Windows.Forms.TableLayoutPanel TLPanelSave;
        private System.Windows.Forms.Button BtnContinue;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.MonthCalendar McSelect;
        private System.Windows.Forms.FlowLayoutPanel FLPanelSetDate;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.TableLayoutPanel TLPanelContent;
        private System.Windows.Forms.Label ContentTxt;
        private System.Windows.Forms.TableLayoutPanel TLPanelBtnSpace;
        private System.Windows.Forms.Button Btn12;
        private System.Windows.Forms.Button Btn11;
        private System.Windows.Forms.Button Btn10;
        private System.Windows.Forms.Button Btn9;
        private System.Windows.Forms.Button Btn8;
        private System.Windows.Forms.Button Btn7;
        private System.Windows.Forms.Button Btn6;
        private System.Windows.Forms.Button Btn5;
        private System.Windows.Forms.Button Btn4;
        private System.Windows.Forms.Button Btn3;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button Btn1;
        private System.Windows.Forms.Panel panelNewData;
    }
}