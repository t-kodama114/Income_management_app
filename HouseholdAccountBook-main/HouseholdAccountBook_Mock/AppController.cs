using System.Windows.Forms;
using HouseholdAccountBook_Mock.User_Control;
using HouseholdAccountBook_Mock.DB;

namespace HouseholdAccountBook_Mock
{
    /// <summary>
    /// アプリ管理オブジェクト
    /// </summary>
    public class AppController
    {
        #region メンバー変数

        /// <summary>
        /// ユーザー情報(ログイン画面またはパスワード入力画面から取得)
        /// </summary>
        public User User;

        /// <summary>
        /// 家計簿入力オブジェクト
        /// </summary>
        private UCBreakdown m_UcBreakdown;

        /// <summary>
        /// 統計確認オブジェクト
        /// </summary>
        private UCStatistics m_UcStatistcs;

        /// <summary>
        /// 資産確認オブジェクト
        /// </summary>
        private UCAssets m_UcAssets;

        /// <summary>
        /// 設定確認オブジェクト
        /// </summary>
        private UCConfiguration m_UcConfiguration;

        #endregion 

        #region Enum

        /// <summary>
        /// 表示タイプ
        /// </summary>
        public enum DisplayType
        {
            /// <summary>
            /// 家計簿入力
            /// </summary>
            BREAKDOWN = 1,
            /// <summary>
            /// 統計
            /// </summary>
            STATISTICS,
            /// <summary>
            /// 資産
            /// </summary>
            ASSETS,
            /// <summary>
            /// 設定
            /// </summary>
            CONFIGURATION
        }

        #endregion

        /// <summary>
        /// 初期化
        /// </summary>
        public void Init()
        {
            //家計簿入力初期化
            m_UcBreakdown = new UCBreakdown();

            //統計確認初期化
            m_UcStatistcs = new UCStatistics();

            //資産確認初期化
            m_UcAssets = new UCAssets();

            //設定確認初期化
            m_UcConfiguration = new UCConfiguration();
        }

        /// <summary>
        /// リソース解放
        /// </summary>
        public void Dispose()
        {
            m_UcBreakdown.Dispose();
            m_UcBreakdown = null;
            m_UcStatistcs.Dispose();
            m_UcStatistcs = null;
            m_UcAssets.Dispose();
            m_UcAssets = null;
            m_UcConfiguration.Dispose();
            m_UcConfiguration = null;
        }

        /// <summary>
        /// 使用コントロール設定
        /// </summary>
        /// <param name="displayType">表示タイプ</param>
        /// <returns></returns>
        public Control Execute(DisplayType displayType)
        {
            Control con = new Control();
            DisplayType type = displayType;
            switch (type)
            {
                case DisplayType.BREAKDOWN:
                    con = m_UcBreakdown;　//家計簿入力
                    break;
                case DisplayType.STATISTICS:
                    con = m_UcStatistcs;  //統計確認
                    break;
                case DisplayType.ASSETS:
                    con = m_UcAssets;     //資産確認
                    break;
                case DisplayType.CONFIGURATION:
                    con = m_UcConfiguration; //設定確認
                    break;
            }
            return con;
       }
    }
}