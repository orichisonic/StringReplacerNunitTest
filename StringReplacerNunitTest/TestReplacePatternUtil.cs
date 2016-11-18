using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;

namespace StringReplacerNunitTest
{
    public class TestReplacePatternUtil
    {
        [Test]
        public static void Test()
        {
            string sourcestr =
               "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)" +
          "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)" +
          "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)" +
          "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)" +
          "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)" +
          "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)";


            string oldstr = "#level#";
            string newvalstr = "#username#";
            byte[] sourceBytes = Encoding.ASCII.GetBytes(sourcestr.Replace(" ", ""));
            byte[] oldBytes = Encoding.ASCII.GetBytes(oldstr.Replace(" ", ""));
            byte[] newBytes = Encoding.ASCII.GetBytes(newvalstr.Replace(" ", ""));
            string oldstr1 = "!username!";
            string newvalstr1 = "#level#";
            byte[] oldBytes1 = Encoding.ASCII.GetBytes(oldstr.Replace(" ", ""));
            byte[] newBytes1 = Encoding.ASCII.GetBytes(newvalstr.Replace(" ", ""));
            string oldstr2 = "@param1,@param2,@param3";
            string newvalstr2 = "@param4,@param5,@param6";
            byte[] oldBytes2 = Encoding.ASCII.GetBytes(oldstr.Replace(" ", ""));
            byte[] newBytes2 = Encoding.ASCII.GetBytes(newvalstr.Replace(" ", ""));
            //100万次计算  
            var arr = System.Linq.Enumerable.Range(1, 1000000);
            //方法1  
            Action act = () =>
            {
                foreach (var k in arr)
                {
                    ReplacePatternUtil.Replace(sourceBytes, oldBytes, newBytes);
                }
            };
            //方法0  
            Action act0 = () =>
            {
                foreach (var k in arr)
                {
                    sourcestr.Replace(oldstr, newvalstr);
                }
            };

            //老的用时  
            System.Diagnostics.Debug.WriteLine("老的用时" + StopWatchMonitor.Stopwatch(act0));
            //array 用时1828  
            System.Diagnostics.Debug.WriteLine("array 用时" + StopWatchMonitor.Stopwatch(act));


        }
    }
}
