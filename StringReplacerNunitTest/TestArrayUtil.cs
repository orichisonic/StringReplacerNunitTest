using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;
using System.Diagnostics;

namespace StringReplacerNunitTest
{
    public class TestArrayUtil
    {

        [Test]
        public static void Test()
        {
            try
            {

                byte[] org = System.Text.Encoding.GetEncoding("GBK").GetBytes("kadeadedcfdededghkk");

                byte[] search = System.Text.Encoding.GetEncoding("GBK").GetBytes("kk");



                int last = ArryUtil.lastIndexOf(org, search, 19);

                long t1 = 0;

                long t2 = 0;

                int f1 = 0;

                int f2 = 0;
                var arr = System.Linq.Enumerable.Range(1, 10000);
                //for (int i = 0; i < 10000; i++)
                //{

                //long s1 = System.nanoTime();
                Action act = () =>
                {
                    foreach (var k in arr)
                    {
                        f1 = ArryUtil.indexOf(org, search, 0);
                    }
                };
                //f1 = ArryUtil.indexOf(org, search, 0);

                //long s2 = System.nanoTime();
                Action act2 = () =>
                {
                    foreach (var k in arr)
                    {
                        f2 = "kadeadedcfdededghkk".IndexOf("kk",0);
                    }
                };
                //f2 = ArryUtil.indexOf(org, search);

                //long s3 = System.nanoTime();

                //t1 = t1 + (s2 - s1);

                //t2 = t2 + (s3 - s2);

                //}
                System.Diagnostics.Debug.WriteLine("kmp=" + StopWatchMonitor.Stopwatch(act) + ",ali=" +
                                                   StopWatchMonitor.Stopwatch(act2));


                System.Diagnostics.Debug.WriteLine("f1=" + f1 + ",f2=" + f2);

            }
            catch (Exception e)
            {


            }
        }

        [Test]
        public static void TestArrayReplace()
        {
            string sourcestr =
                 "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)" +
            "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)" +
            "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)" +
            "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)" +
            "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)" +
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
            byte[] oldresult = new byte[] { };
            string newresult = "";
            //方法1  
            Action act = () =>
            {
                foreach (var k in arr)
                {
                    oldresult = ArryUtil.arrayReplace(sourceBytes, oldBytes, newBytes, 0);
                }
            };
            //方法0  
            Action act0 = () =>
            {
                foreach (var k in arr)
                {
                    newresult=sourcestr.Replace(oldstr, newvalstr);
                }
            };
            bool boolvariable = (System.Text.Encoding.ASCII.GetString(oldresult) == newresult);
            Assert.IsTrue(boolvariable, "相等");
            //老的用时  
            System.Diagnostics.Debug.WriteLine("老的用时" + StopWatchMonitor.Stopwatch(act0));
            //array 用时1828  
            System.Diagnostics.Debug.WriteLine("array 用时" + StopWatchMonitor.Stopwatch(act));

            Stopwatch sw=new Stopwatch();
            sw.Start();
            ArryUtil.arrayReplace(sourceBytes, oldBytes, newBytes, 0);
            sw.Stop();
            var tick = sw.ElapsedTicks;
            sw.Restart();
            sourcestr.Replace(oldstr, newvalstr);
            sw.Stop();
            var tick2 = sw.ElapsedTicks;

          
            //老的用时  
            System.Diagnostics.Debug.WriteLine("老的用时" + tick2);
            //array 用时1828  
            System.Diagnostics.Debug.WriteLine("array 用时" + tick);

        }
    }
}
