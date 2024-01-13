using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;
using HouseholdAccountBook_Mock.MBox;
using HouseholdAccountBook_Mock.Class;
using HouseholdAccountBook_Mock.DB;

namespace HouseholdAccountBook_Mock
{
    public partial class NewDataCreater : Form
    {
        #region private変数

        /// <summary>
        /// ボタンリスト
        /// </summary>
        private List<Button> btnList;

        /// <summary>
        /// 収入か支出か判定フラグ
        /// </summary>
        private bool isIncomeOrSpending = true;

        /// <summary>
        /// 選択した日付
        /// </summary>
        private DateTime selectDate;

        #endregion

        #region プロパティ

        /// <summary>
        /// ダイアログボックスの結果
        /// </summary>
        public DialogResult dialogResult { get; set; }

        #endregion

        #region Enum

        /// <summary>
        /// 表示ボタン種類
        /// </summary>
        public enum DisplayBtnType
        {
            BtnDate, //日時
            Assets, //資産
            IncomeClassification, //収入時の分類
            SpendingClassification, //支出時の分類
            Money, //金額
            Content //内容
        };

        #endregion

        #region コンストラクタ

        public NewDataCreater()
        {
            InitializeComponent();

            BackgroundImage = new Bitmap(ConfigurationManager.AppSettings["FileName"].ToString());
        }

        #endregion

        #region ロードイベント

        private void NewDataCreater_Load(object sender, EventArgs e)
        {
            panelNewData.BackColor = AppConst.FormStyle.FormColor;
            //現在日時表示
            string[] timeList = { DateTime.Now.Year.ToString("0000"), DateTime.Now.Month.ToString("00"),
                DateTime.Now.Day.ToString("00"), DateTime.Now.Hour.ToString("00"), DateTime.Now.Minute.ToString("00") };
            TbDate.Text = string.Format(AppConst.TIME_STR, timeList);
            //初期フォーカスコントロール設定
            ActiveControl = TbAssets;
            TLPanelBtnSpace.Visible = true;
            //初期フォント設定
            ContentTxt.Text = TxtAssets.Text;
            //ボタン登録
            btnList = new List<Button>();
            
            for(int i = 1; i <= 12; i++)
            {
                Control[] con = Controls.Find("Btn" + i.ToString(), true);
                if(con.Length == 1)
                {
                    btnList.Add((Button)con[0]);
                }
            }

            //初期ボタン設定
            ChangeLayout(DisplayBtnType.Assets);
            //支出と収入フラグ初期化
            isIncomeOrSpending = false;
            McSelect.SelectionRange = new SelectionRange(DateTime.Now, DateTime.Now);
        }

        #endregion

        #region クリックイベント

        private void TbAssets_Click(object sender, EventArgs e)
        {
            //レイアウト初期化
            InitVisibleLayout();
            ContentTxt.Text = TxtAssets.Text;

            //レイアウト変更
            ChangeLayout(DisplayBtnType.Assets);
        }

        private void TbClassification_Click(object sender, EventArgs e)
        {
            //レイアウト初期化
            InitVisibleLayout();
            ContentTxt.Text = TxtClassification.Text;

            //レイアウト変更
            if (!isIncomeOrSpending)
            {
                ChangeLayout(DisplayBtnType.IncomeClassification);
            }
            else
            {
                ChangeLayout(DisplayBtnType.SpendingClassification);
            }
        }

        private void TbDate_Click(object sender, EventArgs e)
        {
            //レイアウト初期化
            InitVisibleLayout();
            ContentTxt.Text = TxtDate.Text;

            //レイアウト変更
            ChangeLayout(DisplayBtnType.BtnDate);
        }

        private void TbMoney_Click(object sender, EventArgs e)
        {
            //レイアウト初期化
            InitVisibleLayout();

            //レイアウト変更
            ChangeLayout(DisplayBtnType.Money);
        }

        private void TbContent_Click(object sender, EventArgs e)
        {
            //レイアウト初期化
            InitVisibleLayout();

            //レイアウト変更
            ChangeLayout(DisplayBtnType.Content);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //日付変更
            string dateStr = selectDate.ToShortDateString();
            string timeStr = " " + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00");

            TbDate.Text = dateStr + timeStr;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //ボタンオブジェクト取得
            Button myBtn = (Button)sender;

            //資産のとき
            if(ContentTxt.Text == TxtAssets.Text)
            {
                TbAssets.Text = "";
                TbAssets.Text = myBtn.Text;
            }
            //収入の分類
            else if(ContentTxt.Text == TxtClassification.Text && !isIncomeOrSpending)
            {
                TbClassification.Text = "";
                TbClassification.Text = myBtn.Text;
            }
            //支出の分類
            else if(ContentTxt.Text == TxtClassification.Text && isIncomeOrSpending)
            {
                TbClassification.Text = "";
                TbClassification.Text = myBtn.Text;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
            if (!string.IsNullOrEmpty(TbAssets.Text) && !string.IsNullOrEmpty(TbClassification.Text)
                && !string.IsNullOrEmpty(TbDate.Text) && !string.IsNullOrEmpty(TbMoney.Text) && !string.IsNullOrEmpty(TbContent.Text))
            {
                TbMoney.Text = TbMoney.Text.Replace(",", "").Remove(0, 1);
                if (int.Parse(TbMoney.Text) > 0 && !string.IsNullOrWhiteSpace(TbContent.Text))
                {
                    //家計簿ベースデータ新規登録
                    if (HouseholdABookBase.InsertHouseholdABookBase(isIncomeOrSpending ? 1 : 0,
                        DateTime.Parse(TbDate.Text), TbAssets.Text, TbClassification.Text,
                        int.Parse(TbMoney.Text), TbContent.Text, userId))
                    {
                        OriginMBox.MBoxInfoOK("新規データ登録完了");
                        //閉じる
                        Close();
                        dialogResult = DialogResult.OK;
                    }
                    else
                    {
                        //非表示してから再表示
                        Hide();
                        TbAssets.Text = "";
                        TbClassification.Text = "";
                        TbMoney.Text = "";
                        string[] timeList = { DateTime.Now.Year.ToString("0000"), DateTime.Now.Month.ToString("00"),
                            DateTime.Now.Day.ToString("00"), DateTime.Now.Hour.ToString("00"), DateTime.Now.Minute.ToString("00") };
                        TbDate.Text = string.Format(AppConst.TIME_STR, timeList);
                        TbContent.Text = ""; 
                        Show();
                    }
                }
            }
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
            if (!string.IsNullOrEmpty(TbAssets.Text) && !string.IsNullOrEmpty(TbClassification.Text)
                && !string.IsNullOrEmpty(TbDate.Text) && !string.IsNullOrEmpty(TbMoney.Text) && !string.IsNullOrEmpty(TbContent.Text))
            {
                TbMoney.Text = TbMoney.Text.Replace(",", "").Remove(0, 1);
                if (int.Parse(TbMoney.Text) > 0 && !string.IsNullOrWhiteSpace(TbContent.Text))
                {
                    //家計簿ベースデータ新規登録
                    if (HouseholdABookBase.InsertHouseholdABookBase(isIncomeOrSpending ? 1 : 0,
                        DateTime.Parse(TbDate.Text), TbAssets.Text, TbClassification.Text, 
                        int.Parse(TbMoney.Text), TbContent.Text, userId))
                    {
                        OriginMBox.MBoxInfoOK("新規データ登録完了");
                    }

                    //非表示してから再表示
                    Hide();
                    TbAssets.Text = "";
                    TbClassification.Text = "";
                    TbMoney.Text = "";
                    string[] timeList = { DateTime.Now.Year.ToString("0000"), DateTime.Now.Month.ToString("00"),
                            DateTime.Now.Day.ToString("00"), DateTime.Now.Hour.ToString("00"), DateTime.Now.Minute.ToString("00") };
                    TbDate.Text = string.Format(AppConst.TIME_STR, timeList);
                    TbContent.Text = "";
                    Show();
                }
            }
        }

        #endregion

        #region イベント

        /// <summary>
        /// タブ切り替えイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TCNewDataCreater_Selected(object sender, TabControlEventArgs e)
        {
            e.TabPage.Controls.Add(TLPanelBtnSpace);
            e.TabPage.Controls.Add(TLPanelContent);
            e.TabPage.Controls.Add(TLPanelInfo);
            e.TabPage.Controls.Add(TLPanelSave);
            e.TabPage.Controls.Add(FLPanelSetDate);

            if (e.TabPageIndex == 0)
            {
                //収入時は0
                isIncomeOrSpending = false;
            }
            else
            {
                //支出時は1
                isIncomeOrSpending = true;
            }
        }

        /// <summary>
        /// カレンダーの日付選択時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void McSelect_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectDate = e.Start;
        }

        /// <summary>
        /// ダイアログが閉じる時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewDataCreater_FormClosing(object sender, FormClosingEventArgs e)
        {
            dialogResult = DialogResult.Yes;
        }

        private void TbMoney_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(TbMoney.Text, out int money))
                {
                    TbMoney.Text = string.Format("¥{0:#,0}", money);
                }
                else
                {
                    OriginMBox.MBoxErrorOK(AppConst.MONEY_ERROR_MESSAGE);
                }
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// レイアウト表示初期化
        /// </summary>
        private void InitVisibleLayout()
        {
            TLPanelSave.Visible = true;
            TLPanelInfo.Visible = true;
            TLPanelContent.Visible = true;

            TLPanelBtnSpace.Visible = false;
            FLPanelSetDate.Visible = false;
            
            for(int i = 0; i < btnList.Count; i++)
            {
                btnList[i].Visible = false;
            }
        }

        /// <summary>
        /// ボタンレイアウト表示変更
        /// </summary>
        /// <param name="btnType">表示ボタン種類</param>
        private void ChangeLayout(DisplayBtnType btnType)
        {
            switch (btnType)
            {
                case DisplayBtnType.BtnDate:
                    FLPanelSetDate.Visible = true;
                    break;
                case DisplayBtnType.Assets:
                    TLPanelBtnSpace.Visible = true;
                    IndicateBtnList(3, DisplayBtnType.Assets);
                    break;
                case DisplayBtnType.IncomeClassification:
                    TLPanelBtnSpace.Visible = true;
                    IndicateBtnList(5, DisplayBtnType.IncomeClassification);
                    break;
                case DisplayBtnType.SpendingClassification:
                    TLPanelBtnSpace.Visible = true;
                    IndicateBtnList(12, DisplayBtnType.SpendingClassification);
                    break;
                case DisplayBtnType.Money:
                case DisplayBtnType.Content:
                    TLPanelContent.Visible = false;
                    FLPanelSetDate.Visible = false;
                    TLPanelBtnSpace.Visible = false;
                    break;
            }

        }

        /// <summary>
        /// ボタン表示
        /// </summary>
        /// <param name="BtnCount"></param>
        /// <param name="btnType"></param>
        private void IndicateBtnList(int BtnCount, DisplayBtnType btnType)
        {
            List<string> strList = new List<string>();
            //Iniファイルから文字列リスト取得
            if(IniFileManager.ReadIniFile(btnType, out strList))
            {
                for(int i = 0; i < BtnCount; i++)
                {
                    //ボタン文字表示
                    btnList[i].Text = strList[i];
                }
            }
            else { return; }

            //iniファイルからボタン表示一覧取得
            for (int i = 0; i < BtnCount; i++)
            {
                btnList[i].Visible = true;
            }
        }

        #endregion
    }
}
