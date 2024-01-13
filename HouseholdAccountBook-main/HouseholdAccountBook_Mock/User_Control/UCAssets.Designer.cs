namespace HouseholdAccountBook_Mock.User_Control
{
    partial class UCAssets
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
            this.txtAssets = new System.Windows.Forms.Label();
            this.panelAssets = new System.Windows.Forms.Panel();
            this.panelAssets.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAssets
            // 
            this.txtAssets.AutoSize = true;
            this.txtAssets.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAssets.Location = new System.Drawing.Point(30, 22);
            this.txtAssets.Name = "txtAssets";
            this.txtAssets.Size = new System.Drawing.Size(93, 38);
            this.txtAssets.TabIndex = 0;
            this.txtAssets.Text = "資産";
            // 
            // panelAssets
            // 
            this.panelAssets.Controls.Add(this.txtAssets);
            this.panelAssets.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAssets.Location = new System.Drawing.Point(0, 0);
            this.panelAssets.Name = "panelAssets";
            this.panelAssets.Size = new System.Drawing.Size(820, 79);
            this.panelAssets.TabIndex = 1;
            // 
            // UCAssets
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panelAssets);
            this.MinimumSize = new System.Drawing.Size(820, 890);
            this.Name = "UCAssets";
            this.Size = new System.Drawing.Size(820, 890);
            this.Load += new System.EventHandler(this.UCAssets_Load);
            this.panelAssets.ResumeLayout(false);
            this.panelAssets.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtAssets;
        private System.Windows.Forms.Panel panelAssets;
    }
}
