using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReplacerNunitTest
{
    public class TestReplacer
    {
        public TestReplacer()
        {
        }
        [Test]
        public static void Test()
        {

            string source = "select * from class where #level# in (@param1,@param2,@param3) and #username# in (@param1,@param2,@param3)";
          
            string replaceResult = source.Replace("#level#", "#username#");
           
            bool boolResult;

            boolResult = !string.IsNullOrEmpty(replaceResult);
            Assert.IsTrue(boolResult, "Replace函数替换成功");
            
            //Assert.IsFalse(boolResult,"替换失败");


        }
    }
}
