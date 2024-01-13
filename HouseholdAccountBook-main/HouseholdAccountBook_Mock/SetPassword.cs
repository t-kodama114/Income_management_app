using System;
using System.Configuration;
using System.Windows.Forms;
using HouseholdAccountBook_Mock.MBox;
using HouseholdAccountBook_Mock.DB;
using HouseholdAccountBook_Mock.Class;

namespace HouseholdAccountBook_Mock
{
    public partial class SetPassword : Form
    {
        #region プロパティ

        public AppController controller { get; set; }

        #endregion

        #region コンストラクタ

        public SetPassword(AppController appController = null)
        {
            InitializeComponent();
            controller = appController;
        }

        #endregion

        #region ロードイベント

        private void SetPassword_Load(object sender, EventArgs e)
        {
            AppConst.FormStyle.SetColor();
            panelPassword.BackColor = AppConst.FormStyle.FormColor;
            TbPassword.UseSystemPasswordChar = true;
            CbVisiblePassword.Checked = false;

            if (controller != null) { Text = "ログイン"; }
        }

        #endregion

        #region クリックイベント

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbPassword.Text))
            {
                OriginMBox.MBoxErrorOK(AppConst.PASSWORD_INPUT_ERROR);
                return;
            }

            // コントロール有り無しで動作を変更
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
            if (controller == null)
            {
                // パスワード変更前に以前のユーザー情報取得
                User beforeUserInfo = User.SelectUserFromId(userId);
                // パスワード変更処理のため、パスワード再作成
                (string hashed, string salt) = PasswordManager.HashPassword(TbPassword.Text);

                // 以前のパスワードと更新パスワードが同一かどうか確認
                bool isSame = hashed != beforeUserInfo.Password;
                if (!isSame) OriginMBox.MBoxErrorOK(AppConst.PASSWORD_BEFORE_ERROR);

                User updateUser = User.UpdatePasswordAndSalt(userId, hashed, salt);
                if (updateUser == null) return;

                // 更新パスワードがあっているかどうか
                bool isSuccess = PasswordManager.VerifyPassword(updateUser.Password, TbPassword.Text, updateUser.Salt);
                if (isSuccess && !string.IsNullOrEmpty(config.AppSettings.Settings["HashPassword"].Value)) 
                {
                    config.AppSettings.Settings["HashPassword"].Value = updateUser.Password;
                    config.Save();
                    OriginMBox.MBoxInfoOK(AppConst.PASSWORD_UPDATE_SUCCESS);
                    this.DialogResult = DialogResult.OK;
                }
                else if (isSuccess)
                {
                    OriginMBox.MBoxInfoOK(AppConst.PASSWORD_UPDATE_SUCCESS);
                    this.DialogResult = DialogResult.OK;
                }
                else { this.DialogResult = DialogResult.Cancel;  }
                
                Close();
            }
            else
            {
                // ログイン認証チェック
                User user = User.SelectUserFromId(userId);
                bool isSuccess = PasswordManager.VerifyPassword(user.Password, TbPassword.Text, user.Salt);

                //　ログイン合否によって処理分岐
                if (isSuccess)
                {
                    OriginMBox.MBoxInfoOK(AppConst.LOGIN_SUCCESS);
                    controller.User = user;
                    Hide();
                    MainHouseholdABookForm bookForm = new MainHouseholdABookForm(controller);
                    if (bookForm.ShowDialog() != DialogResult.OK)
                    {
                        Close();
                    }
                }
                else { OriginMBox.MBoxErrorOK(AppConst.LOGIN_ERROR); }
            }
        }

        #endregion

        #region イベント

        private void CbVisiblePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CbVisiblePassword.Checked)
            {
                TbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                TbPassword.UseSystemPasswordChar = true;
            }
        }

        private void TbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);

                // ログイン認証チェック
                User user = User.SelectUserFromId(userId);
                bool isSuccess = PasswordManager.VerifyPassword(user.Password, TbPassword.Text, user.Salt);

                //　ログイン合否によって処理分岐
                if (isSuccess)
                {
                    OriginMBox.MBoxInfoOK(AppConst.LOGIN_SUCCESS);
                    controller.User = user;
                    Hide();
                    MainHouseholdABookForm bookForm = new MainHouseholdABookForm(controller);
                    if (bookForm.ShowDialog() != DialogResult.OK)
                    {
                        Close();
                    }
                }
                else { OriginMBox.MBoxErrorOK(AppConst.LOGIN_ERROR); }
            }
        }

        #endregion
    }
}
