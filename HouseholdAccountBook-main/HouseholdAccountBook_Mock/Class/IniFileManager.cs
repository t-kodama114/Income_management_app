using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using HouseholdAccountBook_Mock.MBox;

namespace HouseholdAccountBook_Mock.Class
{
    public class IniFileManager
    {
        /// <summary>
        /// iniファイルのファイルパス TODO 相対パスで通す
        /// </summary>
        private const string IniFilePath = @"C:\Users\makia\OneDrive\ドキュメント\HouseholdAccountBook\HouseholdAccountBook_Mock\Ini\HouseholdAccountBook.ini";

        // iniファイル呼び出すラッパー(お決まり)
        // ==========================================================
        [DllImport("KERNEL32.DLL")]
        public static extern uint GetPrivateProfileString(string lpAppName,string lpKeyName, string lpDefault,
            StringBuilder lpReturnedString, uint nSize, string lpFileName);

        [DllImport("KERNEL32.DLL")]
        public static extern uint GetPrivateProfileInt(string lpAppName,
            string lpKeyName, int nDefault, string lpFileName);

        [DllImport("kernel32.dll")]
        static extern int WritePrivateProfileString(
            string lpApplicationName, string lpKeyName,
            string lpstring, string lpFileName);

        [DllImport("kernel32.dll")]
        static extern int GetPrivateProfileSectionNames(
            IntPtr lpszReturnBuffer,
            uint nSize, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern uint GetPrivateProfileSection(
            string lpAppName, string lpReturnedString, uint nSize, string lpFileName);

        // ==========================================================

        /// <summary>
        /// 表示するボタン文字列リスト
        /// </summary>
        /// <param name="displayBtnType">表示するボタンタイプ</param>
        /// <param name="iniFileStrList">iniファイルから取得した文字列リスト</param>
        /// <returns>文字列リスト</returns>
        public static bool ReadIniFile(NewDataCreater.DisplayBtnType displayBtnType, out List<string> iniFileStrList)
        {
            try
            {
                iniFileStrList = new List<string>();

                //新規作成画面用のIniファイル文字列リスト取得
                switch (displayBtnType)
                {
                    case NewDataCreater.DisplayBtnType.BtnDate:
                        //何もしない
                        break;
                    case NewDataCreater.DisplayBtnType.Assets:
                        //資産
                        iniFileStrList = IniStrList("Assets", displayBtnType);
                        break;
                    case NewDataCreater.DisplayBtnType.IncomeClassification:
                        //収入時の分類
                        iniFileStrList = IniStrList("IncomeClassification", displayBtnType);
                        break;
                    case NewDataCreater.DisplayBtnType.SpendingClassification:
                        //支出時の分類
                        iniFileStrList = IniStrList("SpendingClassification", displayBtnType);
                        break;
                    case NewDataCreater.DisplayBtnType.Money:
                    case NewDataCreater.DisplayBtnType.Content:
                        //何もしない
                        break;
                }

                //データがない場合は失敗
                if(iniFileStrList.Count < 1) { return false; }
                return true;
            }
            catch
            {
                OriginMBox.MBoxErrorOK(AppConst.INI_MESSAGE1);
                iniFileStrList = null;
                return false;
            }
        }
        
        /// <summary>
        /// iniファイルの文字列リスト取得
        /// </summary>
        /// <returns></returns>
        private static List<string> IniStrList(string section, NewDataCreater.DisplayBtnType displayBtnType)
        {
            List<string> iniStrList = new List<string>();

            try
            {
                switch (displayBtnType)
                {
                    case NewDataCreater.DisplayBtnType.BtnDate:
                        //何も返さない
                        return null;
                    case NewDataCreater.DisplayBtnType.Assets:
                    case NewDataCreater.DisplayBtnType.IncomeClassification:
                    case NewDataCreater.DisplayBtnType.SpendingClassification:
                        iniStrList = GetAllValue(section);
                        break;
                    case NewDataCreater.DisplayBtnType.Money:
                        //何も返さない
                        return null;
                    case NewDataCreater.DisplayBtnType.Content:
                        //何も返さない
                        return null;
                }

                return iniStrList;
            }
            catch
            {
                OriginMBox.MBoxErrorOK(AppConst.INI_MESSAGE2);
                return null;
            }
        }

        /// <summary>
        /// iniファイル中のセクションのキーを指定して、文字列を返す
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetValueString(string section, string key)
        {
            StringBuilder sb = new StringBuilder(1024);

            GetPrivateProfileString(section, key, "", sb, Convert.ToUInt32(sb.Capacity), IniFilePath);

            return sb.ToString();
        }

        /// <summary>
        /// iniファイル中のセクションのキーを指定して、整数値を返す
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetValueInt(string section, string key)
        {
            return (int)GetPrivateProfileInt(section, key, 0, IniFilePath);
        }

        /// <summary>
        /// 指定したセクション、キーに数値を書き込む
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        private void SetValue(string section, string key, int val)
        {
            SetValue(section, key, val.ToString());
        }

        /// <summary>
        /// 指定したセクション、キーに文字列を書き込む
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        private void SetValue(string section, string key, string val)
        {
            WritePrivateProfileString(section, key, val, IniFilePath);
        }

        /// <summary>
        /// 指定したセクションで文字列リストを取得
        /// </summary>
        /// <param name="section"></param>
        private static List<string> GetAllValue(string section)
        {
            List<string> allValueList = new List<string>();

            string keyValues = new string('\0', 512);
            uint ret = GetPrivateProfileSection(section, keyValues, (uint)keyValues.Length, IniFilePath);

            foreach (string keyValue in keyValues.Trim('\0').Split('\0'))
            {
                string[] data = keyValue.Split('=');
                //Console.WriteLine("キー：{0} 値：{1}", data[0], data[1]);
                allValueList.Add(data[1]);
            }

            return allValueList;
        }

    }
}
