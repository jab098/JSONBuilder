using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_Builder
{
    class CDATAParser
    {
        //Very basic XML escaper which parses CDATA and turns it to its original form
        public static string Parse(string input)
        {
            //returns the parsed string. Replaces all '&quot;' with the original ' " ' (double quotation marks)
            return input.Replace("&quot;", '"'.ToString());
        }
    }
}