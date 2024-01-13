using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;
using HouseholdAccountBook_Mock.MBox;

namespace HouseholdAccountBook_Mock.DB
{
    /// <summary>
    /// User設定（パスワード、スタイル、通知設定）
    /// </summary>
    public class ConfigurationSetting
    {
        #region 定数

        private const string ID_STR = "Id";
        private const string CREATEDATE_STR = "CreateDate";
        private const string STYLECOLOR_STR = "StyleColor";
        private const string ISTOAST_STR = "IsToast";

        #endregion

        #region コンストラクタ

        public ConfigurationSetting() { }

        public ConfigurationSetting(DataRow dr)
        {
            InitDataRow(dr);
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// ID(連番)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// スタイル（色）
        /// </summary>
        public int StyleColor { get; set; }

        /// <summary>
        /// トースト通知ありorなし
        /// true:通知あり　false:通知なし
        /// </summary>
        public bool IsToast { get; set; }

        #endregion

        #region メソッド

        public void InitDataRow(DataRow dr)
        {
            Id = int.Parse(dr[ID_STR].ToString());
            CreateDate = DateTime.Parse(dr[CREATEDATE_STR].ToString());
            StyleColor = int.Parse(dr[STYLECOLOR_STR].ToString());
            IsToast = bool.Parse(dr[ISTOAST_STR].ToString());
        }

        /// <summary>
        /// UserIdから設定情報取得
        /// </summary>
        /// <param name="_id">UserId</param>
        /// <returns>設定情報取得</returns>
        public static ConfigurationSetting SelectSetting(int _id)
        {
            using(NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                ConfigurationSetting configuration;
                try
                {
                    string sql = "select * from public.\"ConfigurationSetting\" where \"Id\" = " + _id;

                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];
                    if (table.Rows.Count < 1) { return null; }

                    configuration = new ConfigurationSetting(table.Rows[0]);
                }
                catch (Exception e)
                {
                    string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.USER_ERROR_MESSAGE);
                    return null;
                }
                return configuration;
            }
        }

        /// <summary>
        /// ユーザー情報作成時に設定情報も作成
        /// </summary>
        /// <param name="_id">UserID</param>
        /// <param name="styleColor">スタイルの色</param>
        /// <returns>設定情報取得</returns>
        public static ConfigurationSetting InsertConfigSetting(int _id, int styleColor)
        {
            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    dBManager.Open();
                    dBManager.BeginTran();

                    string sql = "INSERT INTO public.\"ConfigurationSetting\" "
                                            + "VALUES(" + _id + ", "
                                            + "'" + DateTime.Now.ToString() + "', "
                                            + "'" + styleColor + "', "
                                            + false + ")";

                    dBManager.ExecuteNonQuery(sql);
                    dBManager.CommitTran();
                }
                catch (Exception e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.USER_MESSAGE);
                    return null;
                }
            }

            // 作成したユーザー情報取得
            ConfigurationSetting setting = SelectSetting(_id);
            return setting;
        }

        /// <summary>
        /// スタイル更新
        /// </summary>
        /// <param name="_id"UserID></param>
        /// <param name="styleColor">スタイルの色</param>
        /// <returns>設定情報</returns>
        public static ConfigurationSetting UpdateConfigSettingFromColor(int _id, int styleColor)
        {
            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    string sql = "UPDATE public.\"ConfigurationSetting\" "
                                        + "SET \"StyleColor\" = " + styleColor
                                        + " where \"Id\" = " + _id;

                    dBManager.Open();
                    dBManager.BeginTran();

                    dBManager.ExecuteNonQuery(sql);
                    dBManager.CommitTran();
                }
                catch (Exception ex)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = ex.Message;
                    OriginMBox.MBoxErrorOK(AppConst.USER_ERROR_MESSAGE02);
                    return null;
                }
            }
            ConfigurationSetting setting = SelectSetting(_id);
            return setting;
        }

        /// <summary>
        /// トースト通知有無設定
        /// </summary>
        /// <param name="_id"UserID></param>
        /// <param name="isToast">トースト通知有無</param>
        /// <returns>設定情報</returns>
        public static ConfigurationSetting UpdateConfigSettingFromToast(int _id, bool isToast)
        {
            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    string sql = "UPDATE public.\"ConfigurationSetting\" "
                                        + "SET \"IsToast\" = " + isToast
                                        + " where \"Id\" = " + _id;

                    dBManager.Open();
                    dBManager.BeginTran();

                    dBManager.ExecuteNonQuery(sql);
                    dBManager.CommitTran();
                }
                catch
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.USER_ERROR_MESSAGE02);
                    return null;
                }
            }
            ConfigurationSetting setting = SelectSetting(_id);
            return setting;
        }

        /// <summary>
        /// 通知設定更新
        /// </summary>
        /// <param name="_id">UserId</param>
        /// <param name="isToast">トースト通知ありorなし</param>
        /// <returns>通知設定</returns>
        public static ConfigurationSetting UpdateConfigSettingFromIsToast(int _id, bool isToast)
        {
            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    string sql = "UPDATE public.\"ConfigurationSetting\" "
                                        + "SET \"IsToast\" = " + isToast
                                        + " where \"Id\" = " + _id;

                    dBManager.Open();
                    dBManager.BeginTran();

                    dBManager.ExecuteNonQuery(sql);
                    dBManager.CommitTran();
                }
                catch (Exception ex)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = ex.Message;
                    OriginMBox.MBoxErrorOK(AppConst.USER_ERROR_MESSAGE02);
                    return null;
                }
            }
            ConfigurationSetting setting = SelectSetting(_id);
            return setting;
        }
        #endregion
    }
}
