using System;
using System.Drawing;
using System.Windows.Forms;
using HouseholdAccountBook_Mock.DB;
using System.Configuration;

namespace HouseholdAccountBook_Mock.User_Control
{
    public partial class UCConfiguration : UserControl
    {
        #region プロパティ

        /// <summary>
        /// 設定情報
        /// </summary>
        private ConfigurationSetting Setting { get; set; }

        #endregion

        #region コンストラクタ
        public UCConfiguration()
        {
            InitializeComponent();
        }
        #endregion

        #region ロードイベント

        private void UCConfiguration_Load(object sender, EventArgs e)
        {
            panelConfiguration.BackColor = AppConst.FormStyle.FormColor;
            //設定データを取得する
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
            ConfigurationSetting _setting = ConfigurationSetting.SelectSetting(userId);
            Setting = _setting;
        }

        #endregion

        #region クリックイベント

        private void btnPassword_Click(object sender, EventArgs e)
        {
            // パスワード変更
            SetPassword setPassword = new SetPassword
            {
                Text = btnPassword.Text
            };
            setPassword.ShowDialog();
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            // スタイル変更
            SetStyle setStyle = new SetStyle(Setting)
            {
                Text = btnStyle.Text
            };
            setStyle.ShowDialog();
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            ToastManager toastManager = new ToastManager
            {
                Text = btnNotification.Text
            };
            toastManager.ShowDialog();
        }

        #endregion

        public void ChangeColor()
        {
            panelConfiguration.BackColor = AppConst.FormStyle.FormColor;
        }
    }
}
