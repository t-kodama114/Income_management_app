using System;
using System.Configuration;
using System.Windows.Forms;
using HouseholdAccountBook_Mock.MBox;
using HouseholdAccountBook_Mock.DB;
using HouseholdAccountBook_Mock.Class;

namespace HouseholdAccountBook_Mock
{
    public partial class Login : Form
    {
        #region プロパティ

        public AppController controller { get; set; }

        #endregion

        #region コンストラクタ

        public Login(AppController appController)
        {
            InitializeComponent();
            controller = appController;
        }

        #endregion

        #region ロードイベント

        private void Login_Load(object sender, EventArgs e)
        {
            AppConst.FormStyle.SetColor();
            panelLogin.BackColor = AppConst.FormStyle.FormColor;
            TbPassword.UseSystemPasswordChar = true;
            Text = "ログイン";
        }

        #endregion

        #region クリックイベント

        private void BtnOK_Click(object sender, EventArgs e)
        {
            LoginYesOrNo();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoginYesOrNo();
            }
        }

        #endregion

        #region メソッド

        private void LoginYesOrNo()
        {
            //入力チェック
            if (string.IsNullOrEmpty(TbUserName.Text))
            {
                OriginMBox.MBoxErrorOK(AppConst.USER_INPUT_ERROR);
                return;
            }
            if (string.IsNullOrEmpty(TbPassword.Text))
            {
                OriginMBox.MBoxErrorOK(AppConst.PASSWORD_INPUT_ERROR);
                return;
            }

            // ログイン認証チェック
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
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

        #endregion
    }
}
