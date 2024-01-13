using System;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;
using HouseholdAccountBook_Mock.MBox;

namespace HouseholdAccountBook_Mock
{
    /// <summary>
    /// メイン画面
    /// </summary>
    public partial class MainHouseholdABookForm : Form
    {
        #region private変数

        /// <summary>
        /// 共通表示フォーム
        /// </summary> 
        private DisplayForm displayForm;

        #endregion

        #region プロパティ

        public AppController AppCon { get; set; }

        #endregion

        #region コンストラクタ

        public MainHouseholdABookForm(AppController appController)
        {
            InitializeComponent();

            AppCon = appController;
            BackgroundImage = new Bitmap(ConfigurationManager.AppSettings["FileName"].ToString());
            panelMain.BackColor = AppConst.FormStyle.FormColor;
            //資産運用の処理はMBOの後
            BtnAssets.Enabled = false;
        }

        #endregion

        #region クリックイベント

        private void BtnBreakdown_Click(object sender, EventArgs e)
        {
            displayForm = new DisplayForm
            {
                NowControl = AppCon.Execute(AppController.DisplayType.BREAKDOWN),
                FormName = BtnBreakdown.Text
            };
            DialogResult result = displayForm.ShowDialog();
        }

        private void BtnStatistics_Click(object sender, EventArgs e)
        {
            displayForm = new DisplayForm
            {
                NowControl = AppCon.Execute(AppController.DisplayType.STATISTICS),
                FormName = BtnStatistics.Text
            };
            DialogResult result = displayForm.ShowDialog();
        }

        private void BtnAssets_Click(object sender, EventArgs e)
        {
            displayForm = new DisplayForm
            {
                NowControl = AppCon.Execute(AppController.DisplayType.ASSETS),
                FormName = BtnAssets.Text
            };
            DialogResult result = displayForm.ShowDialog();
        }

        private void BtnConfiguration_Click(object sender, EventArgs e)
        {
            displayForm = new DisplayForm
            {
                NowControl = AppCon.Execute(AppController.DisplayType.CONFIGURATION),
                FormName = BtnConfiguration.Text
            };
            DialogResult result = displayForm.ShowDialog();
        }

        #endregion

        private void MainHouseholdABookForm_Activated(object sender, EventArgs e)
        {
            panelMain.BackColor = AppConst.FormStyle.FormColor;
        }
    }
}
