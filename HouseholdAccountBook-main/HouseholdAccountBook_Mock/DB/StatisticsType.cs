using System;
using System.Collections.Generic;
using System.Data;
using HouseholdAccountBook_Mock.MBox;

namespace HouseholdAccountBook_Mock.DB
{
    /// <summary>
    /// 統計の分類タイプのマスタデータ
    /// </summary>
    public class StatisticsType
    {
        #region 定数

        private const string ID_STR = "id";
        private const string CLASSIFICATION_STR = "Classification";
        private const string USERID_STR = "userId";

        #endregion

        #region コンストラクタ

        public StatisticsType() { }

        public StatisticsType(DataRow dr)
        {
            InitDataRow(dr);
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// ID(収入:0か支出:1)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 分類
        /// </summary>
        public string Classification { get; set; }

        /// <summary>
        /// ユーザーID
        /// </summary>
        public int UserId { get; set; }

        #endregion

        #region メソッド

        /// <summary>
        /// 分類マスタデータ情報登録
        /// </summary>
        /// <param name="dr">列データ</param>
        public void InitDataRow(DataRow dr)
        {
            Id = int.Parse(dr[ID_STR].ToString());
            Classification = dr[CLASSIFICATION_STR].ToString();
            UserId = int.Parse(dr[USERID_STR].ToString());
        }

        /// <summary>
        /// 分類マスタデータリスト取得
        /// </summary>
        /// <param name="_id">資産ID</param>
        /// <returns>分類マスタデータリスト取得</returns>
        public static List<StatisticsType> SelectStatisticsTypeList(int _id, int userId)
        {
            List<StatisticsType> statisticsTypeList = new List<StatisticsType>();

            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    string sql = "select * from public.\"StatisticsType\" where \"id\" = " 
                        + _id + " and \"userId\" = " + userId;

                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];
                    if (table.Rows.Count < 1) { return null; }

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        StatisticsType statisticsData = new StatisticsType(table.Rows[i]);
                        statisticsTypeList.Add(statisticsData);
                    }
                }
                catch
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    OriginMBox.MBoxErrorOK(AppConst.STATISTICS_MESSAGE);
                    return null;
                }
            }
            return statisticsTypeList;
        }

        /// <summary>
        /// 分類ごとの金額のデータテーブル取得
        /// </summary>
        /// <param name="householdABookList">家計簿ベースデータ</param>
        /// <returns>分類ごとの金額のデータテーブル取得</returns>
        public static Dictionary<string, int> GetMoneysParam(List<HouseholdABookBase.HouseholdABook> householdABookList, int userId)
        {
            Dictionary<string, int> moneyPairs = new Dictionary<string, int>();
            try
            {
                int id = householdABookList[0].idStr == 
                    AppConst.INCOME ? AppConst.INCOME_VALUE : AppConst.SPENDING_VALUE;

                var typeList = SelectStatisticsTypeList(id, userId);
                if (!IsStatisticsType(typeList, out moneyPairs)) { return new Dictionary<string, int>(); }

                for (int i = 0; i < householdABookList.Count; i++)
                {
                    var data = householdABookList[i];
                    string classification = data.classification;
                    
                    //データ登録
                    if (id == 0)
                    {
                        if (moneyPairs.ContainsKey(classification))
                        {
                            moneyPairs[classification] += data.money;
                        }
                    }
                    else
                    {
                        if (moneyPairs.ContainsKey(classification))
                        {
                            moneyPairs[classification] += data.money;
                        }
                    }
                }
                return moneyPairs;
            }
            catch(Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.STATISTICSTYPE_MESSAGE);
                return null;
            }
        }

        /// <summary>
        /// 統計確認データマスタにデータが存在するか確認
        /// </summary>
        /// <param name="typeList">統計確認データマスタ</param>
        /// <param name="moneyPairs">分類ごとの金額のデータテーブル</param>
        /// <returns>統計確認データマスタにデータが存在するか確認</returns>
        public static bool IsStatisticsType(List<StatisticsType> typeList, out Dictionary<string, int> moneyPairs)
        {
            try
            {
                if(typeList.Count < 0) 
                {
                    moneyPairs = new Dictionary<string, int>();
                    return false; 
                }

                int id = typeList[0].Id;
                moneyPairs = new Dictionary<string, int>();
                
                //データ初期化
                for (int i = 0; i < typeList.Count; i++)
                {
                    var data = typeList[i];
                    if (!moneyPairs.ContainsKey(data.Classification))
                    {
                        moneyPairs.Add(data.Classification, 0);
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.STATISTICSTYPE_MESSAGE);
                moneyPairs = new Dictionary<string, int>();
                return false;
            }
        }

        #endregion
    }
}
