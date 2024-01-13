using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HouseholdAccountBook_Mock.DB;
using System.Configuration;

namespace HouseholdAccountBook_Mock.User_Control
{
    public partial class CustomCalender : UserControl
    {
        #region プロパティ

        /// <summary>
        /// 取得する日付
        /// </summary>
        public DateTime calenderDate { get; set; }

        #endregion

        public CustomCalender(DateTime date)
        {
            InitializeComponent();

            calenderDate = date;
        }

        /// <summary>
        /// ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomCalender_Load(object sender, EventArgs e)
        {
            //TODO 残タスク：支出データの表示されない場合がある⇒原因を調査して修正
            DateTime firstDate = new DateTime(calenderDate.Year, calenderDate.Month, 1);
            int first_time = firstDate.Day;
            int lastdays = DateTime.DaysInMonth(firstDate.Year, firstDate.Month); // その月の日数
            DateTime lastDay = new DateTime(firstDate.Year, firstDate.Month, lastdays);
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int userId = int.Parse(config.AppSettings.Settings["UserId"].Value);

            List<Control> dateList = new List<Control>();
            List<Control> incomeList = new List<Control>();
            List<Control> spendingList = new List<Control>();
            List<Control> panelList = new List<Control>();

            for(int i = 0; i < lastdays; i++)
            {
                dateList.AddRange(Controls.Find("label" + (3 * i + 1), true));
                incomeList.AddRange(Controls.Find("label" + (3 * i + 2), true));
                spendingList.AddRange(Controls.Find("label" + (3 * i + 3), true));
                panelList.AddRange(Controls.Find("panel" + (i + 1), true));
            }

            //カレンダーDBからデータ取得してデータ存在した場合、そのデータを表示する
            //ない場合はベースDBから情報を取得して、カレンダーDBにデータ更新して画面表示
            List<Calender> calenderList = new List<Calender>();
            int[] incomeDataList = new int[lastdays];
            int[] spendingDataList = new int[lastdays];
            DateTime registerDate = new DateTime();

            calenderList = Calender.SelectCalender(firstDate, firstDate.AddMonths(1), out registerDate, userId);
            
            //そもそもデータが一件もない場合は新規データ作成
            if(calenderList == null) { if (!Calender.InsertInitCalender(lastdays, calenderDate, userId)) { return; }}
            //ベースDBからデータ取得
            List<int[]> dataList = HouseholdABookBase.SelectHouseholdABooks(firstDate, lastDay.AddDays(1), userId);

            //収入と支出がある場合はそのデータを取得
            if (calenderList != null)
            {
                //最新データか確認
                if (!Calender.IsNewCalenderData(calenderList, dataList))
                {
                    if (dataList == null) { return; }
                    incomeDataList = dataList[0];
                    spendingDataList = dataList[1];

                    //カレンダーDB更新or登録
                    calenderList = Calender.CreateCalenderList(lastdays, incomeDataList, spendingDataList, calenderDate, userId);
                    if (!Calender.UpdateCalender(calenderList, registerDate)) { return; }
                }

                //最新データはそのまま取得
                calenderList.ForEach(data =>
                {
                    incomeDataList[data.Id - 1] = data.Income > 0 ? data.Income : 0;
                    spendingDataList[data.Id - 1] = data.Spending > 0 ? data.Spending : 0;
                });
            }
            //収入と支出がない場合ベースDBからデータ作成
            else if (dataList != null)
            {
                incomeDataList = dataList[0];
                spendingDataList = dataList[1];

                //カレンダーDB更新or登録
                calenderList = Calender.CreateCalenderList(lastdays, incomeDataList, spendingDataList, calenderDate, userId);
                if (!Calender.UpdateCalender(calenderList, registerDate)) { return; }
            }

            for (int i = 0; i < lastdays; i++)
            {
                //日付制御
                if (dateList.Count() > 0 && panelList.Count() > 0)
                {
                    Control panel = panelList.Where(data => data.Name == "panel" + (i + 1))?.First();
                    panel.Visible = true;
                    Control label = dateList.Where(data => data.Name == "label" + (3 * i + AppConst.CALENDER_DAY))?.First();
                    label.Text = (i + 1).ToString();
                    label.Font = new Font(label.Font, FontStyle.Bold);
                    label.Visible = true;
                }

                //支出の制御
                if (incomeDataList.Length > 0)
                {
                    Control label = incomeList.Where(data => data.Name == "label" + (3 * i + AppConst.CALENDER_INCOME)).First();
                    label.Text = incomeDataList[i].ToString();
                    label.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    if (i == 0)
                    {
                        Control label = incomeList.Where(data => data.Name == "label" + AppConst.CALENDER_INCOME).First();
                        label.Text = incomeDataList[0].ToString();
                        label.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        Control label = incomeList.Where(data => data.Name == "label" + (i * AppConst.CALENDER_INCOME)).First();
                        label.Text = 0.ToString();
                        label.ForeColor = System.Drawing.Color.Blue;
                    }
                }

                //収入の制御
                if (spendingDataList.Length > 0)
                {
                    if (spendingList.Count() > 0)
                    {
                        Control label = spendingList.Where(data => data.Name == "label" + (3 * i + AppConst.CALENDER_SPENDING)).First();
                        label.Text = spendingDataList[i].ToString();
                        label.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        Control label = incomeList.Where(data => data.Name == "label" + (3 * i + AppConst.CALENDER_SPENDING)).First();
                        label.Text = 0.ToString();
                        label.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    Control label = incomeList.Where(data => data.Name == "label" + (3 * i + AppConst.CALENDER_SPENDING)).First();
                    label.Text = 0.ToString();
                    label.ForeColor = Color.Red;
                }
            }
        }
    }
}
