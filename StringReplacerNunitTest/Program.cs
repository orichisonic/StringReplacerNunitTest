using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReplacerNunitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestStringReplacer.TestNoList();
            TestStringReplacer.TestHasList();
            TestStringReplacer.TestCompareWithListandNoList();
            TestReplacer.Test();
        }
    }
}
