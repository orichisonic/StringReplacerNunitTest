using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Common;

namespace StringReplacerNunitTest
{
    [TestFixture]
    public class TestStringReplacer
    {
       
        public TestStringReplacer()
        {
        }

        [Test]
        public static void TestNoList()
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
            byte[] replaceResult=StringReplacer.Replace(sourceBytes, oldBytes, newBytes);
            string result = System.Text.Encoding.ASCII.GetString(replaceResult);
            var boolResult = result.Replace(" ", string.Empty) == sourcestr.Replace(oldstr, newvalstr).Replace(" ", "");
            Assert.IsFalse(boolResult, "byte流替换替换成功");


          

        }
        [Test]
        public static void TestHasList()
        {
            string sourcestr = "select * from class where #level# in (@param1,@param2,@param3) and !username! in (@param1,@param2,@param3)";
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

            //全部替换  
            byte[] result = StringReplacer.Replace(sourceBytes, new List<HexReplaceEntity>()  
                                                   {  
                                                       new HexReplaceEntity()
                                                             {
                                                               oldValue = oldBytes,  
                                                               newValue =newBytes,  
                                                              } ,  
                                                       new HexReplaceEntity()
                                                              {
                                                               oldValue =oldBytes1,  
                                                               newValue =newBytes1,  
                                                              },  
                                                       new HexReplaceEntity()
                                                              {
                                                               oldValue = oldBytes2,  
                                                               newValue = newBytes2,  
                                                           },  
                                                   });
            string str2 = System.Text.Encoding.ASCII.GetString(result); ;
            //字符串替换检查  
            var boolresult = (str2.Replace(" ", string.Empty) != sourcestr
                .Replace(oldstr, newvalstr)
                .Replace(oldstr1, newvalstr1)
                .Replace(oldstr2, newvalstr2)
                .Replace(" ", string.Empty)
                );
            Assert.IsTrue(boolresult, "byte流批量 List替换成功");
        }

        [Test]
        public static void TestCompareWithListandNoList()
        {
            string sourcestr =
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

            //方法0  
            Action act0 = () =>
            {
                foreach (var k in arr)
                {
                    sourcestr.Replace(oldstr, newvalstr);
                }
            };

            //方法1  
            Action act = () =>
            {
                foreach (var k in arr)
                {
                    StringReplacer.Replace(sourceBytes, oldBytes, newBytes);
                }
            };

            //方法2  
            Action act2 = () => { foreach (var k in arr) { StringReplacer.ReplaceA(sourceBytes, oldBytes, newBytes); } };

         
            //方法多个 List替换  
            Action act3 = () => { foreach (var k in arr)
                {
                    StringReplacer.Replace(sourceBytes, new List<HexReplaceEntity>()
                                                   {
                                                       new HexReplaceEntity()
                                                             {
                                                               oldValue = oldBytes,
                                                               newValue =newBytes,
                                                              } ,
                                                       new HexReplaceEntity()
                                                              {
                                                               oldValue =oldBytes1,
                                                               newValue =newBytes1,
                                                              },
                                                       new HexReplaceEntity()
                                                              {
                                                               oldValue = oldBytes2,
                                                               newValue = newBytes2,
                                                           },
                                                   });
                } };
            //老的用时  
            System.Diagnostics.Debug.WriteLine("老的用时" + StopWatchMonitor.Stopwatch(act0));
            //array 用时1828  
            System.Diagnostics.Debug.WriteLine("array 用时" + StopWatchMonitor.Stopwatch(act));
            //list 用时2481  
            System.Diagnostics.Debug.WriteLine("list 用时" + StopWatchMonitor.Stopwatch(act2));

            //多个 List替换  
            System.Diagnostics.Debug.WriteLine("多个 List替换   用时" + StopWatchMonitor.Stopwatch(act3));


        }
    }
}
