namespace HouseholdAccountBook_Mock
{
    partial class MainHouseholdABookForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtTitle = new System.Windows.Forms.Label();
            this.BtnBreakdown = new System.Windows.Forms.Button();
            this.TxtBreakdown = new System.Windows.Forms.Label();
            this.TxtStatistics = new System.Windows.Forms.Label();
            this.BtnStatistics = new System.Windows.Forms.Button();
            this.TxtAssets = new System.Windows.Forms.Label();
            this.BtnAssets = new System.Windows.Forms.Button();
            this.TxtConfiguration = new System.Windows.Forms.Label();
            this.BtnConfiguration = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // TxtTitle
            // 
            this.TxtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTitle.AutoSize = true;
            this.TxtTitle.Font = new System.Drawing.Font("MS UI Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtTitle.Location = new System.Drawing.Point(220, 37);
            this.TxtTitle.Name = "TxtTitle";
            this.TxtTitle.Size = new System.Drawing.Size(164, 48);
            this.TxtTitle.TabIndex = 0;
            this.TxtTitle.Text = "家計簿";
            // 
            // BtnBreakdown
            // 
            this.BtnBreakdown.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBreakdown.Location = new System.Drawing.Point(231, 155);
            this.BtnBreakdown.Name = "BtnBreakdown";
            this.BtnBreakdown.Size = new System.Drawing.Size(253, 57);
            this.BtnBreakdown.TabIndex = 1;
            this.BtnBreakdown.Text = "家計簿入力";
            this.BtnBreakdown.UseVisualStyleBackColor = true;
            this.BtnBreakdown.Click += new System.EventHandler(this.BtnBreakdown_Click);
            // 
            // TxtBreakdown
            // 
            this.TxtBreakdown.AutoSize = true;
            this.TxtBreakdown.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtBreakdown.Location = new System.Drawing.Point(97, 161);
            this.TxtBreakdown.Name = "TxtBreakdown";
            this.TxtBreakdown.Size = new System.Drawing.Size(93, 38);
            this.TxtBreakdown.TabIndex = 2;
            this.TxtBreakdown.Text = "内訳";
            // 
            // TxtStatistics
            // 
            this.TxtStatistics.AutoSize = true;
            this.TxtStatistics.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtStatistics.Location = new System.Drawing.Point(60, 282);
            this.TxtStatistics.Name = "TxtStatistics";
            this.TxtStatistics.Size = new System.Drawing.Size(130, 38);
            this.TxtStatistics.TabIndex = 4;
            this.TxtStatistics.Text = "チャート";
            // 
            // BtnStatistics
            // 
            this.BtnStatistics.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnStatistics.Location = new System.Drawing.Point(231, 276);
            this.BtnStatistics.Name = "BtnStatistics";
            this.BtnStatistics.Size = new System.Drawing.Size(253, 57);
            this.BtnStatistics.TabIndex = 3;
            this.BtnStatistics.Text = "統計確認";
            this.BtnStatistics.UseVisualStyleBackColor = true;
            this.BtnStatistics.Click += new System.EventHandler(this.BtnStatistics_Click);
            // 
            // TxtAssets
            // 
            this.TxtAssets.AutoSize = true;
            this.TxtAssets.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtAssets.Location = new System.Drawing.Point(97, 536);
            this.TxtAssets.Name = "TxtAssets";
            this.TxtAssets.Size = new System.Drawing.Size(93, 38);
            this.TxtAssets.TabIndex = 6;
            this.TxtAssets.Text = "資産";
            this.TxtAssets.Visible = false;
            // 
            // BtnAssets
            // 
            this.BtnAssets.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnAssets.Location = new System.Drawing.Point(231, 530);
            this.BtnAssets.Name = "BtnAssets";
            this.BtnAssets.Size = new System.Drawing.Size(253, 57);
            this.BtnAssets.TabIndex = 5;
            this.BtnAssets.Text = "資産確認";
            this.BtnAssets.UseVisualStyleBackColor = true;
            this.BtnAssets.Visible = false;
            this.BtnAssets.Click += new System.EventHandler(this.BtnAssets_Click);
            // 
            // TxtConfiguration
            // 
            this.TxtConfiguration.AutoSize = true;
            this.TxtConfiguration.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtConfiguration.Location = new System.Drawing.Point(97, 406);
            this.TxtConfiguration.Name = "TxtConfiguration";
            this.TxtConfiguration.Size = new System.Drawing.Size(93, 38);
            this.TxtConfiguration.TabIndex = 8;
            this.TxtConfiguration.Text = "設定";
            // 
            // BtnConfiguration
            // 
            this.BtnConfiguration.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnConfiguration.Location = new System.Drawing.Point(231, 400);
            this.BtnConfiguration.Name = "BtnConfiguration";
            this.BtnConfiguration.Size = new System.Drawing.Size(253, 57);
            this.BtnConfiguration.TabIndex = 7;
            this.BtnConfiguration.Text = "設定確認";
            this.BtnConfiguration.UseVisualStyleBackColor = true;
            this.BtnConfiguration.Click += new System.EventHandler(this.BtnConfiguration_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(0, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(602, 118);
            this.panelMain.TabIndex = 9;
            // 
            // MainHouseholdABookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(602, 733);
            this.Controls.Add(this.TxtConfiguration);
            this.Controls.Add(this.BtnConfiguration);
            this.Controls.Add(this.TxtAssets);
            this.Controls.Add(this.BtnAssets);
            this.Controls.Add(this.TxtStatistics);
            this.Controls.Add(this.BtnStatistics);
            this.Controls.Add(this.TxtBreakdown);
            this.Controls.Add(this.BtnBreakdown);
            this.Controls.Add(this.TxtTitle);
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(620, 780);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 700);
            this.Name = "MainHouseholdABookForm";
            this.Text = "家計簿アプリ";
            this.Activated += new System.EventHandler(this.MainHouseholdABookForm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TxtTitle;
        private System.Windows.Forms.Button BtnBreakdown;
        private System.Windows.Forms.Label TxtBreakdown;
        private System.Windows.Forms.Label TxtStatistics;
        private System.Windows.Forms.Button BtnStatistics;
        private System.Windows.Forms.Label TxtAssets;
        private System.Windows.Forms.Button BtnAssets;
        private System.Windows.Forms.Label TxtConfiguration;
        private System.Windows.Forms.Button BtnConfiguration;
        private System.Windows.Forms.Panel panelMain;
    }
}

