using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using HouseholdAccountBook_Mock.DB;
using HouseholdAccountBook_Mock.Class;
using HouseholdAccountBook_Mock.MBox;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;

namespace HouseholdAccountBook_Mock.User_Control
{
    /// <summary>
    /// 統計確認画面
    /// </summary>
    public partial class UCStatistics : UserControl
    {
        #region プロパティ

        public LiveCharts.SeriesCollection StatisticsSeries { get; set; }

        public List<StatisticsListData> statisticsLists { get; set; }

        #endregion

        #region 定数

        /// <summary>
        /// 円グラフの初期角度
        /// </summary>
        public const double INIT_PIE_ANGLE = -30;

        /// <summary>
        /// 円グラフの時間リスト
        /// </summary>
        private readonly string[] piePeriodTypeStrs = { "月間", "年間", "期間" };

        /// <summary>
        /// リストビュー表示のヘッダー項目
        /// </summary>
        private readonly Dictionary<string, int> STATISTICS_HEADERS_DICT = new Dictionary<string, int>()
        {
            { "割合", 100 },
            { "分類", 300 },
            { "金額", 150 }
        };

        #endregion

        #region Enum

        /// <summary>
        /// 分類タイプ
        /// </summary>
        public enum ClassificationType
        {
            Income,　//収入
            Spending //支出
        }

        /// <summary>
        /// 期間タイプ
        /// </summary>
        public enum PeriodType
        {
            Monthly, //月間
            Year,    //年間
            Period   //期間
        }

        #endregion

        #region コンストラクタ

        public UCStatistics()
        {
            InitializeComponent();
        }

        #endregion

        #region ロードイベント

        private void UCStatistics_Load(object sender, EventArgs e)
        {
            panelMain.BackColor = AppConst.FormStyle.FormColor;
            //初期化
            CbPeriod.Items.AddRange(piePeriodTypeStrs);
            CbPeriod.SelectedIndex = (int)PeriodType.Monthly;
            DTPickerBreakdown.Value = DateTime.Now;
            DTPickerBreakdown02.Value = DateTime.Now;
            
            CbClassification.SelectedIndex = (int)ClassificationType.Income;
        }

        #endregion

        #region クリックイベント

        /// <summary>
        /// 日付変更によるグラフ更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDateUpdate_Click(object sender, EventArgs e)
        {
            CreatePieChart();
        }

        /// <summary>
        /// PDF作成時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPDFCreateor_Click(object sender, EventArgs e)
        {
            //pdf作成処理
            PDFCreator.GetInstance().Init("result.pdf");

            string dayStr = "";
            int periodType = CbPeriod.SelectedIndex;
            switch (periodType)
            {
                case (int)PeriodType.Monthly:
                    dayStr = DTPickerBreakdown.Value.ToString(AppConst.DTP_MONTH_TIMESTR);
                    break;
                case (int)PeriodType.Year:
                    dayStr = DTPickerBreakdown.Value.ToString(AppConst.DTP_YEAR_TIMESTR);
                    break;
                case (int)PeriodType.Period:
                    dayStr = DTPickerBreakdown.Value.ToString(AppConst.DTP_DAY_TIMESTR) 
                        + "～" + DTPickerBreakdown02.Value.ToString(AppConst.DTP_DAY_TIMESTR);
                    break;
            }

            string classifStr = CbClassification.Text;
            string periodStr = CbPeriod.Text;
            DataTable dataTable = MakeDataTable(statisticsLists);
            
            PDFCreator.GetInstance().Create(dayStr, classifStr, periodStr, dataTable, DateTime.Now.ToString("yyyyMMdd"));

            OriginMBox.MBoxInfoOK(AppConst.PDF_SUCCESS_MESSAGE);
        }

        /// <summary>
        /// 画像作成時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImageCreateor_Click(object sender, EventArgs e)
        {
            //画像作成処理

            //①画面のスクリーンショットを作成
            //②保存ダイアログで保存する場所を指定
            //③画面のスクリーンショットを保存
            //④円グラフ画像作成（後ほど使う）

            //画面全体のイメージをクリップボードにコピー
            SendKeys.SendWait("%{PRTSC}");
            //クリップボードにあるデータの取得
            IDataObject d = Clipboard.GetDataObject();
            //クリップボードにデータがあったか確認
            if (d != null)
            {
                //ビットマップデータ形式に関連付けられているデータを取得
                Image img = (Image)d.GetData(DataFormats.Bitmap);
                if (img != null)
                {
                    //データが取得できたときは保存ダイアログ表示
                    SaveFileDialog sfd = new SaveFileDialog();
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_Data.png";
                    sfd.FileName = fileName;
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    sfd.Filter = "PNGファイル(*.png)|*.png";
                    sfd.FilterIndex = 1;
                    sfd.Title = "保存先を選択してください";
                    sfd.RestoreDirectory = true;
                    //ダイアログを表示する
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //OKボタンがクリックされたとき、選択されたファイル名を表示する
                        Console.WriteLine(sfd.FileName);
                        img.Save(sfd.FileName);
                    }
                    else
                    {
                        OriginMBox.MBoxInfoOK(AppConst.IMAGE_CANCEL_MESSAGE);
                        return;
                    }

                    //画面のイメージデータは大きいため、
                    //用がなくなればクリップボードから削除した方がいいかもしれない
                    Clipboard.SetDataObject(new DataObject());
                }
            }

            //円グラフのデータは作成しておく
            Bitmap bmp = new Bitmap(pChartStatistics2.Width, pChartStatistics2.Height);
            Rectangle rectangle =
                new Rectangle(new System.Drawing.Point(0, 0),
                new System.Drawing.Size(pChartStatistics2.Width, pChartStatistics2.Height));
            pChartStatistics2.DrawToBitmap(bmp, rectangle);
            string pieFileName = System.IO.Path.Combine(AppConst.GRAPH_IMAGE_FILE_DIR,
                DateTime.Now.ToString("yyyyMMddHHmmss") + "_Pie.png");
            bmp.Save(pieFileName);

            OriginMBox.MBoxInfoOK(AppConst.IMAGE_SUCCESS_MESSAGE);
        }

        #endregion

        #region イベント

        /// <summary>
        /// 期間切り替え時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTPickerBreakdown.Visible = false;
            DTPickerBreakdown.ShowUpDown = false;
            DTPickerBreakdown02.Visible = false;
            DTPickerBreakdown02.ShowUpDown = false;

            int periodType = CbPeriod.SelectedIndex;
            switch (periodType)
            {
                case (int)PeriodType.Monthly:
                    DTPickerBreakdown.CustomFormat = AppConst.DTP_MONTH_TIMESTR;
                    DTPickerBreakdown.Visible = true;
                    DTPickerBreakdown.ShowUpDown = true;
                    break;
                case (int)PeriodType.Year:
                    DTPickerBreakdown.CustomFormat = AppConst.DTP_YEAR_TIMESTR;
                    DTPickerBreakdown.Visible = true;
                    DTPickerBreakdown.ShowUpDown = true;
                    break;
                case (int)PeriodType.Period:
                    DTPickerBreakdown.CustomFormat = AppConst.DTP_DAY_TIMESTR;
                    DTPickerBreakdown02.CustomFormat = AppConst.DTP_DAY_TIMESTR;
                    DTPickerBreakdown.Visible = true;
                    DTPickerBreakdown02.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 分類切り替え時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreatePieChart();
        }

        /// <summary>
        /// PDF作成後に印刷プレビュー画面表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if(OriginMBox.MBoxInfoYesNo(AppConst.PDF_INSTALL_MESSAGE) == DialogResult.Yes)
            {
                PDFCreator.GetInstance().Preview(true ,PDFCreator.GetPDFFile(DateTime.Now.ToString("yyyyMMdd")));
            }
            else
            {
                PDFCreator.GetInstance().Preview(false ,PDFCreator.GetPDFFile(DateTime.Now.ToString("yyyyMMdd")));
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 円グラフ作成（普通のグラフ）
        /// </summary>
        public void CreatePieChart()
        {
            pChartStatistics2.Series.Clear();
            pChartStatistics2.ChartAreas.Clear();
            pChartStatistics2.Titles.Clear();

            // ChartにChartAreaを追加します
            string chart_area1 = "Area1";
            pChartStatistics2.ChartAreas.Add(new ChartArea(chart_area1));
            // ChartにSeriesを追加します
            string legend1 = "Graph1";
            pChartStatistics2.Series.Add(legend1);
            // グラフの種別を指定
            pChartStatistics2.Series[legend1].ChartType = SeriesChartType.Pie; // 円グラフを指定してみます
            // グラフのタイトルを設定
            if (DTPickerBreakdown02.Visible)
            {
                pChartStatistics2.Titles.Add(DTPickerBreakdown.Value.ToString("yyyy/MM") 
                    + "～" + DTPickerBreakdown02.Value.ToString("yyyy/MM") + "の" + CbClassification.Text + "データ");
            }
            else
            {
                pChartStatistics2.Titles.Add(DTPickerBreakdown.Value.ToString("yyyy/MM") 
                    + "の" + CbClassification.Text + "データ");
            }
            pChartStatistics2.Titles[0].Font = new Font("ＭＳ ゴシック", 14, FontStyle.Bold, GraphicsUnit.Point, 128);

            List <StatisticsData> statisticsDataList = GetStatisticsDataList();
            if (statisticsDataList.Count <= 0) return;
            var totalMoney = statisticsDataList.Select(x => x.Money).Sum();
            var moneyList = statisticsDataList.Select(x => x.Money).ToList();
            var moneyTypeList = statisticsDataList.Select(x => x.Classification).ToList(); 

            // データをシリーズにセットします
            for (int i = 0; i < moneyList.Count; i++)
            {
                double rate = (moneyList[i] / totalMoney) * 100.0;  // <-- ここで割合を算出します
                DataPoint dp = new DataPoint
                {
                    Label = moneyTypeList[i]
                };
                dp.SetValueXY(moneyTypeList[i], rate);
                dp.SetCustomProperty("PieLabelStyle", "Disabled");
                pChartStatistics2.Series[legend1].Points.Add(dp);
            }

            //リスト設定
            List<StatisticsListData> statisticsListData = new List<StatisticsListData>();
            foreach (var statisticsData in statisticsDataList)
            {

                //リスト用のデータ作成
                StatisticsListData data = new StatisticsListData
                {
                    Percentage = (statisticsData.Money / totalMoney * 100).ToString() + "%",
                    Classification = statisticsData.Classification,
                    AmountOfMoney = statisticsData.Money
                };
                statisticsListData.Add(data);
            }

            statisticsLists = statisticsListData;
            //リスト表示
            if (!CreateListData(statisticsListData)) return;
        }

        /// <summary>
        /// 円グラフ作成（アニメーションありのグラフ）
        /// </summary>
        public void CreateNLivePieChart()
        {
            try
            {
                pChartStatistics.Series = new LiveCharts.SeriesCollection();

                List<StatisticsData> statisticsDataList = GetStatisticsDataList();
                if (statisticsDataList.Count <= 0) return;

                StatisticsSeries = new LiveCharts.SeriesCollection();
                Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0:#,0}円", chartPoint.Y);
                
                var totalMoney = statisticsDataList.Select(x => x.Money).Sum();
                //リスト設定
                List<StatisticsListData> statisticsListData = new List<StatisticsListData>();
                
                foreach (var statisticsData in statisticsDataList)
                {
                    PieSeries pieSeries = new PieSeries
                    {
                        // Title⇒収入と支出の分類を表示
                        Title = statisticsData.Classification,
                        // Values⇒金額を表示
                        Values = new ChartValues<double> { statisticsData.Money },
                        DataLabels = true,
                        LabelPoint = labelPoint
                    };

                    StatisticsSeries.Add(pieSeries);

                    //リスト用のデータ作成
                    StatisticsListData data = new StatisticsListData
                    {
                        Percentage = (statisticsData.Money / totalMoney * 100).ToString() + "%",
                        Classification = statisticsData.Classification,
                        AmountOfMoney = statisticsData.Money
                    };
                    statisticsListData.Add(data);
                }

                //円グラフ表示設定
                pChartStatistics.Series = StatisticsSeries;
                pChartStatistics.LegendLocation = LegendLocation.Bottom;
                pChartStatistics.StartingRotationAngle = INIT_PIE_ANGLE;

                //リスト表示
                if (!CreateListData(statisticsListData)) return;
            }
            catch(Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.SERIES_MESSAGE);
                return;
            }
        }

        /// <summary>
        /// 日付の指定によってベースDBからデータ取得
        /// </summary>
        /// <returns>家計簿ベースデータ</returns>
        private List<HouseholdABookBase.HouseholdABook> FindHouseholdABookList()
        {
            List<HouseholdABookBase.HouseholdABook> dataList = new List<HouseholdABookBase.HouseholdABook>();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);

            if (!DTPickerBreakdown.Visible && !DTPickerBreakdown02.Visible) return null;
            else if (DTPickerBreakdown.Visible && !DTPickerBreakdown02.Visible)
            {
                DateTime start = new DateTime();
                DateTime end = new DateTime();
                //月間
                if (CbPeriod.SelectedIndex == (int)PeriodType.Monthly)
                {
                    start = new DateTime(DTPickerBreakdown.Value.Year, DTPickerBreakdown.Value.Month, 1);
                    if (start.Month >= 12)
                    {
                        end = new DateTime(DTPickerBreakdown.Value.AddYears(1).Year, DTPickerBreakdown.Value.AddMonths(1).Month, 1);
                    }
                    else
                    {
                        end = new DateTime(DTPickerBreakdown.Value.Year, DTPickerBreakdown.Value.AddMonths(1).Month, 1);
                    }
                }
                //年間
                else if (CbPeriod.SelectedIndex == (int)PeriodType.Year)
                {
                    start = new DateTime(DTPickerBreakdown.Value.Year, 1, 1);
                    end = new DateTime(DTPickerBreakdown.Value.AddYears(1).Year, 1, 1);
                }

                dataList = HouseholdABookBase.SelectHouseholdABookBase(CbClassification.SelectedIndex, start, end, userId);
            }
            //期間指定
            else if(DTPickerBreakdown.Visible && DTPickerBreakdown02.Visible)
            {
                if(DTPickerBreakdown.Value > DTPickerBreakdown02.Value)
                {
                    OriginMBox.MBoxInfoOK(AppConst.STATISTICSDATE_MESSAGE);
                    DTPickerBreakdown.Value = DTPickerBreakdown02.Value;
                    return null;
                }

                dataList = HouseholdABookBase.SelectHouseholdABookBase(CbClassification.SelectedIndex,
                    DTPickerBreakdown.Value, DTPickerBreakdown02.Value, userId);
            }
            return dataList;
        }

        /// <summary>
        /// 日付の指定によって統計情報取得
        /// </summary>
        /// <returns>統計確認情報</returns>
        private AppConst.StatisticsInfo FindStatisticsInfo(List<HouseholdABookBase.HouseholdABook> bookList, int userId)
        {
            AppConst.StatisticsInfo statisticsInfo = new AppConst.StatisticsInfo();
            statisticsInfo.UserId = userId;

            if (!DTPickerBreakdown.Visible && !DTPickerBreakdown02.Visible) return null;
            else if(DTPickerBreakdown.Visible && !DTPickerBreakdown02.Visible)
            {
                statisticsInfo.BookList = bookList;
                //月間
                if (CbPeriod.SelectedIndex == (int)PeriodType.Monthly)
                {
                    statisticsInfo.StartDate = new DateTime(DTPickerBreakdown.Value.Year, DTPickerBreakdown.Value.Month, 1);
                    if (statisticsInfo.StartDate.Month >= 12)
                    {
                        statisticsInfo.EndDate = new DateTime(DTPickerBreakdown.Value.AddYears(1).Year, DTPickerBreakdown.Value.AddMonths(1).Month, 1);
                    }
                    else
                    {
                        statisticsInfo.EndDate = new DateTime(DTPickerBreakdown.Value.Year, DTPickerBreakdown.Value.AddMonths(1).Month, 1);
                    }
                }
                //年間
                else if (CbPeriod.SelectedIndex == (int)PeriodType.Year)
                {
                    statisticsInfo.StartDate = new DateTime(DTPickerBreakdown.Value.Year, 1, 1);
                    statisticsInfo.EndDate = new DateTime(DTPickerBreakdown.Value.AddYears(1).Year, 1, 1);
                }

                if (bookList.Count <= 0) statisticsInfo.Id = AppConst.INCOME_VALUE;
                else statisticsInfo.Id = bookList[0].idStr == AppConst.INCOME ? AppConst.INCOME_VALUE : AppConst.SPENDING_VALUE;
            }
            //期間指定
            else if (DTPickerBreakdown.Visible && DTPickerBreakdown02.Visible)
            {
                statisticsInfo.BookList = bookList;
                statisticsInfo.StartDate = DateTime.Parse(DTPickerBreakdown.Value.ToShortDateString());
                statisticsInfo.EndDate = DateTime.Parse(DTPickerBreakdown02.Value.ToShortDateString());
                if (bookList.Count <= 0) statisticsInfo.Id = AppConst.INCOME_VALUE;
                else statisticsInfo.Id = bookList[0].idStr == AppConst.INCOME ? AppConst.INCOME_VALUE : AppConst.SPENDING_VALUE;
            }

            return statisticsInfo;
        }

        /// <summary>
        /// 円グラフ表示用データを取得
        /// </summary>
        /// <returns>円グラフ表示用データを取得</returns>
        private List<StatisticsData> GetStatisticsDataList()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);
            // ベースDBからデータ取得処理
            List<HouseholdABookBase.HouseholdABook> dataList = FindHouseholdABookList();
            if (dataList == null || dataList.Count <= 0) return new List<StatisticsData>();

            AppConst.StatisticsInfo statisticsInfo = FindStatisticsInfo(dataList, userId);
            if (statisticsInfo == null) return new List<StatisticsData>();

            //グラフ表示用データを作成or更新
            List<StatisticsData> statisticsDataList = StatisticsData.UpsertDataList(statisticsInfo);
            if (statisticsDataList == null || statisticsDataList.Count <= 0) return new List<StatisticsData>();

            return statisticsDataList;
        }

        /// <summary>
        ///　統計確認リストビューデータ表示
        /// </summary>
        /// <param name="statisticsListData">統計割合データ</param>
        /// <returns>データ表示可否</returns>
        private bool CreateListData(List<StatisticsListData> statisticsListData)
        {
            try
            {
                // ListViewコントロールのプロパティを設定
                LvRecord.FullRowSelect = true;
                LvRecord.GridLines = true;
                LvRecord.Sorting = SortOrder.Ascending;
                LvRecord.View = View.Details;
                LvRecord.Items.Clear();
                LvRecord.Columns.Clear();

                // 列（コラム）ヘッダの登録
                ColumnHeader[] colHeaderRegValue = CreateColumnHeader(STATISTICS_HEADERS_DICT);
                if (colHeaderRegValue == null) return false;
                LvRecord.Columns.AddRange(colHeaderRegValue);

                List<ListViewItem> viewItems = new List<ListViewItem>();
                if (statisticsListData == null || statisticsListData.Count <= 0) return false;
                for (int i = 0; i < statisticsListData.Count; i++)
                {
                    string[] items = statisticsListData[i].GetStatisticsListDataStrs();

                    ListViewItem listView = new ListViewItem(items);
                    //フォント設定使用出来るようにする
                    listView.UseItemStyleForSubItems = false;

                    viewItems.Add(listView);
                }

                LvRecord.Items.AddRange(viewItems.ToArray());
                return true;
            }
            catch(Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.LIST_ITEM_MESSAGE);
                return false;
            }
        }

        /// <summary>
        /// 統計確認リストビューデータ表示(PDF用)
        /// </summary>
        /// <param name="statisticsListData">統計割合データ</param>
        /// <returns>データ表示可否</returns>
        private DataTable MakeDataTable(List<StatisticsListData> statisticsListData)
        {
            try
            {
                DataTable table = new DataTable();

                foreach (KeyValuePair<string, int> valuePair in STATISTICS_HEADERS_DICT)
                {
                    table.Columns.Add(valuePair.Key);
                }

                foreach(var data in statisticsListData)
                {
                    table.Rows.Add(data.GetStatisticsListDataStrs());
                }

                return table;
            }
            catch (Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.LIST_ITEM_MESSAGE);
                return null;
            }
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

        #endregion
    }

    /// <summary>
    /// 統計割合データ（リスト表示用）
    /// </summary>
    public class StatisticsListData
    {
        /// <summary>
        /// 割合
        /// </summary>
        public string Percentage { get; set; } = "";

        /// <summary>
        /// 分類
        /// </summary>
        public string Classification { get; set; } = "";

        /// <summary>
        /// 金額
        /// </summary>
        public int AmountOfMoney { get; set; } = 0;

        public StatisticsListData() { }

        /// <summary>
        /// リスト表示用文字列リスト取得
        /// </summary>
        /// <returns></returns>
        public string[] GetStatisticsListDataStrs()
        {
            return new string[]
            {
                Percentage, Classification, string.Format("{0:#,0}円", AmountOfMoney)
            };
        }
    }
}
