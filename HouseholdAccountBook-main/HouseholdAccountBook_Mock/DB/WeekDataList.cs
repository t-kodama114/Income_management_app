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
    /// 1週間ごとの収入と支出データ管理テーブル
    /// </summary>
    public class WeekDataList
    {
        #region 定数

        private const string ID_STR = "Id";
        private const string WEEKDATE_STR = "WeekData";
        private const string FIRSTDATE_STR = "FirstDate";
        private const string LASTDATE_STR = "LastDate";
        private const string USERID_STR = "userId";

        #endregion

        #region プロパティ

        /// <summary>
        /// ID(収入:0か支出:1)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 1週間の収入か支出データ
        /// </summary>
        public int WeekData { get; set; }

        /// <summary>
        /// 週の始まり
        /// </summary>
        public DateTime FirstDate { get; set; }

        /// <summary>
        /// 週の終わり
        /// </summary>
        public DateTime LastDate { get; set; }

        /// <summary>
        /// ユーザーID
        /// </summary>
        public int UserId { get; set; }

        #endregion

        #region メソッド

        /// <summary>
        /// 1週間ごとの収入と支出データ情報登録
        /// </summary>
        /// <param name="dr">列データ</param>
        public void InitDataRow(DataRow dr)
        {
            Id = int.Parse(dr[ID_STR].ToString());
            WeekData = int.Parse(dr[WEEKDATE_STR].ToString());
            FirstDate = DateTime.Parse(dr[FIRSTDATE_STR].ToString());
            LastDate = DateTime.Parse(dr[LASTDATE_STR].ToString());
            UserId = int.Parse(dr[USERID_STR].ToString());
        }

        /// <summary>
        /// 月始めから月終わりまでの週ごとの収入と支出データ取得
        /// </summary>
        /// <param name="start">月初め</param>
        /// <param name="end">月終わり</param>
        /// <returns>週ごとの収入と支出データ</returns>
        public static List<WeekDataList> SelectDisplayList(DateTime start, DateTime end, int userId)
        {
            List<WeekDataList> dataLists = new List<WeekDataList>();

            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    //収入
                    string sql = "select * from public.\"WeekDataList\" where \"Id\" = 0"
                    + " and \"FirstDate\" >= '" + start.ToString() + "'"
                    + " and \"LastDate\" < '" + end.ToString() + "'"
                    + " and \"userId\" = " + userId;

                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];
                    if (table.Rows.Count < 1) { return null; }
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        WeekDataList weekData = new WeekDataList();
                        weekData.InitDataRow(table.Rows[i]);

                        dataLists.Add(weekData);
                    }

                    //支出
                    sql = "select * from public.\"WeekDataList\" where \"Id\" = 1"
                        + " and \"FirstDate\" >= '" + start.ToString() + "'"
                        + " and \"LastDate\" < '" + end.ToString() + "'"
                        + " and \"userId\" = " + userId;
                    dataSet = dBManager.GetDataSet(sql);
                    table = dataSet.Tables[0];
                    if (table.Rows.Count < 1) { return null; }
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        WeekDataList weekData = new WeekDataList();
                        weekData.InitDataRow(table.Rows[i]);

                        dataLists.Add(weekData);
                    }
                }
                catch
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.WEEKDATA_MESSAGE);
                    return null;
                }
            }
            return dataLists;
        }

        /// <summary>
        /// 週ごとの表示用データ作成
        /// </summary>
        /// <param name="dataLists">週ごとの収入と支出データ</param>
        /// <returns>表示用文字列データ作成</returns>
        public static List<string[]> GetDisplayDataList(List<WeekDataList> dataLists)
        {
            List<string[]> vs = new List<string[]>();

            try
            {
                if(dataLists == null) { return null; }
                //表示用データ作成
                List<WeekDataList> incomeDataList = dataLists.Where(data => data.Id == 0).ToList();
                List<WeekDataList> spendingDataList = dataLists.Where(data => data.Id == 1).ToList();

                for (int i = 0; i < incomeDataList.Count; i++)
                {
                    WeekDataList weekData = incomeDataList[i];

                    WeekDataList spendingData = spendingDataList.
                        Where(data => data.FirstDate == weekData.FirstDate &&
                        data.LastDate == weekData.LastDate).First();

                    string[] dataListStr =
                    {
                        weekData.FirstDate.ToString("yyyy/MM/dd") + "～" + weekData.LastDate.ToString("yyyy/MM/dd"),
                        weekData.WeekData.ToString(),
                        spendingData.WeekData.ToString()
                    };

                    vs.Add(dataListStr);
                }
            }
            catch
            {
                //string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.WEEKDATA_MESSAGE);
                return null;
            }
            return vs;
        }

        /// <summary>
        /// 週ごとの収入と支出データ登録
        /// </summary>
        /// <returns>成功か失敗</returns>
        public static bool InsertWeekDataList(List<WeekDataList> weekDataLists)
        {
            using (NpgSqlDBManager npgSqlDBManager = new NpgSqlDBManager())
            {
                try
                {
                    npgSqlDBManager.Open();
                    npgSqlDBManager.BeginTran();

                    for (int i = 0; i < weekDataLists.Count; i++)
                    {
                        //SQL文
                        string strSQL = "INSERT INTO public.\"WeekDataList\" VALUES( " 
                        + weekDataLists[i].Id + " , " + weekDataLists[i].WeekData + " , " 
                        + "CAST('" + weekDataLists[i].FirstDate.ToString("yyyy/MM/dd") + "' AS TIMESTAMP)" + ", " 
                        + "CAST('" + weekDataLists[i].LastDate.ToString("yyyy/MM/dd") + "' AS TIMESTAMP)" + ", " 
                        + weekDataLists[i].UserId + ")";

                        npgSqlDBManager.ExecuteNonQuery(strSQL);
                    }

                    npgSqlDBManager.CommitTran();
                }
                catch
                {
                    npgSqlDBManager.RollBack();
                    npgSqlDBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.CALENDER_MESSAGE2);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 週ごとの収入と支出データ登録更新
        /// </summary>
        /// <returns>成功か失敗</returns>
        public static bool UpdateWeekDataList(List<WeekDataList> weekDataLists)
        {
            using (NpgSqlDBManager npgSqlDBManager = new NpgSqlDBManager())
            {
                try
                {
                    npgSqlDBManager.Open();
                    npgSqlDBManager.BeginTran();

                    for (int i = 0; i < weekDataLists.Count; i++)
                    {
                        //SQL文
                        string strSQL = "Update public.\"WeekDataList\" set \"WeekData\" = " + weekDataLists[i].WeekData
                        + " where \"Id\" = " + weekDataLists[i].Id +
                        " and \"FirstDate\" = '" + weekDataLists[i].FirstDate.ToString("yyyy/MM/dd") + "' " +
                        " and \"LastDate\" = '" + weekDataLists[i].LastDate.ToString("yyyy/MM/dd") + "'" +
                        " and \"userId\" = " + weekDataLists[i].UserId;

                        npgSqlDBManager.ExecuteNonQuery(strSQL);
                    }

                    npgSqlDBManager.CommitTran();
                }
                catch
                {
                    npgSqlDBManager.RollBack();
                    npgSqlDBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.CALENDER_MESSAGE2);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ベースデータから週ごとのデータ作成
        /// </summary>
        /// <param name="dataLists">ベースデータ</param>
        /// <param name="dateTimeLists">週の始まりと終わりのデータリスト</param>
        /// <returns></returns>
        public static List<WeekDataList> CreateWeekDataList(List<int[]> dataLists, List<DateTime[]> dateTimeLists, int userId)
        {
            List<WeekDataList> weekDataLists = new List<WeekDataList>();

            try
            {
                if(dataLists == null) { return null; }
                if(dateTimeLists == null) { return null; }

                int count = 0;
                foreach(var dateTimes in dateTimeLists)
                {
                    count = 0;
                    int income = 0;
                    int spending = 0;
                    int startDay = dateTimes[0].Day;
                    int endDay = dateTimes[1].Day;

                    //収入
                    for(int i = 0; i < dataLists[count].Length; i++)
                    {   
                        if(i >= startDay && endDay >= i)
                        {
                            income += dataLists[count][i];
                        }
                    }

                    WeekDataList weekData = new WeekDataList
                    {
                        Id = AppConst.INCOME_VALUE,
                        WeekData = income,
                        FirstDate = dateTimes[0],
                        LastDate = dateTimes[1],
                        UserId = userId
                    };
                    weekDataLists.Add(weekData);

                    count++;
                    //支出
                    for (int i = 0; i < dataLists[count].Length; i++)
                    {
                        if (i >= startDay && endDay >= i)
                        {
                            spending += dataLists[count][i];
                        }
                    }

                    weekData = new WeekDataList
                    {
                        Id = AppConst.SPENDING_VALUE,
                        WeekData = spending,
                        FirstDate = dateTimes[0],
                        LastDate = dateTimes[1],
                        UserId = userId
                    };
                    weekDataLists.Add(weekData);
                }
            }
            catch
            {
                OriginMBox.MBoxErrorOK(AppConst.CALENDER_MESSAGE2);
                return null;
            }
            return weekDataLists;
        }

        /// <summary>
        /// 週の始まりと終わりのデータリストを返す
        /// </summary>
        /// <param name="start">月初め</param>
        /// <param name="end">月終わり</param>
        /// <returns>週の始まりと終わりのデータリスト</returns>
        public static List<DateTime[]> GetDateTimes(DateTime start, DateTime end)
        {
            List<DateTime[]> dateList = new List<DateTime[]>();

            try
            {
                DateTime startDate = start;
                DateTime endDate = DateTime.MinValue;
                int count = 0;
                while (end > endDate)
                {
                    //月始めのときは最終日取得から行う
                    if (count <= 0)
                    {
                        endDate = LastDayOfWeek(start, DayOfWeek.Sunday);
                    }
                    //他の場合は開始日取得から行う
                    else
                    {
                        startDate = endDate.AddDays(1);
                        endDate = LastDayOfWeek(startDate, DayOfWeek.Sunday);
                    }

                    //最後の週の場合、最終日設定
                    if (end.Day - endDate.Day < 7)
                    {
                        endDate = end;
                    }

                    DateTime[] dates = { startDate, endDate };
                    dateList.Add(dates);

                    count++;
                }
            }
            catch(Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.CALENDER_MESSAGE2);
                return null;
            }
            
            return dateList;
        }

        /// <summary>
        /// 最新版のデータか判定
        /// </summary>
        /// <param name="monthDataLst">1年間のデータリスト</param>
        /// <param name="dataLst">収入と支出リスト</param>
        /// <returns>最新データかどうか</returns>
        public static bool IsNewMonthDataList(List<WeekDataList> weekDataLst, List<int[]> dataLst)
        {
            try
            {
                if (weekDataLst.Count() != dataLst[0].Count()) { return false; }
                if (weekDataLst.Count() != dataLst[1].Count()) { return false; }

                for (int i = 0; i < weekDataLst.Count; i++)
                {
                    if (weekDataLst[i].Id == 0 && weekDataLst[i].WeekData != dataLst[0][i]) { return false; }
                    if (weekDataLst[i].Id == 1 && weekDataLst[i].WeekData != dataLst[1][i]) { return false; }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                OriginMBox.MBoxErrorOK(AppConst.MONTHDATA_MESSAGE2);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 週の最初の曜日を指定して開始日を返す
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start">週の最初の曜日</param>
        /// <returns></returns>
        public static DateTime FirstDayOfWeek(DateTime source, DayOfWeek start)
        {
            int diff = start - source.DayOfWeek;
            return source.AddDays(diff > 0
              ? diff - 7
              : diff);
        }

        /// <summary>
        /// 週の最初の曜日を指定して最終日を返す
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start">週の最初の曜日</param>
        /// <returns></returns>
        public static DateTime LastDayOfWeek(DateTime source, DayOfWeek start)
        {
            int diff = start - source.DayOfWeek;
            return source.AddDays(diff <= 0
              ? diff + 7
              : diff - 1);
        }

        #endregion
    }
}
