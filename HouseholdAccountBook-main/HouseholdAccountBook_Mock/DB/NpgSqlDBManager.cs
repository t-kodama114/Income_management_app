using System;
using System.Data;
using System.Collections.Generic;
using Npgsql;

namespace HouseholdAccountBook_Mock.DB
{
    public class NpgSqlDBManager : IDisposable
    {
        #region メンバー

        NpgsqlConnection npgsqlConnection;
        NpgsqlTransaction npgsqlTransaction;

        #endregion

        public NpgSqlDBManager()
        {
            if (npgsqlConnection != null)
            {
                npgsqlConnection.Close();
                npgsqlConnection.Dispose();
            }

            //接続文字列
            string connectStr = AppConst.CONNECT_STRING_TEST;

            // SqlConnection の新しいインスタンスを生成 (接続文字列を指定)
            npgsqlConnection = new NpgsqlConnection(connectStr);
        }

        public void Dispose()
        {
            if(npgsqlConnection != null && npgsqlTransaction != null)
            {
                npgsqlConnection.Close();
                npgsqlTransaction.Dispose();
            }
        }

        /// <summary>
        /// DB接続
        /// </summary>
        public void Open()
        {
            npgsqlConnection.Open();
        }

        /// <summary>
        /// DB切断
        /// </summary>
        public void Close()
        {
            npgsqlConnection.Close();
            npgsqlConnection.Dispose();
        }

        /// <summary>
        /// トランザクション開始
        /// </summary>
        public void BeginTran()
        {
            npgsqlTransaction = npgsqlConnection.BeginTransaction();
        }

        /// <summary>
        /// トランザクション　コミット
        /// </summary>
        public void CommitTran()
        {
            if (npgsqlTransaction.Connection != null)
            {
                npgsqlTransaction.Commit();
            }
        }

        /// <summary>
        /// トランザクション　ロールバック
        /// </summary>
        public void RollBack()
        {
            if (npgsqlTransaction.Connection != null)
            {
                npgsqlTransaction.Rollback();
                npgsqlTransaction.Dispose();
            }
        }

        /// <summary>
        /// クエリー実行(OUTPUT項目あり)
        /// <para name="query">SQL文</para>
        /// <para name="paramDict">SQLパラメータ</para>
        /// </summary>
        public NpgsqlDataReader ExecuteQuery(string query, Dictionary<string, Object> paramDict)
        {
            NpgsqlCommand sqlCom = new NpgsqlCommand();

            //クエリー送信先、トランザクションの指定
            sqlCom.Connection = npgsqlConnection;
            sqlCom.Transaction = npgsqlTransaction;

            sqlCom.CommandText = query;
            //パラメータ設定
            foreach (KeyValuePair<string, Object> item in paramDict)
            {
                sqlCom.Parameters.Add(new NpgsqlParameter(item.Key, item.Value));
            }

            // SQLを実行
            NpgsqlDataReader reader = sqlCom.ExecuteReader();

            return reader;
        }

        /// <summary>
        /// クエリー実行(OUTPUT項目あり)
        /// <para name="query">SQL文</para>
        /// <para name="paramDict">SQLパラメータ</para>
        /// </summary>
        public NpgsqlDataReader ExecuteQuery(string query, List<NpgsqlParameter> sqlParamList)
        {
            NpgsqlCommand sqlCom = new NpgsqlCommand();

            //クエリー送信先、トランザクションの指定
            sqlCom.Connection = npgsqlConnection;
            sqlCom.Transaction = npgsqlTransaction;

            sqlCom.CommandText = query;
            //パラメータ設定
            foreach (NpgsqlParameter item in sqlParamList)
            {
                sqlCom.Parameters.Add(item);
            }

            // SQLを実行
            NpgsqlDataReader reader = sqlCom.ExecuteReader();

            return reader;
        }

        /// <summary>
        /// クエリー実行(OUTPUT項目あり)
        /// <para name="query">SQL文</para>
        /// </summary>
        public NpgsqlDataReader ExecuteQuery(string query)
        {
            return this.ExecuteQuery(query, new Dictionary<string, Object>());
        }

        /// <summary>
        /// クエリー実行(データセットを取得)
        /// </summary>
        /// <returns>家計簿ベースのデータ</returns>
        public DataSet GetDataSet(string sql)
        {
            // DataAdapterを利用したSELECT
            NpgsqlCommand sqlCom = new NpgsqlCommand();
            
            sqlCom.Connection = npgsqlConnection;
            sqlCom.Transaction = npgsqlTransaction;
            sqlCom.CommandText = sql;

            var dataAdapter = new NpgsqlDataAdapter(sqlCom);

            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            return dataSet;
        }

        /// <summary>
        /// クエリー実行(OUTPUT項目なし)
        /// <para name="query">SQL文</para>
        /// <para name="paramDict">SQLパラメータ</para>
        /// </summary>
        public void ExecuteNonQuery(string query)
        {
            NpgsqlCommand sqlCom = new NpgsqlCommand();

            //クエリー送信先、トランザクションの指定
            sqlCom.Connection = npgsqlConnection;
            sqlCom.Transaction = npgsqlTransaction;

            sqlCom.CommandText = query;

            // SQLを実行
            sqlCom.ExecuteNonQuery();
        }

        /// <summary>
        /// クエリー実行(OUTPUT項目なし)
        /// <para name="query">SQL文</para>
        /// <para name="paramDict">SQLパラメータ</para>
        /// </summary>
        public void ExecuteNonQuery(string query, Dictionary<string, Object> paramDict)
        {
            NpgsqlCommand sqlCom = new NpgsqlCommand();

            //クエリー送信先、トランザクションの指定
            sqlCom.Connection = npgsqlConnection;
            sqlCom.Transaction = npgsqlTransaction;

            sqlCom.CommandText = query;
            //パラメータ設定
            foreach (KeyValuePair<string, Object> item in paramDict)
            {
                sqlCom.Parameters.Add(new NpgsqlParameter(item.Key, item.Value));
            }

            // SQLを実行
            sqlCom.ExecuteNonQuery();
        }

        /// <summary>
        /// クエリー実行(OUTPUT項目なし)
        /// <para name="query">SQL文</para>
        /// <para name="paramDict">SQLパラメータ</para>
        /// </summary>
        public void ExecuteNonQuery(string query, List<NpgsqlParameter> sqlParamList)
        {
            NpgsqlCommand sqlCom = new NpgsqlCommand();

            //クエリー送信先、トランザクションの指定
            sqlCom.Connection = npgsqlConnection;
            sqlCom.Transaction = npgsqlTransaction;

            sqlCom.CommandText = query;
            //パラメータ設定
            foreach (NpgsqlParameter item in sqlParamList)
            {
                sqlCom.Parameters.Add(item);
            }

            // SQLを実行
            sqlCom.ExecuteNonQuery();
        }
    }
}
