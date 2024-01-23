using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Linq;
using HouseholdAccountBook_Mock.DB;
using HouseholdAccountBook_Mock.MBox;
using System.Configuration;

namespace HouseholdAccountBook_Mock.User_Control
{
    public partial class UCBreakdown : UserControl
    {
        #region 定数

        /// <summary>
        /// 1日ごとのリスト表示用
        /// </summary>
        private readonly Dictionary<string, int> ONEDAY_PARAM_DICT = new Dictionary<string, int>()
        {
            { "日付", 150 },
            { "分類", 80 },
            { "内容", 200 },
            { "金額", 150 }
        };

        /// <summary>
        /// 1週ごとのリスト表示用
        /// </summary>
        private readonly Dictionary<string, int> BYWEEK_PARAM_DICT = new Dictionary<string, int>()
        {
            { "週", 210 },
            { "収入", 150 },
            { "支出", 150 }
        };

        /// <summary>
        /// 1月ごとのリスト表示用
        /// </summary>
        private readonly Dictionary<string, int> BYMONTH_PARAM_DICT = new Dictionary<string, int>()
        {
            { "月", 100 },
            { "収入", 150 },
            { "支出", 150 }
        };

        #endregion

        #region プロパティ

        /// <summary>
        /// アプリ管理オブジェクト
        /// </summary>
        public AppController AppController { get; set; }

        /// <summary>
        /// 表示用の日付フォーマット
        /// </summary>
        public string DTPBreakdownStr { get; set; }

        /// <summary>
        /// カレンダーオブジェクト
        /// </summary>
        public CustomCalender Calender { get; set; } 

        #endregion

        #region Enum

        /// <summary>
        /// 表示リスト種類
        /// </summary>
        public enum DisplayListType
        {
            OneDay, //日付ごとに詳細リスト表示
            ByDay, //カレンダーに表示
            ByWeek, //週ごとにリスト表示
            ByMonth //月ごとにリスト表示
        }

        #endregion

        #region コンストラクタ

        public UCBreakdown()
        {
            InitializeComponent();
        }

        #endregion

        #region ロードイベント

        private void UCBreakdown_Load(object sender, System.EventArgs e)
        {
            panelMain.BackColor = AppConst.FormStyle.FormColor;
            //日付初期化
            DTPickerBreakdown.Format = DateTimePickerFormat.Custom;
            DTPickerBreakdown.CustomFormat = DTPickerBreakdownStr(DisplayListType.OneDay);
            DTPickerBreakdown.Value = DateTime.Now;
            DTPickerBreakdown.Visible = false;

            //リスト初期化
            InitializeListView();

            //収入と支出と合計初期表示
            DisplayPropertyManagement(DisplayListType.OneDay);

            //データリスト表示処理
            ChangeListViewItems(DisplayListType.OneDay);
        }

        #endregion

        #region イベント

        private void TCBreakdown_Selected(object sender, TabControlEventArgs e)
        {
            //共通部分表示共有
            e.TabPage.Controls.Add(FLPanelResult);
            e.TabPage.Controls.Add(BtnNewData);

            //リスト表示リセット
            LvRecord.Items.Clear();
            LvRecord.Columns.Clear();

            //タブの種類によってリスト表示切り替え
            switch (e.TabPageIndex)
            {
                case (int)DisplayListType.OneDay:
                    DTPickerBreakdown.Visible = false;
                    e.TabPage.Controls.Add(LvRecord);
                    ChangeListView(DisplayListType.OneDay);
                    //日付文字列変更
                    DTPickerBreakdown.CustomFormat = DTPickerBreakdownStr(DisplayListType.OneDay);
                    //データリスト表示処理
                    ChangeListViewItems(DisplayListType.OneDay);
                    //収入と支出と合計の更新
                    DisplayPropertyManagement(DisplayListType.OneDay);
                    break;
                case (int)DisplayListType.ByDay:
                    DTPickerBreakdown.Visible = true;
                    //日付文字列変更
                    DTPickerBreakdown.CustomFormat = DTPickerBreakdownStr(DisplayListType.ByDay);
                    //カレンダー情報初期化
                    Calender = new CustomCalender(DTPickerBreakdown.Value)
                    {
                        Top = LvRecord.Top,
                        Left = LvRecord.Left
                    };
                    //収入と支出と合計の更新
                    DisplayPropertyManagement(DisplayListType.ByDay);
                    //カレンダー表示
                    e.TabPage.Controls.Add(Calender);
                    break;
                case (int)DisplayListType.ByWeek:
                    DTPickerBreakdown.Visible = true;
                    e.TabPage.Controls.Add(LvRecord);
                    ChangeListView(DisplayListType.ByWeek);
                    //日付文字列変更
                    DTPickerBreakdown.CustomFormat = DTPickerBreakdownStr(DisplayListType.ByWeek);
                    //データリスト表示処理
                    ChangeListViewItems(DisplayListType.ByWeek);
                    //収入と支出と合計の更新
                    DisplayPropertyManagement(DisplayListType.ByWeek);
                    break;
                case (int)DisplayListType.ByMonth:
                    DTPickerBreakdown.Visible = true;
                    e.TabPage.Controls.Add(LvRecord);
                    ChangeListView(DisplayListType.ByMonth);
                    //日付文字列変更
                    DTPickerBreakdown.CustomFormat = DTPickerBreakdownStr(DisplayListType.ByMonth);
                    //データリスト表示処理
                    ChangeListViewItems(DisplayListType.ByMonth);
                    //収入と支出と合計の更新
                    DisplayPropertyManagement(DisplayListType.ByMonth);
                    break;
            }
        }

        #endregion

        #region クリックイベント

        /// <summary>
        /// 新規データ作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewData_Click(object sender, System.EventArgs e)
        {
            NewDataCreater dataCreater = new NewDataCreater();
            dataCreater.ShowDialog();
            if(dataCreater.dialogResult == DialogResult.OK)
            {
                // 新規作成したら一度閉じてから開いてもらう
                this.ParentForm.Close();
            }
        }

        private void LbIncome_Click(object sender, System.EventArgs e)
        {
            LbIncome.Focus();
        }

        private void LbSpending_Click(object sender, System.EventArgs e)
        {
            LbSpending.Focus();
        }


        private void LbSettlement_Click(object sender, System.EventArgs e)
        {
            LbSettlement.Focus();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 日付文字列取得
        /// </summary>
        /// <param name="listType">表示リスト種類</param>
        /// <returns>日付文字列</returns>
        private string DTPickerBreakdownStr(DisplayListType listType)
        {
            switch (listType)
            {
                case DisplayListType.OneDay:
                case DisplayListType.ByDay:
                case DisplayListType.ByWeek:
                    DTPBreakdownStr = AppConst.DTP_MONTH_TIMESTR;
                    break;
                case DisplayListType.ByMonth:
                    DTPBreakdownStr = AppConst.DTP_YEAR_TIMESTR;
                    break;
            }

            return DTPBreakdownStr;
        }

        /// <summary>
        /// ListViewコントロールを初期化する
        /// </summary>
        private void InitializeListView()
        {
            // ListViewコントロールのプロパティを設定
            LvRecord.FullRowSelect = true;
            LvRecord.GridLines = true;
            LvRecord.Sorting = SortOrder.Ascending;
            LvRecord.View = View.Details;

            // 列（コラム）ヘッダの登録
            ColumnHeader[] colHeaderRegValue = ChangeHeader(DisplayListType.OneDay);
            if (colHeaderRegValue == null) return;
            LvRecord.Columns.AddRange(colHeaderRegValue);
        }

        /// <summary>
        /// ListViewコントロールを変更する
        /// </summary>
        /// <param name="listType"></param>
        private void ChangeListView(DisplayListType listType)
        {
            // ListViewコントロールのプロパティを設定
            LvRecord.FullRowSelect = true;
            LvRecord.GridLines = true;
            LvRecord.Sorting = SortOrder.Ascending;
            LvRecord.View = View.Details;

            // 列（コラム）ヘッダの登録
            ColumnHeader[] colHeaderRegValue = ChangeHeader(listType);
            if (colHeaderRegValue == null) return;
            LvRecord.Columns.AddRange(colHeaderRegValue);
        }

        /// <summary>
        /// ListViewの項目を追加
        /// </summary>
        /// <param name="listType"></param>
        private void ChangeListViewItems(DisplayListType listType)
        {
            // ListViewコントロールのデータをすべて消去します。
            LvRecord.Items.Clear();

            // ListViewコントロールにデータを追加します。
            ListViewItem[] items = ChangeItems(listType);
            if (items == null) return;
            LvRecord.Items.AddRange(items);

            if(listType == DisplayListType.ByMonth)
            {
                LvRecord.Sorting = SortOrder.Descending;
                LvRecord.ListViewItemSorter = new ValueCompare();
            }
        }

        /// <summary>
        /// データごとにヘッダーの中身を変更する
        /// </summary>
        /// <param name="displayListType">表示リスト種類</param>
        /// <returns>リストのヘッダー</returns>
        private ColumnHeader[] ChangeHeader(DisplayListType displayListType)
        {
            ColumnHeader[] colHeaderList = null;
            //データごとにヘッダーの中身を変更する
            switch (displayListType)
            {
                case DisplayListType.OneDay:
                    colHeaderList = CreateColumnHeader(ONEDAY_PARAM_DICT);
                    break;
                case DisplayListType.ByDay:
                    break;
                case DisplayListType.ByWeek:
                    colHeaderList = CreateColumnHeader(BYWEEK_PARAM_DICT);
                    break;
                case DisplayListType.ByMonth:
                    colHeaderList = CreateColumnHeader(BYMONTH_PARAM_DICT);
                    break;
            }

            return colHeaderList;
        }

        /// <summary>
        /// 列（コラム）ヘッダの作成
        /// </summary>
        /// <param name="pairs">リスト表示の動的配列</param>
        /// <returns>ヘッダー</returns>
        private ColumnHeader[] CreateColumnHeader(Dictionary<string, int> pairs)
        {
            ColumnHeader[] colHeaderList = null;

            try
            {
                List<ColumnHeader> headersList = new List<ColumnHeader>();

                // 列（コラム）ヘッダの作成
                int count = 0;
                foreach (KeyValuePair<string, int> valuePair in pairs)
                {
                    ColumnHeader header = new ColumnHeader(count)
                    {
                        Text = valuePair.Key,
                        Width = valuePair.Value
                    };
                    headersList.Add(header);
                    count++;
                }

                colHeaderList = headersList.ToArray();
                return colHeaderList;
            }
            catch
            {
                OriginMBox.MBoxErrorOK(AppConst.LIST_HEADER_MESSAGE);
                return null;
            }
        }

        /// <summary>
        /// データごとに表示項目を変更する
        /// </summary>
        /// <param name="displayListType">表示リスト種類</param>
        /// <returns>リストのヘッダー</returns>
        private ListViewItem[] ChangeItems(DisplayListType displayListType)
        {
            ListViewItem[] viewItems = null;
            //データごとにヘッダーの中身を変更する
            switch (displayListType)
            {
                case DisplayListType.OneDay:
                    viewItems = CreateItemsList(DisplayListType.OneDay);
                    break;
                case DisplayListType.ByDay:
                    break;
                case DisplayListType.ByWeek:
                    viewItems = CreateItemsList(DisplayListType.ByWeek);
                    break;
                case DisplayListType.ByMonth:
                    viewItems = CreateItemsList(DisplayListType.ByMonth);
                    break;
            }

            return viewItems;
        }

        /// <summary>
        /// 表示項目の作成
        /// </summary>
        /// <param name="pairs">リスト表示の動的配列</param>
        /// <returns>ヘッダー</returns>
        private ListViewItem[] CreateItemsList(DisplayListType listType)
        {
            ListViewItem[] listViewItems = null;

            try
            {
                List<ListViewItem> itemsList = new List<ListViewItem>();

                // 列（コラム）ヘッダの作成
                switch (listType)
                {
                    case DisplayListType.OneDay:
                        itemsList = OneDayCreateItems();
                        break;
                    case DisplayListType.ByDay:
                        break;
                    case DisplayListType.ByWeek:
                        itemsList = WeekCreateItems();
                        break;
                    case DisplayListType.ByMonth:
                        itemsList = MonthCreateItems();
                        break;
                }

                listViewItems = itemsList.ToArray();
                return listViewItems;
            }
            catch
            {
                OriginMBox.MBoxErrorOK(AppConst.LIST_ITEM_MESSAGE);
                return null;
            }
        }

        /// <summary>
        /// 1日ごとの項目作成
        /// </summary>
        private List<ListViewItem> OneDayCreateItems()
        {
            List<ListViewItem> viewItems = new List<ListViewItem>();

            List<HouseholdABookBase.HouseholdABook> householdsList = new List<HouseholdABookBase.HouseholdABook>();

            //データ取得
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
            householdsList = HouseholdABookBase.SelectHouseholdABookBase(userId);

            for (int i = 0; i < householdsList.Count; i++)
            {
                string[] items = householdsList[i].GetHouseholdABookList();

                ListViewItem listView = new ListViewItem(items);
                //フォント設定使用出来るようにする
                listView.UseItemStyleForSubItems = false;

                //金額をタイプごとに色変更
                const int MONEY_NUM = 3;
                if (householdsList[i].idStr == AppConst.INCOME)
                {
                    listView.SubItems[MONEY_NUM].ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    listView.SubItems[MONEY_NUM].ForeColor = System.Drawing.Color.Red;
                }

                viewItems.Add(listView);
            }

            return viewItems;
        }

        /// <summary>
        /// 週の項目作成
        /// </summary>
        /// <returns></returns>
        private List<ListViewItem> WeekCreateItems()
        {
            List<ListViewItem> viewItems = new List<ListViewItem>();
            
            DateTime startDate = new DateTime(DTPickerBreakdown.Value.Year
                , DTPickerBreakdown.Value.Month, 1);
            DateTime endDate = new DateTime(DTPickerBreakdown.Value.Year
                , DTPickerBreakdown.Value.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));

            //データ取得
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
            List<WeekDataList> weekDataLists = WeekDataList.SelectDisplayList(startDate, endDate.AddDays(1), userId);
            //データが存在しない場合、データ集計して週ごとの収入と支出データ作成
            if(weekDataLists == null)
            {
                //月始めから月終わりまでのベースデータ取得
                List<int[]> dataLists = HouseholdABookBase.SelectHouseholdABooks(startDate, endDate.AddDays(1), userId);
                if(dataLists == null) 
                { 
                    OriginMBox.MBoxInfoOK("当月のデータが作成されていません。データ作成画面でデータ作成してください。");
                    return new List<ListViewItem>();
                }

                weekDataLists = WeekDataList.CreateWeekDataList(dataLists, WeekDataList.GetDateTimes(startDate, endDate), userId);
                if (!WeekDataList.InsertWeekDataList(weekDataLists))
                {
                    OriginMBox.MBoxErrorOK("週ごとの収入と支出データ作成に失敗しました。");
                    return null;
                }
            }
            else
            {
                //月ごとのベースデータ取得
                List<int[]> dataLists = HouseholdABookBase.SelectHouseholdABooks(startDate, endDate.AddDays(1), userId);
                if (dataLists == null)
                {
                    OriginMBox.MBoxInfoOK("当月のデータが作成されていません。データ作成画面でデータ作成してください。");
                    return new List<ListViewItem>();
                }

                // 二度目以降は最新データかによって処理分け
                weekDataLists = WeekDataList.CreateWeekDataList(dataLists, WeekDataList.GetDateTimes(startDate, endDate), userId);
                if (!WeekDataList.UpdateWeekDataList(weekDataLists))
                {
                    OriginMBox.MBoxErrorOK("週ごとの収入と支出データ更新に失敗しました。");
                    return new List<ListViewItem>();
                }
            }

            List<string[]> dataStrList = WeekDataList.GetDisplayDataList(weekDataLists);

            for(int i = 0; i < dataStrList.Count; i++)
            {
                ListViewItem listView = new ListViewItem(dataStrList[i])
                {
                    //フォント設定使用出来るようにする
                    UseItemStyleForSubItems = false
                };

                //収入と支出データで色分け
                listView.SubItems[1].ForeColor = System.Drawing.Color.Blue;
                listView.SubItems[2].ForeColor = System.Drawing.Color.Red;

                viewItems.Add(listView);
            }

            return viewItems;
        }

        /// <summary>
        /// 月の項目作成
        /// </summary>
        /// <returns></returns>
        private List<ListViewItem> MonthCreateItems()
        {
            List<ListViewItem> viewItems = new List<ListViewItem>();

            // データ取得
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
            List<MonthDataList> monthDataLists = MonthDataList.SelectDisplayList(DTPickerBreakdown.Value.Year, userId);
            // 最初に見たとき
            if(monthDataLists == null)
            {
                DateTime start = new DateTime(DTPickerBreakdown.Value.Year, 1, 1);
                DateTime end = new DateTime(DTPickerBreakdown.Value.Year, 12, DateTime.DaysInMonth(DTPickerBreakdown.Value.Year, 12));

                //月ごとのベースデータ取得
                List<int[]> dataLists = HouseholdABookBase.SelectMonthDatasCreate(start, end, userId);
                if (!(dataLists[0].Any(x => x > 0) || dataLists[1].Any(x => x > 0)))
                {
                    OriginMBox.MBoxInfoOK("当年のデータが作成されていません。データ作成画面でデータ作成してください。");
                    return new List<ListViewItem>();
                }

                monthDataLists = MonthDataList.CreateMonthDataList(dataLists, DateTime.Now, userId);
                if (!MonthDataList.InsertMonthDataList(monthDataLists))
                {
                    OriginMBox.MBoxErrorOK("月ごとの収入と支出データ作成に失敗しました。");
                    return new List<ListViewItem>();
                }
            }
            else
            {
                DateTime start = new DateTime(DTPickerBreakdown.Value.Year, 1, 1);
                DateTime end = new DateTime(DTPickerBreakdown.Value.Year, 12, DateTime.DaysInMonth(DTPickerBreakdown.Value.Year, 12));

                //月ごとのベースデータ取得
                List<int[]> dataLists = HouseholdABookBase.SelectMonthDatasCreate(start, end, userId);
                if (!(dataLists[0].Any(x => x > 0) || dataLists[1].Any(x => x > 0)))
                {
                    OriginMBox.MBoxInfoOK("当年のデータが作成されていません。データ作成画面でデータ作成してください。");
                    return new List<ListViewItem>();
                }

                // 二度目以降は最新データかによって処理分け
                if (!MonthDataList.IsNewMonthDataList(monthDataLists, dataLists))
                {
                    monthDataLists = MonthDataList.CreateMonthDataList(dataLists, monthDataLists.Select(x => x.CreateDate).FirstOrDefault(), userId);
                    if (!MonthDataList.UpdateMonthDataList(monthDataLists))
                    {
                        OriginMBox.MBoxErrorOK("月ごとの収入と支出データ更新に失敗しました。");
                        return new List<ListViewItem>();
                    }
                }
            }

            List<string[]> dataStrList = MonthDataList.GetDisplayDataList(monthDataLists);

            for (int i = 0; i < dataStrList.Count; i++)
            {
                ListViewItem listView = new ListViewItem(dataStrList[i])
                {
                    //フォント設定使用出来るようにする
                    UseItemStyleForSubItems = false
                };

                //収入と支出データで色分け
                listView.SubItems[1].ForeColor = System.Drawing.Color.Blue;
                listView.SubItems[2].ForeColor = System.Drawing.Color.Red;

                viewItems.Add(listView);
            }

            return viewItems;
        }

        /// <summary>
        /// 収入と支出と合計の表示
        /// </summary>
        private void DisplayPropertyManagement(DisplayListType listType)
        {
            DateTime start;
            DateTime end;

            switch (listType)
            {
                case DisplayListType.OneDay:
                    //1日ごとの全データを設定
                    SetPropertyManagementList(DateTime.MinValue, DateTime.MinValue);
                    break;
                case DisplayListType.ByDay:
                    start = new DateTime(DTPickerBreakdown.Value.Year, DTPickerBreakdown.Value.Month, 1);
                    SetPropertyManagementList(start, start.AddMonths(1));
                    break;
                case DisplayListType.ByWeek:
                    start = new DateTime(DTPickerBreakdown.Value.Year, DTPickerBreakdown.Value.Month, 1);
                    SetPropertyManagementList(start, start.AddMonths(1));
                    break;
                case DisplayListType.ByMonth:
                    start = new DateTime(DTPickerBreakdown.Value.Year, 1, 1);
                    end = new DateTime(DTPickerBreakdown.Value.AddYears(1).Year, 1, 1);
                    SetPropertyManagementList(start, end);
                    break; 
            }
        }

        /// <summary>
        /// 期間ごとの収入と支出と合計の設定
        /// </summary>
        /// <param name="start">スタート期間</param>
        /// <param name="end">エンド期間</param>
        /// <returns></returns>
        private void SetPropertyManagementList(DateTime start, DateTime end)
        {
            List<int> list = new List<int>();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);

            //最小値の時は全データを取得する
            if (start == DateTime.MinValue && end == DateTime.MinValue)
            {
                list = HouseholdABookBase.SelectPropManageList(userId);
            }
            //そのほかは期間ごとに取得
            else
            {
                list = HouseholdABookBase.SelectPropManageList(start, end, userId);
            }

            if (list.Count <= 0) 
            { 
                OriginMBox.MBoxInfoOK("データが存在しません。"); 
                return; 
            }

            //リストクリア
            LbIncome.Items.Clear();
            LbSpending.Items.Clear();
            LbSettlement.Items.Clear();

            //TODO　金額の桁数によって位置を調整する
            //収入と支出と合計
            LbIncome.Items.Add("　　　　" + AppConst.INCOME);
            LbIncome.Items.Add("　　    " + list[AppConst.INCOME_VALUE]);

            LbSpending.Items.Add("　　　　" + AppConst.SPENDING);
            LbSpending.Items.Add("　　    " + list[AppConst.SPENDING_VALUE]);

            LbSettlement.Items.Add("　　　　" + "合計");
            //合計がマイナスの値のとき
            if(list[AppConst.SUM_VALUE] < 0)
            {
                LbSettlement.ForeColor = System.Drawing.Color.Red;
                LbSettlement.Items.Add("　　    " + list[AppConst.SUM_VALUE]);
            }
            else
            {
                LbSettlement.Items.Add("　　    " + list[AppConst.SUM_VALUE]);
            }
        }
        #endregion

        #region 独自クラス

        /// <summary>
        /// リストビューの並び替え用(年間データ表示時)
        /// </summary>
        public class ValueCompare : System.Collections.IComparer
        {
            public ValueCompare() { }

            public ValueCompare(int column) { }

            public int Compare(object x, object y)
            {
                //nullが最も小さいとする
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }

                ListViewItem lx = (ListViewItem)x;
                ListViewItem ly = (ListViewItem)y;

                int a = 0;
                if(!int.TryParse(lx.SubItems[0].Text.Substring(0, 2), out a))
                {
                    a = int.Parse(lx.SubItems[0].Text.Substring(0, 1));
                }

                int b = 0;
                if (!int.TryParse(ly.SubItems[0].Text.Substring(0, 2), out b))
                {
                    b = int.Parse(ly.SubItems[0].Text.Substring(0, 1));
                }

                return a.CompareTo(b);

            }
        }

        #endregion
    }
}
