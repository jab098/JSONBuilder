using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace Json_Builder
{
    class BuildJSON
    {
        public static void Build(BindingList<JObject> JObjectList)
        {
            foreach (var item in JObjectList)
            {
                item.Property("displaymember").Remove();
            }
            //Create result json object
            JObject result = JObjectList.First();
            string schema = result.Property("title").ToString();
            string saveName = string.Empty;
            switch(schema)
            {
                case "\"title\": \"(BASE SCHEMA)CCA Check Case Submission\"":
                    saveName = "\\Complete CCA Case Schema.json";
                    break;
                case "\"title\": \"(BASE SCHEMA)Valuation Common Types\"":
                    saveName = "\\Complete NDR Valuation Schema.json";
                    break;
                default:
                    break;
            }

        restart:
            //Searches baseline schema for references to other schemas using the Find Token class
            foreach (JToken token in result.FindTokens("$ref"))
            {
                //these 3 lines extract the last word from the reference, so that we can use that to search for 
                //the required json to insert from the referenced schema.
                string strToken = token.ToString();
                int pos = strToken.LastIndexOf("/") + 1;
                string searchParam = strToken.Substring(pos, strToken.Length - pos);

                //iterates over the JSON Object list
                foreach (var Jobj in JObjectList)
                {
                    //Uses the search parameter on each of the list items and replaces the found reference with 
                    //the required part of the referenced schema
                    foreach (var token2 in Jobj.FindTokens(searchParam))
                    {
                        JObject insertionPosition = (JObject)token.Parent.Parent;

                        insertionPosition.Property("$ref").Remove();
                        insertionPosition.Add(token2.Children());

                        goto restart;
                    }
                }
            }
            try
            {
                //Writes the finished result to a json file on the desktop
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (saveName != string.Empty)
                {
                    File.WriteAllText(desktop + saveName, result.ToString());
                }
                else
                {
                    File.WriteAllText(desktop + "\\schema.json", result.ToString());
                }

                MessageBox.Show("Json File creation successfull!");
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to generate JSON file", ex);
            }
           
        }
    }
}
