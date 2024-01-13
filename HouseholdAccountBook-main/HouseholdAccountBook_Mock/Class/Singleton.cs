using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdAccountBook_Mock.Class
{
    /// <summary>
    /// シングルトンクラス（クラスごとに設定できるように簡易的なもの）
    /// </summary>
    public class Singleton<T> where T : class, new()
    {
        private static readonly T _instance = new T();

        protected Singleton()
        {
            Debug.Assert(null == _instance);
        }

        public static T GetInstance()
        {
            return _instance;
        }
    }
}
