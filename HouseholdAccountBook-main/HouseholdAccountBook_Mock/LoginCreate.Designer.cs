namespace HouseholdAccountBook_Mock
{
    partial class LoginCreate
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
            this.TxtLoginCreate = new System.Windows.Forms.Label();
            this.panelConfiguration = new System.Windows.Forms.Panel();
            this.TxtUserName = new System.Windows.Forms.Label();
            this.TxtUserNameKana = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.Label();
            this.TxtAutoLogin = new System.Windows.Forms.Label();
            this.TbUserName = new System.Windows.Forms.TextBox();
            this.CbAutoLogin = new System.Windows.Forms.CheckBox();
            this.TbUserNameKana = new System.Windows.Forms.TextBox();
            this.TbPassword = new System.Windows.Forms.TextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.panelConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtLoginCreate
            // 
            this.TxtLoginCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLoginCreate.AutoSize = true;
            this.TxtLoginCreate.Font = new System.Drawing.Font("MS UI Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtLoginCreate.Location = new System.Drawing.Point(178, 27);
            this.TxtLoginCreate.Name = "TxtLoginCreate";
            this.TxtLoginCreate.Size = new System.Drawing.Size(259, 48);
            this.TxtLoginCreate.TabIndex = 10;
            this.TxtLoginCreate.Text = "ログイン作成";
            // 
            // panelConfiguration
            // 
            this.panelConfiguration.Controls.Add(this.TxtLoginCreate);
            this.panelConfiguration.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfiguration.Location = new System.Drawing.Point(0, 0);
            this.panelConfiguration.Name = "panelConfiguration";
            this.panelConfiguration.Size = new System.Drawing.Size(602, 105);
            this.panelConfiguration.TabIndex = 11;
            // 
            // TxtUserName
            // 
            this.TxtUserName.AutoSize = true;
            this.TxtUserName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtUserName.Location = new System.Drawing.Point(56, 165);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(155, 30);
            this.TxtUserName.TabIndex = 12;
            this.TxtUserName.Text = "ユーザー名：";
            // 
            // TxtUserNameKana
            // 
            this.TxtUserNameKana.AutoSize = true;
            this.TxtUserNameKana.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtUserNameKana.Location = new System.Drawing.Point(11, 271);
            this.TxtUserNameKana.Name = "TxtUserNameKana";
            this.TxtUserNameKana.Size = new System.Drawing.Size(200, 30);
            this.TxtUserNameKana.TabIndex = 13;
            this.TxtUserNameKana.Text = "ユーザー名カナ：";
            // 
            // TxtPassword
            // 
            this.TxtPassword.AutoSize = true;
            this.TxtPassword.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtPassword.Location = new System.Drawing.Point(55, 372);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(145, 30);
            this.TxtPassword.TabIndex = 14;
            this.TxtPassword.Text = "パスワード：";
            // 
            // TxtAutoLogin
            // 
            this.TxtAutoLogin.AutoSize = true;
            this.TxtAutoLogin.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtAutoLogin.Location = new System.Drawing.Point(15, 463);
            this.TxtAutoLogin.Name = "TxtAutoLogin";
            this.TxtAutoLogin.Size = new System.Drawing.Size(185, 30);
            this.TxtAutoLogin.TabIndex = 15;
            this.TxtAutoLogin.Text = "オートログイン：";
            // 
            // TbUserName
            // 
            this.TbUserName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbUserName.Location = new System.Drawing.Point(206, 162);
            this.TbUserName.MaxLength = 16;
            this.TbUserName.Name = "TbUserName";
            this.TbUserName.Size = new System.Drawing.Size(278, 37);
            this.TbUserName.TabIndex = 16;
            // 
            // CbAutoLogin
            // 
            this.CbAutoLogin.AutoSize = true;
            this.CbAutoLogin.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CbAutoLogin.Location = new System.Drawing.Point(206, 463);
            this.CbAutoLogin.Name = "CbAutoLogin";
            this.CbAutoLogin.Size = new System.Drawing.Size(395, 34);
            this.CbAutoLogin.TabIndex = 17;
            this.CbAutoLogin.Text = "初回ログイン後にオートログイン";
            this.CbAutoLogin.UseVisualStyleBackColor = true;
            // 
            // TbUserNameKana
            // 
            this.TbUserNameKana.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbUserNameKana.Location = new System.Drawing.Point(206, 268);
            this.TbUserNameKana.MaxLength = 16;
            this.TbUserNameKana.Name = "TbUserNameKana";
            this.TbUserNameKana.Size = new System.Drawing.Size(278, 37);
            this.TbUserNameKana.TabIndex = 18;
            // 
            // TbPassword
            // 
            this.TbPassword.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbPassword.Location = new System.Drawing.Point(206, 365);
            this.TbPassword.MaxLength = 16;
            this.TbPassword.Name = "TbPassword";
            this.TbPassword.Size = new System.Drawing.Size(278, 37);
            this.TbPassword.TabIndex = 19;
            // 
            // BtnOK
            // 
            this.BtnOK.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnOK.Location = new System.Drawing.Point(123, 539);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(134, 48);
            this.BtnOK.TabIndex = 20;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnCancel.Location = new System.Drawing.Point(327, 539);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(134, 48);
            this.BtnCancel.TabIndex = 21;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LoginCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(602, 624);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TbPassword);
            this.Controls.Add(this.TbUserNameKana);
            this.Controls.Add(this.CbAutoLogin);
            this.Controls.Add(this.TbUserName);
            this.Controls.Add(this.TxtAutoLogin);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUserNameKana);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.panelConfiguration);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginCreate";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginCreate_Load);
            this.panelConfiguration.ResumeLayout(false);
            this.panelConfiguration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TxtLoginCreate;
        private System.Windows.Forms.Panel panelConfiguration;
        private System.Windows.Forms.Label TxtUserName;
        private System.Windows.Forms.Label TxtUserNameKana;
        private System.Windows.Forms.Label TxtPassword;
        private System.Windows.Forms.Label TxtAutoLogin;
        private System.Windows.Forms.TextBox TbUserName;
        private System.Windows.Forms.CheckBox CbAutoLogin;
        private System.Windows.Forms.TextBox TbUserNameKana;
        private System.Windows.Forms.TextBox TbPassword;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
    }
}