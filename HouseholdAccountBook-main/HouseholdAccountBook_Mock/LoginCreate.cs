using System;
using System.Configuration;
using System.Windows.Forms;
using HouseholdAccountBook_Mock.Class;
using HouseholdAccountBook_Mock.DB;

namespace HouseholdAccountBook_Mock
{
    public partial class LoginCreate : Form
    {
        #region プロパティ

        public AppController controller { get; set; }

        #endregion

        #region コンストラクタ

        public LoginCreate(AppController appController)
        {
            InitializeComponent();
            controller = appController;
        }

        #endregion

        #region ロードイベント

        private void LoginCreate_Load(object sender, EventArgs e)
        {
            TbPassword.UseSystemPasswordChar = true;
            Name = "アカウント作成";
        }

        #endregion

        #region クリックイベント

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // ユーザー情報作成
            (string hashed, string salt) = PasswordManager.HashPassword(TbPassword.Text);
            User initUser = User.InsertUser(TbUserName.Text, TbUserNameKana.Text, hashed, CbAutoLogin.Checked, salt);
            if (initUser == null) return;
            // 設定データの初期データ作成
            // デフォルトの色は白(インデックスは9)
            DB.ConfigurationSetting setting = DB.ConfigurationSetting.InsertConfigSetting(initUser.Id, (int)AppConst.FormStyle.StyleColor.white);
            if (setting == null) return;

            if (CbAutoLogin.Checked)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["UserId"].Value = initUser.Id.ToString();
                config.AppSettings.Settings["HashPassword"].Value = initUser.Password;
                config.Save();
            }
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["UserId"].Value = initUser.Id.ToString();
                config.Save();
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region イベント

        #endregion
    }
}
