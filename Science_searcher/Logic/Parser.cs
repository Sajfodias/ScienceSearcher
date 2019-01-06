using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace Science_searcher.Logic
{
    public class Parser
    {
        public string _content;
        public string _parsedContent;

        public Parser(string context)
        {
            _content = context;
        }

        public string RemoveUnusedContext(string content)
        {
            string result = String.Empty;

            return result;
        }
    }
}
