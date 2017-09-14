using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;

namespace Lucene.Test
{
    class TestFactory
    {
        public static void TestFunc(Analyzer analyzer)
        {
            using (TokenStream ts = analyzer.ReusableTokenStream("", new StringReader(TestData.TestWords))) 
            { 
                while (ts.IncrementToken())
                {
                    Console.WriteLine(ts.TermText());
                }
            }
        }
    }
}
