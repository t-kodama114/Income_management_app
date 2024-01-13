using System;
using System.Windows.Forms;
using Windows.UI.Notifications;
using System.Diagnostics;
using HouseholdAccountBook_Mock.MBox;
using HouseholdAccountBook_Mock.DB;
using System.Configuration;

namespace HouseholdAccountBook_Mock
{
    public partial class ToastManager : Form
    {
        #region 定数

        private const string TOAST_TITLE = "家計簿アプリ";

        private const string EXE_PATH = @"C:\Users\makia\OneDrive\デスクトップ\家計簿アプリ";

        #endregion

        #region コンストラクタ

        public ToastManager()
        {
            InitializeComponent();
        }

        #endregion

        #region ロードイベント

        private void ToastManager_Load(object sender, EventArgs e)
        {
            AppConst.FormStyle.SetColor();
            panelToast.BackColor = AppConst.FormStyle.FormColor;

            //通知有無
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
            ConfigurationSetting setting = ConfigurationSetting.SelectSetting(userId);
            CbToastUseFlg.Checked = setting.IsToast;

            //通知日時と時間と分
            DTPickerToast.Value = DateTime.Now;
            TbAddHour.Text = "0";
            TbAddMinute.Text = "0";
        }

        #endregion

        #region クリックイベント

        private void BtnToastTestSend_Click(object sender, EventArgs e)
        {
            if (CbToastUseFlg.Checked)
            {
                CreateTestToast();
            }
            else
            {
                OriginMBox.MBoxErrorOK(AppConst.TOAST_USEFLG_OFF);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            bool isFinish = CbToastUseFlg.Checked ?
                OriginMBox.MBoxInfoOKCancel(AppConst.TOAST_USEFLG_ON + AppConst.TOAST_FINISH) == DialogResult.OK
                : OriginMBox.MBoxInfoOKCancel(AppConst.TOAST_USEFLG_OFF + AppConst.TOAST_FINISH) == DialogResult.OK;

            if (isFinish)
            {
                //DB更新
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
                ConfigurationSetting.UpdateConfigSettingFromToast(userId,CbToastUseFlg.Checked);

                Close();
            }
        }

        private void BtnToastSend_Click(object sender, EventArgs e)
        {
            if (CbToastUseFlg.Checked)
            {
                if (int.Parse(TbAddHour.Text) == 0)
                {
                    var result = OriginMBox.MBoxInfoOKCancel(AppConst.TOAST_HOUR_ERR);
                    if (result != DialogResult.OK) return;
                }
                else if(int.Parse(TbAddMinute.Text) == 0)
                {
                    var result = OriginMBox.MBoxInfoOKCancel(AppConst.TOAST_MINUTE_ERR);
                    if (result != DialogResult.OK) return;
                }

                //TODO 送信されないバグが発生したため、こちらの機能については保留
                CreateScheduleToast();

                OriginMBox.MBoxInfoOK(AppConst.TOAST_SUCCESS);
                Close();
            }
            else
            {
                OriginMBox.MBoxErrorOK(AppConst.TOAST_USEFLG_OFF);
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// トースト通知テスト発信
        /// </summary>
        /// <returns></returns>
        private bool CreateTestToast()
        {
            try
            {
                var tmpl = ToastTemplateType.ToastImageAndText02;
                var xml = ToastNotificationManager.GetTemplateContent(tmpl);
                Debug.WriteLine(xml.GetXml());

                var images = xml.GetElementsByTagName("image");
                var src = images[0].Attributes.GetNamedItem("src");
                src.InnerText = AppConst.TOAST_ICON_FILE_DIR;
                Debug.WriteLine(src.InnerText);

                var texts = xml.GetElementsByTagName("text");
                texts[0].AppendChild(xml.CreateTextNode("テスト"));
                texts[1].AppendChild(xml.CreateTextNode("家計簿アプリの送信テスト"));

                var toast = new ToastNotification(xml);
                ToastNotificationManager.CreateToastNotifier(TOAST_TITLE).Show(toast);
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// トースト通知スケジュール発信
        /// </summary>
        /// <returns></returns>
        private bool CreateScheduleToast()
        {
            try
            {
                var tmpl = ToastTemplateType.ToastImageAndText02;
                var xml = ToastNotificationManager.GetTemplateContent(tmpl);
                Debug.WriteLine(xml.GetXml());

                var images = xml.GetElementsByTagName("image");
                var src = images[0].Attributes.GetNamedItem("src");
                src.InnerText = AppConst.TOAST_ICON_FILE_DIR;
                Debug.WriteLine(src.InnerText);

                var texts = xml.GetElementsByTagName("text");
                texts[0].AppendChild(xml.CreateTextNode("使用確認"));
                texts[1].AppendChild(xml.CreateTextNode("家計簿アプリを使用しましたか？"));

                DateTimeOffset dateTimeOffset =
                    new DateTimeOffset(DTPickerToast.Value.Year, DTPickerToast.Value.Month, DTPickerToast.Value.Day,
                    DTPickerToast.Value.Hour, DTPickerToast.Value.Minute, DTPickerToast.Value.Second, 
                    new TimeSpan(int.Parse(TbAddHour.Text), int.Parse(TbAddMinute.Text), 0));
                var scheduled = new ScheduledToastNotification(xml, dateTimeOffset);
                
                var toastNotifier = ToastNotificationManager.CreateToastNotifier(TOAST_TITLE);
                toastNotifier.AddToSchedule(scheduled);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
            return true;
        }

        #endregion
    }
}
