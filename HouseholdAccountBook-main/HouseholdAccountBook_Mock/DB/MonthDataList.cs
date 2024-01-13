using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HouseholdAccountBook_Mock.MBox;

namespace HouseholdAccountBook_Mock.DB
{
    /// <summary>
    /// 月ごとの収入と支出データ管理テーブル
    /// </summary>
    public class MonthDataList
    {
        #region 定数

        private const string ID_STR = "Id";
        private const string INCOME_STR = "Income";
        private const string SPENDING_STR = "Spending";
        private const string CREATEDATE_STR = "CreateDate";
        private const string USERID_STR = "userId";

        private const int MAX_MONTH_COUNT = 12;

        #endregion

        #region プロパティ

        /// <summary>
        /// ID(月)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 収入データ
        /// </summary>
        public int Income { get; set; }

        /// <summary>
        /// 支出データ
        /// </summary>
        public int Spending { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// ユーザーID
        /// </summary>
        public int UserId { get; set; }

        #endregion

        #region メソッド

        /// <summary>
        /// 月ごとの収入と支出データ管理データ登録
        /// </summary>
        /// <param name="dr">列データ</param>
        public void InitDataRow(DataRow dr)
        {
            Id = int.Parse(dr[ID_STR].ToString());
            Income = int.Parse(dr[INCOME_STR].ToString());
            Spending = int.Parse(dr[SPENDING_STR].ToString());
            CreateDate = DateTime.Parse(dr[CREATEDATE_STR].ToString());
            UserId = int.Parse(dr[USERID_STR].ToString());
        }

        /// <summary>
        /// 月ごとの収入と支出データ管理データ取得
        /// </summary>
        /// <returns></returns>
        public static List<MonthDataList> SelectDisplayList(int year, int userId)
        {
            List<MonthDataList> monthDataList = new List<MonthDataList>();

            using(NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    string sql = "select * from public.\"MonthDataList\" where \"userId\" = " + userId;

                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];
                    if (table.Rows.Count < 1) { return null; }
                    
                    for(int i = 0; i < table.Rows.Count; i++)
                    {
                        DateTime date = DateTime.Parse(table.Rows[i][CREATEDATE_STR].ToString());
                        if(year != date.Year) { continue; }

                        MonthDataList monthData = new MonthDataList();
                        monthData.InitDataRow(table.Rows[i]);

                        monthDataList.Add(monthData);
                    }

                    //データが12か月分あるか確認
                    if(monthDataList.Count != MAX_MONTH_COUNT) { return null; }
                }
                catch
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.MONTHDATA_MESSAGE);
                    return null;
                }
            }
            return monthDataList;
        }

        /// <summary>
        /// 月ごとの表示用データ作成
        /// </summary>
        /// <param name="dataLists">週ごとの収入と支出データ</param>
        /// <returns>表示用文字列データ作成</returns>
        public static List<string[]> GetDisplayDataList(List<MonthDataList> dataLists)
        {
            List<string[]> vs = new List<string[]>();

            try
            {
                if (dataLists == null) { return null; }
                
                for (int i = 0; i < MAX_MONTH_COUNT; i++)
                {
                    MonthDataList monthData = dataLists[i];

                    string[] dataListStr =
                    {
                        monthData.Id + "月",
                        monthData.Income.ToString(),
                        monthData.Spending.ToString()
                    };

                    vs.Add(dataListStr);
                }
            }
            catch
            {
                //string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.MONTHDATA_MESSAGE);
                return null;
            }
            return vs;
        }

        /// <summary>
        /// 月ごとの収入と支出データ登録
        /// </summary>
        /// <returns>成功か失敗</returns>
        public static bool InsertMonthDataList(List<MonthDataList> monthDataLists)
        {
            using (NpgSqlDBManager npgSqlDBManager = new NpgSqlDBManager())
            {
                try
                {
                    npgSqlDBManager.Open();
                    npgSqlDBManager.BeginTran();

                    for (int i = 0; i < monthDataLists.Count; i++)
                    {
                        //SQL文
                        string strSQL = "INSERT INTO public.\"MonthDataList\" VALUES( "
                        + monthDataLists[i].Id + " , " + monthDataLists[i].Income + " , "
                        + monthDataLists[i].Spending + " , "
                        + "CAST('" + monthDataLists[i].CreateDate.ToString("yyyy/MM/dd") + "' AS TIMESTAMP) , "
                        + monthDataLists[i].UserId + ")";

                        npgSqlDBManager.ExecuteNonQuery(strSQL);
                    }

                    npgSqlDBManager.CommitTran();
                }
                catch
                {
                    npgSqlDBManager.RollBack();
                    npgSqlDBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.MONTHDATA_MESSAGE2);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 月ごとの収入と支出データ更新
        /// </summary>
        /// <returns>成功か失敗</returns>
        public static bool UpdateMonthDataList(List<MonthDataList> monthDataLists)
        {
            using (NpgSqlDBManager npgSqlDBManager = new NpgSqlDBManager())
            {
                try
                {
                    npgSqlDBManager.Open();
                    npgSqlDBManager.BeginTran();

                    //SQL文
                    foreach (var pair in monthDataLists)
                    {
                        string strSQL = "Update public.\"MonthDataList\" set \"Income\" = " + pair.Income
                            + ", \"Spending\" = " + pair.Spending
                            + " where \"Id\" = " + pair.Id
                            + " and \"CreateDate\" = '" + pair.CreateDate.ToString("yyyy/MM/dd") + "'"
                            + " and \"userId\" = " + pair.UserId;

                        npgSqlDBManager.ExecuteNonQuery(strSQL);
                    }

                    npgSqlDBManager.CommitTran();
                }
                catch
                {
                    npgSqlDBManager.RollBack();
                    npgSqlDBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.MONTHDATA_MESSAGE2);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ベースデータから月ごとのデータ作成
        /// </summary>
        /// <param name="dataLists">ベースデータ</param>
        /// <param name="dateTimeLists">週の始まりと終わりのデータリスト</param>
        /// <returns></returns>
        public static List<MonthDataList> CreateMonthDataList(List<int[]> dataLists, DateTime nowDate, int userId)
        {
            List<MonthDataList> monthDataLists = new List<MonthDataList>();

            try
            {
                if (dataLists == null) { return null; }
                if (dataLists[0].Length != MAX_MONTH_COUNT) { return null; }
                if (dataLists[1].Length != MAX_MONTH_COUNT) { return null; }

                //収入と支出データ作成
                int[] incomes = dataLists[0];
                int[] spendings = dataLists[1];

                int count = 1;
                for(int i = 0; i < MAX_MONTH_COUNT; i++)
                {
                    MonthDataList monthData = new MonthDataList
                    {
                        Id = count,
                        Income = incomes[i],
                        Spending = spendings[i],
                        CreateDate = nowDate,
                        UserId = userId
                    };
                    monthDataLists.Add(monthData);
                    count++;
                }
            }
            catch
            {
                //string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.MONTHDATA_MESSAGE2);
                return null;
            }
            return monthDataLists;
        }

        /// <summary>
        /// 最新版のデータか判定
        /// </summary>
        /// <param name="monthDataLst">1年間のデータリスト</param>
        /// <param name="dataLst">収入と支出リスト</param>
        /// <returns>最新データかどうか</returns>
        public static bool IsNewMonthDataList(List<MonthDataList> monthDataLst, List<int[]> dataLst)
        {
            try
            {
                if (monthDataLst.Count() != dataLst[0].Count()) { return false; }
                if (monthDataLst.Count() != dataLst[1].Count()) { return false; }

                for (int i = 0; i < monthDataLst.Count; i++)
                {
                    if (monthDataLst[i].Income != dataLst[0][i]) { return false; }
                    if (monthDataLst[i].Spending != dataLst[1][i]) { return false; }
                }
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                OriginMBox.MBoxErrorOK(AppConst.MONTHDATA_MESSAGE2);
                return false;
            }
            return true;
        }

        #endregion
    }
}
