using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReplacerNunitTest
{
    public class StopWatchMonitor
    {
        /// <summary>  
        /// 测试运行时间  
        /// </summary>  
        /// <param name="method">需要执行的方法</param>  
        /// <param name="summary">对方法的说明</param>  
        /// <returns>返回,这个方法执行用了多少毫秒</returns>  
        public static long Stopwatch(Action method)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Restart();
            //运行方法  
            method.Invoke();

            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        /// <summary>  
        /// 测试运行时间  
        /// </summary>  
        /// <param name="method">需要执行的方法</param>  
        /// <param name="obj">参数对像</param>  
        /// <returns>返回,这个方法执行用了多少毫秒</returns>  
        public static long Stopwatch<T>(Action<T> method, T obj)
        {
            return Stopwatch(new Action(() =>
            {
                method.Invoke(obj);
            }));
        }

    }
}
