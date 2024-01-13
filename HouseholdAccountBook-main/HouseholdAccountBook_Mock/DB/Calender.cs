using System;
using System.Data;
using System.Collections.Generic;
using HouseholdAccountBook_Mock.MBox;
using Npgsql;
using System.Linq;

namespace HouseholdAccountBook_Mock.DB
{
    /// <summary>
    /// カレンダー情報テーブル
    /// </summary>
    public class Calender
    {
        #region 定数



        #endregion

        #region プロパティ

        /// <summary>
        /// ID情報（連番）
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 収入
        /// </summary>
        public int Income { get; set; }

        /// <summary>
        /// 支出
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

        #region コンストラクタ

        public Calender() { }

        public Calender(DataRow dr)
        {
            InitDataRow(dr);
        }

        #endregion

        #region メソッド

        /// <summary>
        /// カレンダー情報登録
        /// </summary>
        /// <param name="dr">列データ</param>
        public void InitDataRow(DataRow dr)
        {
            Id = int.Parse(dr["Id"].ToString());
            Income = int.Parse(dr["Income"].ToString());
            Spending = int.Parse(dr["Spending"].ToString());
            CreateDate = DateTime.Parse(dr["Create_Date"].ToString());
            UserId = int.Parse(dr["UserId"].ToString());
        }

        /// <summary>
        /// カレンダーDBデータ作成
        /// </summary>
        /// <param name="count">作成回数</param>
        /// <param name="incomes">収入</param>
        /// <param name="spendings">支出</param>
        /// <returns>カレンダーDBデータリスト</returns>
        public static List<Calender> CreateCalenderList(int count, int[] incomes, int[] spendings, DateTime nowTime, int userId)
        {
            List<Calender> calenders = new List<Calender>();
            try
            {
                int id = 1;

                for(int i = 0; i< count; i++)
                {
                    Calender calender = new Calender
                    {
                        Id = id,
                        Income = incomes[i],
                        Spending = spendings[i],
                        CreateDate = nowTime,
                        UserId = userId
                    };

                    calenders.Add(calender);
                    id++;
                }
            }
            catch
            {
                OriginMBox.MBoxErrorOK(AppConst.CALENDER_MESSAGE2);
                return null;
            }

            return calenders;
        }

        /// <summary>
        /// カレンダーのベースデータ取得
        /// </summary>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<Calender> SelectCalender(DateTime start, DateTime end, out DateTime registerDate, int userId)
        {
            List<Calender> calenderList = new List<Calender>();

            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    //カレンダーDBに該当データが存在するか確認
                    string sql = "select * from public.\"Calender\""
                        + " where \"Calender\".\"Create_Date\" >= '" + start.ToString("yyyy/MM/dd") + "'"
                        + " and \"Calender\".\"Create_Date\" < '" + end.ToString("yyyy/MM/dd") + "'"
                        + " and \"Calender\".\"UserId\" = " + userId;

                    dBManager.Open();
                    dBManager.BeginTran();

                    NpgsqlDataReader reader = dBManager.ExecuteQuery(sql);
                    
                    //データがある場合はデータ取得
                    registerDate = DateTime.MinValue;
                    int count = 0;
                    while (reader.Read())
                    {
                        if (registerDate == DateTime.MinValue && count == 0)
                        {
                            count++;
                            registerDate = DateTime.Parse(reader["Create_Date"].ToString());
                        }
                        Calender calender1 = new Calender
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Income = int.Parse(reader["Income"].ToString()),
                            Spending = int.Parse(reader["Spending"].ToString()),
                            CreateDate = DateTime.Parse(reader["Create_Date"].ToString()),
                            UserId = int.Parse(reader["UserId"].ToString())
                        };

                        calenderList.Add(calender1);
                    }

                    reader.Close();
                }
                catch
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.CALENDER_MESSAGE);
                    registerDate = DateTime.MinValue;
                    return null;
                }

                return calenderList;
            }
        }

        /// <summary>
        /// カレンダーの初期日付設定
        /// </summary>
        /// <returns></returns>
        public static bool InsertInitCalender(int count, DateTime time, int userId)
        {
            using (NpgSqlDBManager npgSqlDBManager = new NpgSqlDBManager())
            {
                try
                {
                    int id = 1;
                    int income = 0;
                    int spending = 0;

                    npgSqlDBManager.Open();
                    npgSqlDBManager.BeginTran();

                    for (int i = 0; i < count; i++)
                    {
                        //SQL文
                        string strSQL = "INSERT INTO public.\"Calender\" VALUES( "
                        + id + " , " + income + " , " + spending + " , "
                        + "CAST('" + time.ToString("yyyy/MM/dd") + "' AS TIMESTAMP) , "
                        + userId + ")";

                        npgSqlDBManager.ExecuteNonQuery(strSQL);
                        id++;
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
        /// カレンダーデータ更新
        /// </summary>
        /// <returns></returns>
        public static bool UpdateCalender(List<Calender> calenderList, DateTime date)
        {
            using(NpgSqlDBManager npgSqlDBManager = new NpgSqlDBManager())
            {
                try
                {
                    npgSqlDBManager.Open();
                    npgSqlDBManager.BeginTran();

                    if (calenderList.Count() < 1 && date == DateTime.MinValue) 
                    {
                        foreach (var pair in calenderList)
                        {
                            string strSQL = "Insert into public.\"Calender\" VALUES( "
                                + pair.Id + " , " + pair.Income + " , " 
                                + pair.Spending + " , " + pair.CreateDate + " , "
                                + pair.UserId + ")";

                            npgSqlDBManager.ExecuteNonQuery(strSQL);
                        }
                    }
                    else
                    {
                        foreach (var pair in calenderList)
                        {
                            string strSQL = "Update public.\"Calender\" set \"Income\" = " + pair.Income
                                + ", \"Spending\" = " + pair.Spending
                                + " where \"Id\" = " + pair.Id 
                                + " and \"Create_Date\" = '" + date.ToString("yyyy/MM/dd") + "'"
                                + " and \"UserId\" = " + pair.UserId;

                            npgSqlDBManager.ExecuteNonQuery(strSQL);
                        }
                    }
                    npgSqlDBManager.CommitTran();
                }
                catch//(Npgsql.NpgsqlException e)
                {
                    npgSqlDBManager.RollBack();
                    npgSqlDBManager.Close();
                    //string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.CALENDER_MESSAGE2);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 最新版のカレンダー情報か判定
        /// </summary>
        /// <param name="calenderLst">カレンダーリスト</param>
        /// <param name="dataLst">収入と支出リスト</param>
        /// <returns>最新データかどうか</returns>
        public static bool IsNewCalenderData(List<Calender> calenderLst, List<int[]> dataLst)
        {
            try
            {
                if(calenderLst.Count() != dataLst[0].Count()) { return false; }
                if(calenderLst.Count() != dataLst[1].Count()) { return false; }

                for(int i = 0; i < calenderLst.Count; i++)
                {
                    if(calenderLst[i].Income != dataLst[0][i]) { return false; }
                    if(calenderLst[i].Spending != dataLst[1][i]) { return false; }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                OriginMBox.MBoxErrorOK(AppConst.CALENDER_MESSAGE2);
                return false;
            }

            return true;
        }

        #endregion

    }
}
