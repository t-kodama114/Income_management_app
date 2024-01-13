using System;
using System.Drawing;
using HouseholdAccountBook_Mock.DB;
using System.Windows.Forms;
using System.Configuration;

namespace HouseholdAccountBook_Mock
{
    public partial class SetStyle : Form
    {
        #region プロパティ

        /// <summary>
        /// 設定情報
        /// </summary>
        private ConfigurationSetting setting { get; set; }

        #endregion

        #region Enum

        #endregion

        #region コンストラクタ

        public SetStyle(ConfigurationSetting _setting)
        {
            InitializeComponent();
            setting = _setting;
        }

        #endregion

        #region ロードイベント

        private void SetStyle_Load(object sender, EventArgs e)
        {
            panelConfiguration.BackColor = AppConst.FormStyle.FormColor;
            SetStyleCheck();
        }

        #endregion

        #region クリックイベント

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            int num = GetStyleNum();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
            setting = ConfigurationSetting.UpdateConfigSettingFromColor(userId, num);

            //スタイルの色設定
            AppConst.FormStyle.FormColor = AppConst.FormStyle.GetBGColor(setting.StyleColor);
            Close();
        }

        #endregion

        #region クリックイベント

        private void CbColor1_CheckedChanged(object sender, EventArgs e)
        {
            if (CbColor1.Checked)
            {
                CbColor2.Checked = false;
                CbColor3.Checked = false;
                CbColor4.Checked = false;
                CbColor5.Checked = false;
                CbColor6.Checked = false;
                CbColor7.Checked = false;
                CbColor8.Checked = false;
                CbColor9.Checked = false;
                CbColor10.Checked = false;
            }
        }

        private void CbColor2_CheckedChanged(object sender, EventArgs e)
        {
            if (CbColor2.Checked)
            {
                CbColor1.Checked = false;
                CbColor3.Checked = false;
                CbColor4.Checked = false;
                CbColor5.Checked = false;
                CbColor6.Checked = false;
                CbColor7.Checked = false;
                CbColor8.Checked = false;
                CbColor9.Checked = false;
                CbColor10.Checked = false;
            }
        }

        private void CbColor3_CheckedChanged(object sender, EventArgs e)
        {
            if (CbColor3.Checked)
            {
                CbColor1.Checked = false;
                CbColor2.Checked = false;
                CbColor4.Checked = false;
                CbColor5.Checked = false;
                CbColor6.Checked = false;
                CbColor7.Checked = false;
                CbColor8.Checked = false;
                CbColor9.Checked = false;
                CbColor10.Checked = false;
            }
        }

        private void CbColor4_CheckedChanged(object sender, EventArgs e)
        {
            if (CbColor4.Checked)
            {
                CbColor1.Checked = false;
                CbColor2.Checked = false;
                CbColor3.Checked = false;
                CbColor5.Checked = false;
                CbColor6.Checked = false;
                CbColor7.Checked = false;
                CbColor8.Checked = false;
                CbColor9.Checked = false;
                CbColor10.Checked = false;
            }
        }

        private void CbColor5_CheckedChanged(object sender, EventArgs e)
        {
            if (CbColor5.Checked)
            {
                CbColor1.Checked = false;
                CbColor2.Checked = false;
                CbColor3.Checked = false;
                CbColor4.Checked = false;
                CbColor6.Checked = false;
                CbColor7.Checked = false;
                CbColor8.Checked = false;
                CbColor9.Checked = false;
                CbColor10.Checked = false;
            }
        }

        private void CbColor6_CheckedChanged(object sender, EventArgs e)
        {
            if (CbColor6.Checked)
            {
                CbColor1.Checked = false;
                CbColor2.Checked = false;
                CbColor3.Checked = false;
                CbColor4.Checked = false;
                CbColor5.Checked = false;
                CbColor7.Checked = false;
                CbColor8.Checked = false;
                CbColor9.Checked = false;
                CbColor10.Checked = false;
            }
        }

        private void CbColor7_CheckedChanged(object sender, EventArgs e)
        {
            if (CbColor7.Checked)
            {
                CbColor1.Checked = false;
                CbColor2.Checked = false;
                CbColor3.Checked = false;
                CbColor4.Checked = false;
                CbColor5.Checked = false;
                CbColor6.Checked = false;
                CbColor8.Checked = false;
                CbColor9.Checked = false;
                CbColor10.Checked = false;
            }
        }

        private void CbColor8_CheckedChanged(object sender, EventArgs e)
        {
            if (CbColor8.Checked)
            {
                CbColor1.Checked = false;
                CbColor2.Checked = false;
                CbColor3.Checked = false;
                CbColor4.Checked = false;
                CbColor5.Checked = false;
                CbColor6.Checked = false;
                CbColor7.Checked = false;
                CbColor9.Checked = false;
                CbColor10.Checked = false;
            }
        }

        private void CbColor9_CheckedChanged(object sender, EventArgs e)
        {
            if (CbColor9.Checked)
            {
                CbColor1.Checked = false;
                CbColor2.Checked = false;
                CbColor3.Checked = false;
                CbColor4.Checked = false;
                CbColor5.Checked = false;
                CbColor6.Checked = false;
                CbColor7.Checked = false;
                CbColor8.Checked = false;
                CbColor10.Checked = false;
            }
        }

        private void CbColor10_CheckedChanged(object sender, EventArgs e)
        {
            if (CbColor10.Checked)
            {
                CbColor1.Checked = false;
                CbColor2.Checked = false;
                CbColor3.Checked = false;
                CbColor4.Checked = false;
                CbColor5.Checked = false;
                CbColor6.Checked = false;
                CbColor7.Checked = false;
                CbColor8.Checked = false;
                CbColor9.Checked = false;
            }
        }

        #endregion

        #region メソッド
        

        /// <summary>
        /// スタイル色のインデックス取得
        /// </summary>
        /// <returns></returns>
        private int GetStyleNum()
        {
            int num = 0;
            try
            {
                if (CbColor1.Checked)
                {
                    num = 0;
                }
                else if (CbColor2.Checked)
                {
                    num = 1;
                }
                else if (CbColor3.Checked)
                {
                    num = 2;
                }
                else if (CbColor4.Checked)
                {
                    num = 3;
                }
                else if (CbColor5.Checked)
                {
                    num = 4;
                }
                else if (CbColor6.Checked)
                {
                    num = 5;
                }
                else if (CbColor7.Checked)
                {
                    num = 6;
                }
                else if (CbColor8.Checked)
                {
                    num = 7;
                }
                else if (CbColor9.Checked)
                {
                    num = 8;
                }
                else if (CbColor10.Checked)
                {
                    num = 9;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return num;
        }

        /// <summary>
        /// どの色をチェックするのか設定
        /// </summary>
        private void SetStyleCheck()
        {
            switch (setting.StyleColor)
            {
                case (int)AppConst.FormStyle.StyleColor.red:
                    CbColor1.Checked = true;
                    break;
                case (int)AppConst.FormStyle.StyleColor.yellow:
                    CbColor2.Checked = true;
                    break;
                case (int)AppConst.FormStyle.StyleColor.green:
                    CbColor3.Checked = true;
                    break;
                case (int)AppConst.FormStyle.StyleColor.orange:
                    CbColor4.Checked = true;
                    break;
                case (int)AppConst.FormStyle.StyleColor.blue:
                    CbColor5.Checked = true;
                    break;
                case (int)AppConst.FormStyle.StyleColor.purple:
                    CbColor6.Checked = true;
                    break;
                case (int)AppConst.FormStyle.StyleColor.pink:
                    CbColor7.Checked = true;
                    break;
                case (int)AppConst.FormStyle.StyleColor.gray:
                    CbColor8.Checked = true;
                    break;
                case (int)AppConst.FormStyle.StyleColor.black:
                    CbColor9.Checked = true;
                    break;
                case (int)AppConst.FormStyle.StyleColor.white:
                    CbColor10.Checked = true;
                    break;
            }
        }
        #endregion
    }
}
