using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Com.Centaline.Framework.Kernel.placeholder;
using Common;


namespace StringReplacerNunitTest
{

    public class TestPlaceHolder
    {
      //[Test]
        public static void TestPlaceHolderReplace()
        {

            string content = "select  @classname@ from @test3@ where @Pattern@='3' and @Pattern@='4' ";
            content += content;
            content += content;
            content += content;
            content += content;
            content += content;
            content += content;
            content += content;
            content += content;
            content += content;


            var test =
                new PazoPlaceHolderStringParser(
                    new PazoParameterPreparerPlaceHolderEnsurer(new PazoStringParameterValueFormatter())
                    , new PazoPlaceHolderAnalyzer()
                    , new PazoPlaceHolderValidator());
            Dictionary<string, object> propertys = new Dictionary<string, object>();

            propertys.Add("Pattern", "yyyy-MM-dd HH:mm:ss");
            propertys.Add("classname", "test2");
            propertys.Add("test3", "test5");
            PlaceHolderScheme ps=new PlaceHolderScheme();
            ps.setPrefix("@");
            ps.setSuffix("@");
            ((PazoParameterPreparerPlaceHolderEnsurer) test.getPlaceHolderEnsurer()).AppendParamter(propertys);
            //test.setPlaceHolderEnsurer(new PazoStringParameterValueFormatter().format());
            int count = 1;
            Stopwatch st=new Stopwatch();
            st.Start();
            for(int i=0;i< count; i++)
            {
                test.parse(content, ps);
            }
            st.Stop();
            Console.WriteLine("用时" + st.ElapsedMilliseconds);


            st.Restart();
            for (int i = 0; i < count; i++)
            {
                content =content.Replace("@Pattern@", "yyyy-MM-dd HH:mm:ss")
                        .Replace("@classname@", "test2")
                        .Replace("@test3@", "test5");
            }
            st.Stop();
            Console.WriteLine("MS 用时" + st.ElapsedMilliseconds);
            //Action act = () =>
            //{
            //    foreach (var k in arr)
            //    {
            //        test.parse(content, ps);
            //    }
            //};
            //Action act2 = () =>
            //{
            //    foreach (var k in arr)
            //    {
            //        content =
            //            content.Replace("@Pattern@", "yyyy-MM-dd HH:mm:ss")
            //                .Replace("@classname@", "test2")
            //                .Replace("@test3@", "test5");

            //    }


            //};
            //System.Diagnostics.Debug.WriteLine("用时" + StopWatchMonitor.Stopwatch(act));
            //System.Diagnostics.Debug.WriteLine("老的用时" + StopWatchMonitor.Stopwatch(act2));

        }
    }
}
