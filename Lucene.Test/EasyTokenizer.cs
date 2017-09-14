using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;

namespace Lucene.Test
{
    class EasyTokenizer : Tokenizer
    {
        private static bool flag = true;
        public override bool IncrementToken()
        {
            if (flag)
            {
                flag = false;
                return true;
            }
            return false;
        }
    }
}
