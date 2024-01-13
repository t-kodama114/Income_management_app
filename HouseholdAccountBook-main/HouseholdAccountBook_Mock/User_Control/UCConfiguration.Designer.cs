namespace HouseholdAccountBook_Mock.User_Control
{
    partial class UCConfiguration
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
            this.panelConfiguration = new System.Windows.Forms.Panel();
            this.txtConfiguration = new System.Windows.Forms.Label();
            this.btnPassword = new System.Windows.Forms.Button();
            this.btnStyle = new System.Windows.Forms.Button();
            this.btnNotification = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.Label();
            this.txtStyle = new System.Windows.Forms.Label();
            this.txtNotification = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelConfiguration
            // 
            this.panelConfiguration.Controls.Add(this.txtConfiguration);
            this.panelConfiguration.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfiguration.Location = new System.Drawing.Point(0, 0);
            this.panelConfiguration.Name = "panelConfiguration";
            this.panelConfiguration.Size = new System.Drawing.Size(750, 79);
            this.panelConfiguration.TabIndex = 0;
            // 
            // txtConfiguration
            // 
            this.txtConfiguration.AutoSize = true;
            this.txtConfiguration.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtConfiguration.Location = new System.Drawing.Point(35, 19);
            this.txtConfiguration.Name = "txtConfiguration";
            this.txtConfiguration.Size = new System.Drawing.Size(93, 38);
            this.txtConfiguration.TabIndex = 1;
            this.txtConfiguration.Text = "設定";
            // 
            // btnPassword
            // 
            this.btnPassword.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPassword.Location = new System.Drawing.Point(199, 120);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(150, 150);
            this.btnPassword.TabIndex = 1;
            this.btnPassword.Text = "パスワード";
            this.btnPassword.UseVisualStyleBackColor = true;
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
            // 
            // btnStyle
            // 
            this.btnStyle.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStyle.Location = new System.Drawing.Point(199, 276);
            this.btnStyle.Name = "btnStyle";
            this.btnStyle.Size = new System.Drawing.Size(150, 150);
            this.btnStyle.TabIndex = 2;
            this.btnStyle.Text = "スタイル";
            this.btnStyle.UseVisualStyleBackColor = true;
            this.btnStyle.Click += new System.EventHandler(this.btnStyle_Click);
            // 
            // btnNotification
            // 
            this.btnNotification.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNotification.Location = new System.Drawing.Point(199, 432);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(150, 150);
            this.btnNotification.TabIndex = 3;
            this.btnNotification.Text = "通知";
            this.btnNotification.UseVisualStyleBackColor = true;
            this.btnNotification.Visible = false;
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.Location = new System.Drawing.Point(199, 588);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 150);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSize = true;
            this.txtPassword.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPassword.Location = new System.Drawing.Point(396, 171);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(173, 40);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "パスワード";
            // 
            // txtStyle
            // 
            this.txtStyle.AutoSize = true;
            this.txtStyle.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStyle.Location = new System.Drawing.Point(396, 328);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(138, 40);
            this.txtStyle.TabIndex = 6;
            this.txtStyle.Text = "スタイル";
            // 
            // txtNotification
            // 
            this.txtNotification.AutoSize = true;
            this.txtNotification.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtNotification.Location = new System.Drawing.Point(396, 484);
            this.txtNotification.Name = "txtNotification";
            this.txtNotification.Size = new System.Drawing.Size(97, 40);
            this.txtNotification.TabIndex = 7;
            this.txtNotification.Text = "通知";
            this.txtNotification.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(396, 656);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 40);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // UCConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNotification);
            this.Controls.Add(this.txtStyle);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnNotification);
            this.Controls.Add(this.btnStyle);
            this.Controls.Add(this.btnPassword);
            this.Controls.Add(this.panelConfiguration);
            this.Name = "UCConfiguration";
            this.Size = new System.Drawing.Size(750, 780);
            this.Load += new System.EventHandler(this.UCConfiguration_Load);
            this.panelConfiguration.ResumeLayout(false);
            this.panelConfiguration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelConfiguration;
        private System.Windows.Forms.Label txtConfiguration;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Button btnStyle;
        private System.Windows.Forms.Button btnNotification;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.Label txtStyle;
        private System.Windows.Forms.Label txtNotification;
        private System.Windows.Forms.Label label4;
    }
}
