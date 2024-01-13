using System;
using System.Collections.Generic;
using HouseholdAccountBook_Mock.MBox;
using System.Data;
using Npgsql;

namespace HouseholdAccountBook_Mock.DB
{
    /// <summary>
    /// 統計確認データ（主にグラフ表示用）
    /// </summary>
    public class StatisticsData
    {
        #region 定数

        private const string DATAID_STR = "data_id";
        private const string CREATEDATE_STR = "createDate";
        private const string CLASSIFICATION_STR = "Classification";
        private const string MONEY_STR = "money";
        private const string STARTDATE_STR = "StartDate";
        private const string ENDDATE_STR = "EndDate";
        private const string USERID_STR = "userId";

        #endregion

        #region コンストラクタ

        public StatisticsData(){}

        public StatisticsData(DataRow dr)
        {
            InitDataRow(dr);
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// ID(収入:0か支出:1)
        /// </summary>
        public int DataId { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 分類
        /// </summary>
        public string Classification { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// スタート日時
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// エンド日時
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// ユーザーID
        /// </summary>
        public int UserId { get; set; }

        #endregion

        #region メソッド

        /// <summary>
        /// グラフ表示用の分類データ情報登録
        /// </summary>
        /// <param name="dr">列データ</param>
        public void InitDataRow(DataRow dr)
        {
            DataId = int.Parse(dr[DATAID_STR].ToString());
            CreateDate = DateTime.Parse(dr[CREATEDATE_STR].ToString());
            Classification = dr[CLASSIFICATION_STR].ToString();
            Money = int.Parse(dr[MONEY_STR].ToString());
            StartDate = DateTime.Parse(dr[STARTDATE_STR].ToString());
            EndDate = DateTime.Parse(dr[ENDDATE_STR].ToString());
            UserId = int.Parse(dr[USERID_STR].ToString());
        }

        /// <summary>
        /// グラフ表示用の分類データ取得(デフォルトで期間指定)
        /// </summary>
        /// <param name="start">スタート日時</param>
        /// <param name="end">エンド日時</param>
        /// <returns></returns>
        public static List<StatisticsData> SelectStatisticsDataList(int data_id ,DateTime start, DateTime end, int userId)
        {
            List<StatisticsData> statisticsDataList = new List<StatisticsData>();

            using(NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    string sql = "select * from public.\"StatisticsData\" where \"data_id\" = " + data_id
                    + " and \"StartDate\" = '" + start.ToString() + "'"
                    + " and \"EndDate\" = '" + end.ToString() + "'"
                    + " and \"userId\" = " + userId;

                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];
                    if (table.Rows.Count < 1) { return null; }

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        StatisticsData statisticsData = new StatisticsData(table.Rows[i]);
                        statisticsDataList.Add(statisticsData);
                    }
                }
                catch(Exception e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.STATISTICS_MESSAGE);
                    return null;
                }
            }

            return statisticsDataList;
        }

        public static bool InsertStatisticsData(List<HouseholdABookBase.HouseholdABook> householdABookList, 
            DateTime start, DateTime end, int userId)
        {
            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    if(householdABookList.Count <= 0) { return false; }

                    int id = householdABookList[0].idStr == AppConst.INCOME ? AppConst.INCOME_VALUE : AppConst.SPENDING_VALUE;
                    Dictionary<string, int> moneyParam = StatisticsType.GetMoneysParam(householdABookList, userId);
                    if(moneyParam == null && moneyParam.Count < 0) { return false; }

                    dBManager.Open();
                    dBManager.BeginTran();

                    foreach (var moneyData in moneyParam)
                    {
                        if(moneyData.Value > 0)
                        {
                            string sql = "INSERT INTO public.\"StatisticsData\" "
                                            + "VALUES(" + id + ", "
                                            + "'" + DateTime.Now + "', "
                                            + "'" + moneyData.Key + "', "
                                            + moneyData.Value + ", '" + start + "', '" + end + "', "
                                            + userId + ")";

                            dBManager.ExecuteNonQuery(sql);
                        }
                    }
                    dBManager.CommitTran();
                }
                catch (Exception e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.STATISTICS_MESSAGE2);
                    return false;
                }
            }
            
            return true;
        }

        public static bool UpdateStatisticsData(List<HouseholdABookBase.HouseholdABook> householdABookList, 
            DateTime start, DateTime end, int userId)
        {
            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    if (householdABookList.Count <= 0) { return false; }

                    int id = householdABookList[0].idStr == AppConst.INCOME ? AppConst.INCOME_VALUE : AppConst.SPENDING_VALUE;
                    Dictionary<string, int> moneyParam = StatisticsType.GetMoneysParam(householdABookList, userId);
                    if (moneyParam == null && moneyParam.Count < 0) { return false; }

                    dBManager.Open();
                    dBManager.BeginTran();

                    foreach(var moneyData in moneyParam)
                    {
                        if(moneyData.Value > 0)
                        {
                            string sql = "UPDATE public.\"StatisticsData\" "
                                        + "SET \"createDate\" = '" + DateTime.Now.ToString() + "', "
                                        + "\"money\" = " + moneyData.Value
                                        + " where \"data_id\" = " + id
                                        + " and \"Classification\" = '" + moneyData.Key + "'"
                                        + " and \"StartDate\" = '" + start + "' and \"EndDate\" = '" + end + "'"
                                        + " and \"userId\" = " + userId;

                            dBManager.ExecuteNonQuery(sql);
                        }
                    }
                    dBManager.CommitTran();
                }
                catch (Exception e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.STATISTICS_MESSAGE2);
                    return false; 
                }
            }

            return true;
        }

        /// <summary>
        /// 円グラフのデータ作成 or 更新
        /// </summary>
        /// <param name="statisticsInfo">統計確認情報</param>
        /// <returns>統計確認データ</returns>
        public static List<StatisticsData> UpsertDataList(AppConst.StatisticsInfo statisticsInfo)
        {
            try
            {
                int id = statisticsInfo.Id;
                List<HouseholdABookBase.HouseholdABook> householdABookList = statisticsInfo.BookList;
                DateTime start = statisticsInfo.StartDate;
                DateTime end = statisticsInfo.EndDate;
                int userId = statisticsInfo.UserId;

                List<StatisticsData> dataList = SelectStatisticsDataList(id, start, end, userId);
                if (dataList != null && dataList.Count > 0)
                {
                    if (!UpdateStatisticsData(householdABookList, start, end, userId)) return null;
                }
                else
                {
                    if (!InsertStatisticsData(householdABookList, start, end, userId)) return null;
                }

                dataList = SelectStatisticsDataList(id, start, end, userId);

                return dataList;
            }
            catch (Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.STATISTICS_MESSAGE2);
                return null;
            }
        }

        #endregion
    }
}
