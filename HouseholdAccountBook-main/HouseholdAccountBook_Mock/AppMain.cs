using System;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;
using HouseholdAccountBook_Mock.MBox;

namespace HouseholdAccountBook_Mock
{
    static class AppMain
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //二重起動防止処理
            //Mutex名を決める（必ずアプリケーション固有の文字列に変更すること！）
            string mutexStr = Application.ProductName;
            //Mutexオブジェクトを作成する
            Mutex mutex = new Mutex(false, mutexStr);

            bool hasHandle = false;
            try
            {
                //ミューテックスの所有権を要求する
                hasHandle = mutex.WaitOne(0, false);

                if(hasHandle == false)
                {
                    OriginMBox.MBoxWarningOK(AppConst.MUTEX_MESSAGE);
                    return;
                }

                AppController appController = new AppController();
                appController.Init();
                
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["UserId"].ToString())
                    && string.IsNullOrEmpty(ConfigurationManager.AppSettings["HashPassword"].ToString()))
                {
                    LoginCreate loginCreate = new LoginCreate(appController);
                    if(loginCreate.ShowDialog() == DialogResult.OK)
                    {
                        OriginMBox.MBoxInfoOK(AppConst.USER_MESSAGE);
                    }
                    else { return; }
                }

                Application.EnableVisualStyles();
                Application.Run(GetMainForm(appController));
            }
            catch (AbandonedMutexException e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(s);
                //別のアプリケーションがミューテックスを解放しないで終了した時
                hasHandle = true;
            }
            finally
            {
                if (hasHandle)
                {
                    //ミューテックスを解放する
                    mutex.ReleaseMutex();
                }
                mutex.Close();
            }
        }

        /// <summary>
        /// 最初に表示するメイン画面の選定
        /// </summary>
        /// <param name="appController"></param>
        /// <returns></returns>
        private static Form GetMainForm(AppController appController)
        {
            Form mainForm = new Form();
            try
            {
                // 設定ファイルにハッシュを持っているかどうかで表示画面を変更
                // デフォルトはログイン画面を表示
                // オートログイン時はパスワードだけの入力画面を表示
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["HashPassword"].ToString()))
                {
                    mainForm = new SetPassword(appController);
                }
                else
                {
                    mainForm = new Login(appController);
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Console.WriteLine(s);
                Console.WriteLine(AppConst.FORM_MESSAGE);
            }
            return mainForm;
        }
    }
}
