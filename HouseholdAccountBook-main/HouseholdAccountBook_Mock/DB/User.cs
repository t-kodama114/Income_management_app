using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;
using HouseholdAccountBook_Mock.MBox;

namespace HouseholdAccountBook_Mock.DB
{
    /// <summary>
    /// ユーザー情報
    /// </summary>
    public class User
    {
        #region 定数

        private const string ID_STR = "Id";
        private const string CREATEDATE_STR = "CreateDate";
        private const string USERNAME_STR = "UserName";
        private const string USERNAME_KANA_STR = "UserNameKana";
        private const string PASSWORD_STR = "Password";
        private const string ISONCE_STR = "IsOnce";
        private const string SALT_STR = "Salt";

        #endregion

        #region コンストラクタ

        public User() { }

        public User(DataRow dr)
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
        /// ユーザー名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ユーザー名カナ
        /// </summary>
        public string UserNameKana { get; set; }

        /// <summary>
        /// パスワード（ハッシュ値）
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 一度ログインしたら、ログイン画面を出さないか（オートログイン）
        /// true：ログイン画面表示しない
        /// false：ログイン画面表示する
        /// </summary>
        public bool IsOnce { get; set; }

        /// <summary>
        /// ソルト
        /// </summary>
        public string Salt { get; set; }

        #endregion

        #region メソッド

        public void InitDataRow(DataRow dr)
        {
            Id = int.Parse(dr[ID_STR].ToString());
            CreateDate = DateTime.Parse(dr[CREATEDATE_STR].ToString());
            UserName = dr[USERNAME_STR].ToString();
            UserNameKana = dr[USERNAME_KANA_STR].ToString();
            Password = dr[PASSWORD_STR].ToString();
            IsOnce = bool.Parse(dr[ISONCE_STR].ToString());
            Salt = dr[SALT_STR].ToString();
        }

        /// <summary>
        /// ログイン中のユーザー情報を取得(IDから)
        /// </summary>
        /// <param name="_id">ユーザーID</param>
        /// <returns>ユーザー情報</returns>
        public static User SelectUserFromId(int _id)
        {
            using(NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                User user = null;
                try
                {
                    string sql = "select * from public.\"User\" where \"Id\" = " + _id;

                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];
                    if (table.Rows.Count < 1) { return null; }

                    user = new User(table.Rows[0]);
                }
                catch(Exception e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.USER_ERROR_MESSAGE);
                    return null;
                }
                return user;
            }
        }

        /// <summary>
        /// パスワードからユーザー情報を取得
        /// </summary>
        /// <param name="HashPassword">パスワード</param>
        /// <returns>ユーザー情報</returns>
        public static User SelectUserFromPassword(string HashPassword)
        {
            User user = null;
            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    string sql = "select * from public.\"User\" where \"Password\" = " + HashPassword;

                    DataSet dataSet = dBManager.GetDataSet(sql);
                    DataTable table = dataSet.Tables[0];
                    if (table.Rows.Count < 1) { return null; }

                    user = new User(table.Rows[0]);
                }
                catch(Exception ex)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = ex.Message;
                    OriginMBox.MBoxErrorOK(AppConst.USER_ERROR_MESSAGE02);
                    return null;
                }
            }
            return user;
        }

        /// <summary>
        /// 新規ユーザー情報作成
        /// </summary>
        /// <param name="userName">ユーザー名</param>
        /// <param name="userNameKana">ユーザー名カナ</param>
        /// <param name="hashPassword">パスワード</param>
        /// <param name="isOnce">オートログイン有り無し</param>
        /// <param name="salt">ソルト</param>
        /// <returns></returns>
        public static User InsertUser(string userName, string userNameKana, string hashPassword, bool isOnce, string salt)
        {
            int id = 1;
            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    string sql = "SELECT MAX(\"Id\") AS max FROM public.\"User\"";

                    dBManager.Open();
                    dBManager.BeginTran();

                    using(NpgsqlDataReader reader = dBManager.ExecuteQuery(sql))
                    {
                        while (reader.Read())
                        {
                            if (string.IsNullOrEmpty(reader["max"].ToString())) break;
                            id = int.Parse(reader["max"].ToString()) + 1;
                        }
                    }

                    sql = "";
                    sql = "INSERT INTO public.\"User\" "
                                            + "VALUES(" + id + ", "
                                            + "'" + DateTime.Now.ToString() + "', "
                                            + "'" + userName + "', "
                                            + "'" + userNameKana + "', "
                                            + "'" + hashPassword + "', " 
                                            + isOnce + ", "
                                            + "'" + salt + "')";

                    dBManager.ExecuteNonQuery(sql);
                    dBManager.CommitTran();
                }
                catch(Exception e)
                {
                    dBManager.RollBack();
                    dBManager.Close();
                    string s = e.Message;
                    OriginMBox.MBoxErrorOK(AppConst.USER_MESSAGE);
                    return null;
                }
            }

            // 作成したユーザー情報取得
            User user = SelectUserFromId(id);
            return user;
        }

        /// <summary>
        /// パスワード更新
        /// </summary>
        /// <param name="_id">ID</param>
        /// <param name="userName">ユーザー名</param>
        /// <param name="password">ハッシュパスワード</param>
        /// <param name="salt">ソルト</param>
        /// <returns>ユーザー情報</returns>
        public static User UpdatePasswordAndSalt(int _id, string password, string salt)
        {
            using (NpgSqlDBManager dBManager = new NpgSqlDBManager())
            {
                try
                {
                    string sql = "UPDATE public.\"User\" "
                                        + "SET \"Password\" = '" + password + "', "
                                        + "\"Salt\" = '" + salt + "'"
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
            User user = SelectUserFromId(_id);
            return user;
        }

        #endregion
    }
}
