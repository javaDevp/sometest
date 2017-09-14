using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;

namespace Lucene.Test
{
    class MyCharTokenizer : CharTokenizer
    {
        public MyCharTokenizer(TextReader input)
            :base(input)
        {
            
        }

        protected override bool IsTokenChar(char c)
        {
            return c == '中';
        }
    }
}
