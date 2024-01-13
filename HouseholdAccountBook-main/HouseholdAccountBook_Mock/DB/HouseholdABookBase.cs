using System;
using System.Collections.Generic;
using HouseholdAccountBook_Mock.MBox;
using System.Data;
using Npgsql;

namespace HouseholdAccountBook_Mock.DB
{
    /// <summary>
    /// 家計簿ベースデータテーブル
    /// </summary>
    public class HouseholdABookBase
    {
        #region 定数

        //ベースDBのカラム文字列(HouseholdABookBase)
        public const string ID_STR = "data_id";
        public const string CREATEDATE_STR = "creation_datetime";
        public const string ASSETS_STR = "assets";
        public const string CLASSIFICATION_STR = "classifcation";
        public const string MONEY_STR = "amountofmoney";
        public const string CONTENT_STR = "description";
        public const string USERID_STR = "userId";

        #endregion

        #region クラス

        /// <summary>
        /// 家計簿のベースデータ
        /// </summary>
        public class HouseholdABook
        {
            public string idStr;
            public DateTime createDate;
            public string assets;
            public string classification;
            public int money;
            public string content;

            public HouseholdABook() { }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="id">ID</param>
            /// <param name="date">作成日時</param>
            /// <param name="assets">資産</param>
            /// <param name="classification">分類</param>
            /// <param name="money">金額</param>
            /// <param name="content">説明</param>
            public HouseholdABook(string id, DateTime date, string assets, string classification, int money, string content)
            {
                idStr = id;
                createDate = date;
                this.assets = assets;
                this.classification = classification;
                this.money = money;
                this.content = content;
            }

            /// <summary>
            /// 日時ごとの収入と支出表示用
            /// </summary>
            /// <returns></returns>
            public string[] GetHouseholdABookList()
            {
                return new string[]
                {
                    createDate.Date.ToString("yyyy年MM月dd日"), classification, content, string.Format("￥{0:#,0}", money)
                };
            }
        }

        #endregion

        #region プロパティ

        #endregion

        #region コンストラクタ

        public HouseholdABookBase()
        {
            
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 家計簿のベースデータ取得(リスト取得)
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        public static List<HouseholdABook> SelectHouseholdABookBase(int userId)
        {
            List<HouseholdABook> householdsList = new List<HouseholdABook>();

            using(NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    dBManager.Open();
                    dBManager.BeginTran();

                    //SQL文
                    string sql = "select * from public.\"householdabookbase\" where \"userId\" = " + userId;
                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];
                    for(int i = 0; i < table.Rows.Count; i++)
                    {
                        HouseholdABook household = new HouseholdABook
                        {
                            idStr = table.Rows[i][ID_STR].ToString() == "0" ? AppConst.INCOME : AppConst.SPENDING ,
                            assets = table.Rows[i][ASSETS_STR].ToString(),
                            createDate = DateTime.Parse(table.Rows[i][CREATEDATE_STR].ToString()),
                            classification = table.Rows[i][CLASSIFICATION_STR].ToString(),
                            money = int.Parse(table.Rows[i][MONEY_STR].ToString()),
                            content = table.Rows[i][CONTENT_STR].ToString()
                        };

                        householdsList.Add(household);
                    }

                    return householdsList;
                }
                catch//(Npgsql.NpgsqlException e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    //string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.BASEDATA_MESSAGE);
                    return null;
                }
            }
        }

        /// <summary>
        /// 家計簿のベースデータを期間指定取得(リスト取得)
        /// </summary>
        public static List<HouseholdABook> SelectHouseholdABookBase(DateTime start, DateTime end, int userId)
        {
            List<HouseholdABook> householdsList = new List<HouseholdABook>();

            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    dBManager.Open();
                    dBManager.BeginTran();

                    //SQL文
                    string sql = "select * from public.\"householdabookbase\" "
                        + " where \"creation_datetime\" >= '" + start.ToString("yyyy/MM/dd") + "'"
                        + " and \"creation_datetime\" < '" + end.ToString("yyyy/MM/dd") + "'"
                        + " and \"userId\" = "+ userId;
                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        HouseholdABook household = new HouseholdABook
                        {
                            idStr = table.Rows[i][ID_STR].ToString() == "0" ? AppConst.INCOME : AppConst.SPENDING,
                            assets = table.Rows[i][ASSETS_STR].ToString(),
                            createDate = DateTime.Parse(table.Rows[i][CREATEDATE_STR].ToString()),
                            classification = table.Rows[i][CLASSIFICATION_STR].ToString(),
                            money = int.Parse(table.Rows[i][MONEY_STR].ToString()),
                            content = table.Rows[i][CONTENT_STR].ToString()
                        };

                        householdsList.Add(household);
                    }

                    return householdsList;
                }
                catch//(Npgsql.NpgsqlException e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    //string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.BASEDATA_MESSAGE);
                    return null;
                }
            }
        }

        /// <summary>
        /// 家計簿のベースデータを期間指定取得(リスト取得)
        /// </summary>
        public static List<HouseholdABook> SelectHouseholdABookBase(int id, DateTime start, DateTime end, int userId)
        {
            List<HouseholdABook> householdsList = new List<HouseholdABook>();

            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    dBManager.Open();
                    dBManager.BeginTran();

                    //SQL文
                    string sql = "select * from public.householdabookbase"
                        + " where data_id = " + id
                        + " and creation_datetime >= '" + start.ToString("yyyy/MM/dd") + "'"
                        + " and creation_datetime < '" + end.ToString("yyyy/MM/dd") + "'"
                        + " and \"userId\" = " + userId;
                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        HouseholdABook household = new HouseholdABook
                        {
                            idStr = table.Rows[i][ID_STR].ToString() == "0" ? AppConst.INCOME : AppConst.SPENDING,
                            assets = table.Rows[i][ASSETS_STR].ToString(),
                            createDate = DateTime.Parse(table.Rows[i][CREATEDATE_STR].ToString()),
                            classification = table.Rows[i][CLASSIFICATION_STR].ToString(),
                            money = int.Parse(table.Rows[i][MONEY_STR].ToString()),
                            content = table.Rows[i][CONTENT_STR].ToString()
                        };

                        householdsList.Add(household);
                    }

                    return householdsList;
                }
                catch
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.BASEDATA_MESSAGE);
                    return null;
                }
            }
        }

        /// <summary>
        /// 家計簿のベースデータ新規登録
        /// </summary>
        /// <returns></returns>
        public static bool InsertHouseholdABookBase(int id, DateTime date, string assets, string classifcation, int money, string content, int userId)
        {
            using (NpgSqlDBManager npgSqlDBManager = new NpgSqlDBManager())
            {
                try
                {
                    //SQL文
                    string sql = "INSERT INTO \"householdabookbase\" VALUES("
                        + id + ",CAST('" + date.ToString() + "' AS TIMESTAMP),'"
                        + assets + "','" +classifcation + "'," + money + ",'" + content +",'" + userId + "')";

                    npgSqlDBManager.Open();
                    npgSqlDBManager.BeginTran();

                    npgSqlDBManager.ExecuteNonQuery(sql);
                    
                    npgSqlDBManager.CommitTran();
                }
                catch
                {
                    npgSqlDBManager.RollBack();
                    npgSqlDBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.NEWDATA_MESSAGE);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 期間指定なしの収入と支出と合計の取得
        /// </summary>
        /// <returns></returns>
        public static List<int> SelectPropManageList(int userId)
        {
            List<int> propList = new List<int>();

            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    //収入
                    string sql = "select SUM(\"amountofmoney\") AS Total from public.\"householdabookbase\" where \"householdabookbase\".data_id = 0"
                        + " and \"userId\" = " + userId;

                    dBManager.Open();
                    dBManager.BeginTran();

                    NpgsqlDataReader reader = dBManager.ExecuteQuery(sql);
                    int total = 0;
                    while (reader.Read())
                    {
                        total = int.Parse(reader["Total"].ToString());
                        propList.Add(total);
                    }

                    reader.Close();

                    //支出
                    sql = "select SUM(\"amountofmoney\") AS Total2 from public.\"householdabookbase\" where \"householdabookbase\".data_id = 1"
                        + " and \"userId\" = " + userId;

                    reader = dBManager.ExecuteQuery(sql);
                    int total2 = 0;
                    while (reader.Read())
                    {
                        total2 = int.Parse(reader["Total2"].ToString());
                        propList.Add(total2);
                    }

                    reader.Close();

                    //合計
                    int sum = total - total2;
                    propList.Add(sum);

                    return propList;
                }
                catch//(NpgsqlException e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    //string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.NEWDATA_MESSAGE);
                    return null;
                }
            }
        }

        /// <summary>
        /// 期間ごとの収入と支出と合計の取得(上限日時(end)はStartの1ヶ月)
        /// </summary>
        /// <returns></returns>
        public static List<int> SelectPropManageList(DateTime start, DateTime end, int userId)
        {
            List<int> propList = new List<int>();

            using(NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    //収入
                    string sql = "select SUM(\"amountofmoney\") AS Total "
                        + "from public.\"householdabookbase\" where \"householdabookbase\".data_id = 0 "
                        + "and \"householdabookbase\".creation_datetime >= CAST('" + start.ToString() + "' AS TIMESTAMP) "
                        + "and \"householdabookbase\".creation_datetime < CAST('" + end.ToString() + "' AS TIMESTAMP)"
                        + "and \"userId\" = " + userId;

                    dBManager.Open();
                    dBManager.BeginTran();

                    NpgsqlDataReader reader = dBManager.ExecuteQuery(sql);
                    int total = 0;
                    while (reader.Read())
                    {
                        if(!int.TryParse(reader["Total"].ToString(), out total))
                        {
                            total = 0;
                        }
                        propList.Add(total);
                    }

                    reader.Close();

                    //支出
                    sql = "select SUM(\"amountofmoney\") AS Total2 "
                        + "from public.\"householdabookbase\" where \"householdabookbase\".data_id = 1 "
                        + "and \"householdabookbase\".creation_datetime >= CAST('" + start.ToString() + "' AS TIMESTAMP) "
                        + "and \"householdabookbase\".creation_datetime < CAST('" + end.ToString() + "' AS TIMESTAMP)"
                        + "and \"userId\" = " + userId;

                    reader = dBManager.ExecuteQuery(sql);
                    int total2 = 0;
                    while (reader.Read())
                    {
                        if (!int.TryParse(reader["Total2"].ToString(), out total2))
                        {
                            total2 = 0;
                        }
                        
                        propList.Add(total2);
                    }

                    reader.Close();

                    //合計
                    int sum = total - total2;
                    propList.Add(sum);

                    return propList;
                }
                catch(NpgsqlException ex)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = ex.Message;
                    OriginMBox.MBoxErrorOK(AppConst.BASEDATA_MESSAGE);
                    return null;
                }
            }
        }

        /// <summary>
        /// 収入と支出の取得(週ごとのデータ)
        /// </summary>
        /// <returns></returns>
        public static List<int[]> SelectHouseholdABooks(DateTime start, DateTime end, int userId)
        {
            List<int[]> propList = new List<int[]>();

            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    //収入
                    string sql = "select * "
                        + "from public.\"householdabookbase\" where \"householdabookbase\".data_id = 0 "
                        + "and \"householdabookbase\".creation_datetime >= CAST('" + start.ToString() + "' AS TIMESTAMP) "
                        + "and \"householdabookbase\".creation_datetime < CAST('" + end.ToString() + "' AS TIMESTAMP)"
                        + "and \"userId\" = " + userId;

                    dBManager.Open();
                    dBManager.BeginTran();

                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];
                    int dataCount = end.AddDays(-1).Day;
                    int[] incomeBooks = new int[dataCount];

                    int count = 0;
                    for(int i = 0; i < dataCount; i++)
                    {
                        if(table.Rows.Count == 0) { break; }
                        if(table.Rows.Count <= count) { count = table.Rows.Count - 1; }
                        if (table.Rows[count] == null) { continue; }
                        string dateStr = table.Rows[count]["creation_datetime"].ToString();
                        DateTime time = DateTime.Parse(dateStr);

                        if (i == time.Day - 1)
                        {
                            incomeBooks[i] = int.Parse(table.Rows[count]["amountofmoney"].ToString());
                            count++;
                        }
                    }

                    //支出
                    sql = "select * "
                        + "from public.\"householdabookbase\" where \"householdabookbase\".data_id = 1 "
                        + "and \"householdabookbase\".creation_datetime >= CAST('" + start.ToString() + "' AS TIMESTAMP) "
                        + "and \"householdabookbase\".creation_datetime < CAST('" + end.ToString() + "' AS TIMESTAMP)"
                        + "and \"userId\" = " + userId;

                    dataSet = dBManager.GetDataSet(sql);
                    table = dataSet.Tables[0];
                    int[] spendingBooks = new int[dataCount];

                    count = 0;
                    for (int i = 0; i < dataCount; i++)
                    {
                        if (table.Rows.Count == 0) { break; }
                        if (table.Rows.Count <= count) { count = table.Rows.Count - 1; }
                        if (table.Rows[count] == null) { continue; }
                        string dateStr = table.Rows[count]["creation_datetime"].ToString();
                        DateTime time = DateTime.Parse(dateStr);

                        if (i == time.Day - 1)
                        {
                            spendingBooks[i] = int.Parse(table.Rows[count]["amountofmoney"].ToString());
                            count++;
                        }
                    }
                    propList.Add(incomeBooks);
                    propList.Add(spendingBooks);

                    return propList;
                }
                catch (NpgsqlException e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.BASEDATA_MESSAGE);
                    return null;
                }
            }
        }

        /// <summary>
        /// 収入と支出の取得(月ごとのデータ)
        /// </summary>
        /// <returns></returns>
        public static List<int[]> SelectMonthDatasCreate(DateTime start, DateTime end, int userId)
        {
            List<int[]> propList = new List<int[]>();

            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    int dataCount = end.Month;
                    int[] incomeBooks = new int[dataCount];
                    int[] spendingBooks = new int[dataCount];
                    DateTime date = start;
                    DateTime nextDate = start.AddMonths(1);

                    dBManager.Open();
                    dBManager.BeginTran();

                    //収入
                    for (int i = 0; i < dataCount; i++)
                    {   
                        string sql = "select * "
                            + "from public.\"householdabookbase\" where \"householdabookbase\".data_id = 0 "
                            + "and \"householdabookbase\".creation_datetime >= CAST('" + date.ToString() + "' AS TIMESTAMP) "
                            + "and \"householdabookbase\".creation_datetime < CAST('" + nextDate.ToString() + "' AS TIMESTAMP) "
                            + "and \"userId\" = " + userId;

                        DataSet dataSet = dBManager.GetDataSet(sql);
                        DataTable table = dataSet.Tables[0];

                        int data = 0;
                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            data += int.Parse(table.Rows[j][MONEY_STR].ToString());
                        }

                        incomeBooks[i] = data;

                        date = nextDate;
                        nextDate = nextDate.AddMonths(1);
                    }

                    date = start;
                    nextDate = start.AddMonths(1);

                    //支出
                    for(int i = 0; i < dataCount; i++)
                    {
                        string sql = "select * "
                        + "from public.\"householdabookbase\" where \"householdabookbase\".data_id = 1 "
                        + "and \"householdabookbase\".creation_datetime >= CAST('" + date.ToString() + "' AS TIMESTAMP) "
                        + "and \"householdabookbase\".creation_datetime < CAST('" + nextDate.ToString() + "' AS TIMESTAMP) "
                        + "and \"userId\" = " + userId;

                        DataSet dataSet = dBManager.GetDataSet(sql);
                        DataTable table = dataSet.Tables[0];
                        
                        int data = 0;
                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            data += int.Parse(table.Rows[j][MONEY_STR].ToString());
                        }

                        spendingBooks[i] = data;

                        date = nextDate;
                        nextDate = nextDate.AddMonths(1);
                    }
                    
                    propList.Add(incomeBooks);
                    propList.Add(spendingBooks);

                    return propList;
                }
                catch (NpgsqlException e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.BASEDATA_MESSAGE);
                    return null;
                }
            }
        }

        /// <summary>
        /// HouseholdABookBaseテーブルのカラム設定と値設定
        /// </summary>
        /// <param name="id">収入か支出かフラグ</param>
        /// <param name="date">作成日</param>
        /// <param name="assets">資産</param>
        /// <param name="classifcation">分類</param>
        /// <param name="money">金額</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        private static List<NpgsqlParameter> GetListValues(int id, DateTime date, string assets, string classifcation, int money, string content)
        {
            List<NpgsqlParameter> allParamList = new List<NpgsqlParameter>();

            NpgsqlParameter p1 = new NpgsqlParameter(ID_STR, DbType.Int16);
            p1.Value = id;
            allParamList.Add(p1);

            NpgsqlParameter p2 = new NpgsqlParameter(CREATEDATE_STR, DbType.DateTime);
            p2.Value = date;
            allParamList.Add(p2);

            NpgsqlParameter p3 = new NpgsqlParameter(ASSETS_STR, DbType.String);
            p3.Value = assets;
            allParamList.Add(p3);

            NpgsqlParameter p4 = new NpgsqlParameter(CLASSIFICATION_STR, DbType.String);
            p4.Value = classifcation;
            allParamList.Add(p4);

            NpgsqlParameter p5 = new NpgsqlParameter(MONEY_STR, DbType.Int32);
            p5.Value = money;
            allParamList.Add(p5);

            NpgsqlParameter p6 = new NpgsqlParameter(CONTENT_STR, DbType.String);
            p6.Value = content;
            allParamList.Add(p6);

            return allParamList;
        }

        /// <summary>
        /// HouseholdABookBaseテーブルのカラム設定と値設定
        /// </summary>
        /// <param name="id">収入か支出かフラグ</param>
        /// <param name="time">作成日</param>
        /// <param name="assets">資産</param>
        /// <param name="classifcation">分類</param>
        /// <param name="money">金額</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        private static Dictionary<string, Object> GetBaseDataParamValues()
        {
            Dictionary<string, Object> allParamValues = new Dictionary<string, Object>();

            NpgsqlParameter p1 = new NpgsqlParameter(ID_STR, DbType.Int32);
            allParamValues.Add(ID_STR, p1.DbType);

            NpgsqlParameter p2 = new NpgsqlParameter(CREATEDATE_STR, DbType.DateTime);
            allParamValues.Add(CREATEDATE_STR, p2.DbType);

            NpgsqlParameter p3 = new NpgsqlParameter(ASSETS_STR, DbType.String);
            allParamValues.Add(ASSETS_STR, p3.DbType);

            NpgsqlParameter p4 = new NpgsqlParameter(CLASSIFICATION_STR, DbType.String);
            allParamValues.Add(CLASSIFICATION_STR, p4.DbType);

            NpgsqlParameter p5 = new NpgsqlParameter(MONEY_STR, DbType.Int32);
            allParamValues.Add(MONEY_STR, p5.DbType);

            NpgsqlParameter p6 = new NpgsqlParameter(CONTENT_STR, DbType.String);
            allParamValues.Add(CONTENT_STR, p6.DbType);

            return allParamValues;
        }

        #endregion

    }
}
