using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_Builder
{
    class Scrape
    {

        //Method that takes a string and finds all occurences of text between 2 strings within that string - uses ref to save memory
        public static List<string> ScrapeSource(ref string sourceCode)
        {
            string startString = "<![CDATA[";
            string endString = "]]>";

            //List of matched string inbetween parameter strings
            List<string> matched = new List<string>();

            int indexStart = 0, indexEnd = 0;

            //Exit loop ensures all possible matches are found
            bool exit = false;
            while (!exit)
            {
                indexStart = sourceCode.IndexOf(startString);
                indexEnd = sourceCode.IndexOf(endString);

                if (indexStart != -1 || indexEnd != -1)
                {
                    var x = (sourceCode.Substring(indexStart + startString.Length, indexEnd - indexStart - startString.Length));
                    sourceCode = sourceCode.Substring(indexEnd + endString.Length);

                    //adds the located match to the matches list
                    if (!x.Contains("RAML")) matched.Add(x);
                }
                else
                    exit = true;
            }
            return matched;
        }

        //Same as Scrape method except only returns the firsti teration of text found and not a list of matches.
        public static string ScrapeFirst(string sourceCode, string startString, string endString)
        {
            int indexStart = sourceCode.IndexOf(startString);
            int indexEnd = sourceCode.IndexOf(endString);

            if (indexStart != -1 || indexEnd != -1)
            {
                var x = (sourceCode.Substring(indexStart + startString.Length, indexEnd - indexStart - startString.Length));
                sourceCode = sourceCode.Substring(indexEnd + endString.Length);


                return x;
            }
            else
                return string.Empty;

        }

        //Removes the comments section of the Confluence source codes obtained.
        public static string RemoveComments(ref string input)
        {
            int index = input.IndexOf("<div id=\"comments-section\" class=\"pageSection group\">");
            return input.Substring(0, index);
        }
    }
}
