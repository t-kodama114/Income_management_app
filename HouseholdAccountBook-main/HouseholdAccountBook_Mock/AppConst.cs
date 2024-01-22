using System.Drawing;
using System.Collections.Generic;
using HouseholdAccountBook_Mock.DB;
using System.Configuration;

namespace HouseholdAccountBook_Mock
{
    /// <summary>
    /// アプリ定数管理オブジェクト
    /// </summary>
    public class AppConst
    {
        //エラーメッセージ一覧
        public const string FORM_MESSAGE = "メイン画面の選定でエラーです。";
        public const string MUTEX_MESSAGE = "多重起動はできません。";
        public const string INI_MESSAGE1 = "設定ファイルがあるかご確認ください。";
        public const string INI_MESSAGE2 = "設定ファイルに内容が記述されていません。";
        public const string NEWDATA_MESSAGE = "新規データ作成に失敗です。";
        public const string MONEY_ERROR_MESSAGE = "金額を入力してください。";
        public const string CALENDER_MESSAGE = "カレンダーのデータ取得に失敗しました。";
        public const string CALENDER_MESSAGE2 = "カレンダーのデータ作成に失敗しました。";
        public const string WEEKDATA_MESSAGE = "週ごとのデータ取得に失敗しました。";
        public const string WEEKDATA_MESSAGE2 = "週ごとのデータ作成に失敗しました。";
        public const string MONTHDATA_MESSAGE = "月ごとのデータ取得に失敗しました。";
        public const string MONTHDATA_MESSAGE2 = "月ごとのデータ作成に失敗しました。";
        public const string LIST_HEADER_MESSAGE = "ヘッダー作成に失敗しています。";
        public const string LIST_ITEM_MESSAGE = "項目作成に失敗しています。";
        public const string BASEDATA_MESSAGE = "家計簿ベースデータの取得に失敗しました。";
        public const string SERIES_MESSAGE = "グラフのデータ作成に失敗しました。";
        public const string STATISTICS_MESSAGE = "グラフ用統計データ取得に失敗しました。";
        public const string STATISTICS_MESSAGE2 = "グラフ用統計データ更新に失敗しました。";
        public const string STATISTICSTYPE_MESSAGE = "統計マスタデータ取得に失敗しました。";
        public const string STATISTICSDATE_MESSAGE = "日付の指定が間違っています。";
        public const string IMAGE_SUCCESS_MESSAGE = "画像作成が完了しました。";
        public const string IMAGE_CANCEL_MESSAGE = "画像作成がキャンセルしました。";
        public const string PDF_INSTALL_MESSAGE = "Acrobat Reader DCはインストールされていますか？";
        public const string PDF_DC_MESSAGE = "PDFをAcrobat Reader DCで開きます。";
        public const string PDF_BROWSER_MESSAGE = "Acrobat Reader DCがインストールされていないため、\nPDFをブラウザで開きます。";
        public const string PDF_ERROR_MESSAGE = "PDF表示に失敗しました。";
        public const string PDF_SUCCESS_MESSAGE = "PDF作成が完了しました。";
        public const string PDF_FAILURE_MESSAGE = "PDF作成に失敗しました。";
        public const string PDF_FAILURE_MESSAGE2 = " PDFファイル名取得に失敗しました。";
        public const string PNG_FAILURE_MESSAGE = " PNGファイル名取得に失敗しました。";
        public const string USER_ERROR_MESSAGE = "ユーザー情報が取得出来ません。";
        public const string USER_ERROR_MESSAGE02 = "ユーザー情報の作成に失敗しました。";
        public const string USER_MESSAGE = "新規ユーザー作成に成功しました。";
        public const string LOGIN_SUCCESS = "ログインに成功しました。";
        public const string LOGIN_ERROR = "ログインに失敗しました。";
        public const string USER_INPUT_ERROR = "ユーザー名を入力してください。";
        public const string PASSWORD_INPUT_ERROR = "パスワードを入力してください。";
        public const string PASSWORD_UPDATE_SUCCESS = "パスワード更新が完了しました。";
        public const string PASSWORD_UPDATE_ERROR = "パスワード更新が失敗しました。";
        public const string PASSWORD_BEFORE_ERROR = "以前のパスワードと同一なため、再入力してください。";
        public const string TOAST_USEFLG_ON = "通知有無の設定がONになっています。";
        public const string TOAST_USEFLG_OFF = "通知有無の設定がOFFになっています。";
        public const string TOAST_SUCCESS = "通知設定が完了しました。";
        public const string TOAST_HOUR_ERR = "時間が設定されていません。\n通知設定してもよろしいですか？";
        public const string TOAST_MINUTE_ERR = "分が設定されていません。\n通知設定してもよろしいですか？";
        public const string TOAST_FINISH = "\n終了しますか？";

        //接続文字列(テスト用)
        public const string CONNECT_STRING_TEST = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres;";

        //接続文字列(本番用)
        //public const string CONNECT_STRING_TEST = "Host=192.168.0.46;Port=5432;Username=postgres;Password=7215MKIA;Database=postgres;";
        public const string CONNECT_STRING = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres;";

        //日付時間文字列
        public const string TIME_STR = "{0}/{1}/{2} {3}:{4}";
        public const string DTP_DAY_TIMESTR = "yyyy'年'MM'月'dd'日'";
        public const string DTP_MONTH_TIMESTR = "yyyy'年'MM'月'";
        public const string DTP_YEAR_TIMESTR = "yyyy'年'";

        //タイトル画面の表示一覧
        public const string BREAKDOWN_STR = "家計簿入力";
        public const string STATISTICS_STR = "統計確認";
        public const string ASSETS_STR = "資産確認";
        public const string CONFIGURATION_STR = "設定確認";

        //ベースDBの日本語表記(HouseholdABookBase)
        public const string INCOME = "収入";
        public const string SPENDING = "支出";
        public const string CREATEDATE = "日付";
        public const string ASSETS = "資産";
        public const string CLASSIFICATION = "分類";
        public const string MONEY = "金額";
        public const string CONTENT = "内容";

        //収入と支出と合計(データ作成メイン画面)
        public const int INCOME_VALUE = 0;
        public const int SPENDING_VALUE = 1;
        public const int SUM_VALUE = 2;

        //カレンダー用収入と支出判別用
        public const int CALENDER_DAY = 1;
        public const int CALENDER_INCOME = 2;
        public const int CALENDER_SPENDING = 3;

        /// <summary>
        /// グラフ画像保存場所
        /// </summary>
        public const string GRAPH_IMAGE_FILE_DIR = @"C:\Users\makia\OneDrive\ドキュメント\HouseholdAccountBook_Mock\HouseholdAccountBook_Mock\GraphImage";

        /// <summary>
        /// トースト通知用の画像パス
        /// </summary>
        public const string TOAST_ICON_FILE_DIR = @"C:\Users\makia\OneDrive\ドキュメント\HouseholdAccountBook_Mock\HouseholdAccountBook_Mock\Image\手帳のアイコン素材64.png";

        /// <summary>
        /// 統計確認情報
        /// </summary>
        public class StatisticsInfo
        {
            /// <summary>
            /// 家計簿ベースデータ
            /// </summary>
            public List<HouseholdABookBase.HouseholdABook> BookList { get; set; }

            /// <summary>
            /// 開始日時
            /// </summary>
            public System.DateTime StartDate { get; set; }
            
            /// <summary>
            /// 終了日時
            /// </summary>
            public System.DateTime EndDate { get; set; }

            /// <summary>
            /// ID(収入:0か支出:1)
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// ユーザーID
            /// </summary>
            public int UserId { get; set; }

            public StatisticsInfo() { }

            public StatisticsInfo(List<HouseholdABookBase.HouseholdABook> bookList,
                System.DateTime start, System.DateTime end, int id, int userId)
            {
                BookList = bookList;
                StartDate = start;
                EndDate = end;
                Id = id;
                UserId = userId;
            }
        }

        /// <summary>
        /// フォームのスタイル色
        /// </summary>
        public class FormStyle
        {
            /// <summary>
            /// 画面色の種類
            /// </summary>
            public enum StyleColor
            {
                red, yellow, green, orange, blue, purple, pink, gray, black, white
            }

            /// <summary>
            /// フォーム画面の色
            /// </summary>
            public static Color FormColor { get; set; }

            /// <summary>
            /// スタイル設定
            /// </summary>
            public static void SetColor()
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
                var setting = DB.ConfigurationSetting.SelectSetting(userId);
                FormColor = GetBGColor(setting.StyleColor);
            }

            /// <summary>
            /// 設定するスタイルの色取得
            /// </summary>
            /// <returns></returns>
            public static Color GetBGColor(int num)
            {
                Color color = new Color();
                switch (num)
                {
                    case (int)StyleColor.red:
                        color = Color.Red;
                        break;
                    case (int)StyleColor.yellow:
                        color = Color.Yellow;
                        break;
                    case (int)StyleColor.green:
                        color = Color.Green;
                        break;
                    case (int)StyleColor.orange:
                        color = Color.Orange;
                        break;
                    case (int)StyleColor.blue:
                        color = Color.Blue;
                        break;
                    case (int)StyleColor.purple:
                        color = Color.Purple;
                        break;
                    case (int)StyleColor.pink:
                        color = Color.Pink;
                        break;
                    case (int)StyleColor.gray:
                        color = Color.Gray;
                        break;
                    case (int)StyleColor.black:
                        color = Color.Black;
                        break;
                    case (int)StyleColor.white:
                        color = Color.White;
                        break;
                }
                return color;
            }
        }
    }
}
