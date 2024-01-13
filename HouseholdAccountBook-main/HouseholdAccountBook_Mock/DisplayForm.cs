using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace HouseholdAccountBook_Mock
{
    /// <summary>
    /// 共通画面
    /// </summary>
    public partial class DisplayForm : Form
    {
        #region 定数

        /// <summary>
        /// 初期位置(X)
        /// </summary>
        const int CONTROL_X = 10;
        /// <summary>
        /// 初期位置(Y)
        /// </summary>
        const int CONTROL_Y = 10;

        /// <summary>
        /// 初期サイズ(家計簿入力画面幅)
        /// </summary>
        const int BREAKDOWN_WIDTH = 600;
        /// <summary>
        /// 初期サイズ(家計簿入力画面高さ)
        /// </summary>
        const int BREAKDOWN_HEIGHT = 690;

        /// <summary>
        /// 初期サイズ(統計確認画面幅)
        /// </summary>
        const int STATISTICS_WIDTH = 850;

        /// <summary>
        /// 初期サイズ(統計確認画面高さ)
        /// </summary>
        const int STATISTICS_HEIGHT = 940;

        #endregion

        #region プロパティ

        /// <summary>
        /// 表示中の画面オブジェクト
        /// </summary>
        public Control NowControl { get; set; }

        /// <summary>
        /// 表示画面名
        /// </summary>
        public string FormName { get; set; }

        #endregion

        #region コンストラクタ

        public DisplayForm()
        {
            InitializeComponent();
        }

        #endregion

        #region ロードイベント

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            BackgroundImage = new Bitmap(ConfigurationManager.AppSettings["FileName"].ToString());
            //表示コントロールの初期化
            NowControl.Enabled = true;
            NowControl.Visible = true;
            NowControl.Location = new Point(CONTROL_X, CONTROL_Y);
            NowControl.BackgroundImage = new Bitmap(ConfigurationManager.AppSettings["FileName"].ToString());
            //画面ごとに画面サイズ調整
            if (FormName == AppConst.BREAKDOWN_STR)
            {
                this.Size = new Size(BREAKDOWN_WIDTH, BREAKDOWN_HEIGHT);
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
            }
            else if(FormName == AppConst.STATISTICS_STR)
            {
                this.Size = new Size(STATISTICS_WIDTH, STATISTICS_HEIGHT);
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
            }
            else if(FormName == AppConst.ASSETS_STR)
            {
                this.Size = new Size(STATISTICS_WIDTH, STATISTICS_HEIGHT);
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
            }
            else if(FormName == AppConst.CONFIGURATION_STR)
            {
                this.Size = new Size(BREAKDOWN_WIDTH, BREAKDOWN_HEIGHT);
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
            }

            if (this.Controls.Find(NowControl.Name, true).Length != 1)
            {
                this.Controls.Add(NowControl);
            }
            //表示画面名表示
            this.Text = FormName;
        }

        #endregion

        #region クローズイベント

        private void DisplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //表示コントロールのリセット
            this.Controls.Remove(NowControl);
        }

        #endregion

        private void DisplayForm_Activated(object sender, EventArgs e)
        {
            if (FormName == AppConst.CONFIGURATION_STR)
            {
                HouseholdAccountBook_Mock.User_Control.UCConfiguration uC =
                (HouseholdAccountBook_Mock.User_Control.UCConfiguration)NowControl;

                uC.ChangeColor();
            }
        }
    }
}
