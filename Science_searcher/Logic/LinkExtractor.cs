using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Science_searcher.Logic
{

    public static class LinkExtractor
    {
        public static List<string> Find(string context)
        {
            string hrefString = String.Empty;
            List<string> list = new List<string>();

            MatchCollection m1 = Regex.Matches(context, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);

            foreach (Match m in m1)
            {
                string value = m.Groups[1].Value;
                Match m2 = Regex.Match(value, @"href=\""(.*?)\""", RegexOptions.Singleline);
                if (m2.Success)
                    hrefString = m2.Groups[1].Value;
          
                list.Add(hrefString);
            }
            return list;
        }
    }
}
