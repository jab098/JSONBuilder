using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.IO.Compression;
using System.ComponentModel;
using System.Windows.Forms;

namespace Json_Builder
{
    class GetAndSort
    {
        //String that points to the path of the current users desktop
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\Schemas";

        //static binding lists that can be accessed by the form.cs for the boxes.
        public static BindingList<JObject> CCACaseSchemas = new BindingList<JObject>();
        public static BindingList<JObject> CCAAuthSchemas = new BindingList<JObject>();
        public static BindingList<JObject> NDRListSchemas = new BindingList<JObject>();
        public static BindingList<JObject> NDRValuationSchemas = new BindingList<JObject>();
        public static BindingList<JObject> CustomerSchemas = new BindingList<JObject>();

        //Method that obtains all of the schemas using web scraping and downloading and organises them into the lists
        public static void GetNSort()
        {
            #region URL's and authentication
           

            #endregion

            #region NDR List
            //Gets Source Code of the NDR List API page
            var ndrListSource = GetSource(ref NDRListUrl);

                //Removes comments so no CDATA in comments is caught by the scraper
                ndrListSource = Scrape.RemoveComments(ref ndrListSource);

                //scrapes the source with removed comments for CDATA
                var scrapedNdrListSource = Scrape.ScrapeSource(ref ndrListSource);

                //parses the cdata and adds it to the list of ndrlistschemas
                foreach (var item in scrapedNdrListSource)
                {
                    string parsed = CDATAParser.Parse(item);
                    JObject converted = JObject.Parse(parsed);

                    //if the title of the schema is a base schema its display member is altered
                    string x = converted.Property("title").ToString();
                    if (x == "\"title\": \"NDR List Property Valuation History View\"")
                    {

                        converted.Property("title").AddAfterSelf(new JProperty("displaymember", "(BASE SCHEMA)NDR List Property Valuation History View"));
                    }
                    //else the display member is assigned as the title where not 
                    else
                    {
                        string y = converted.Property("id").ToString();
                        int pos = y.LastIndexOf('/') + 1;
                        y = y.Substring(pos, y.Length - pos);
                        converted.Property("title").AddAfterSelf(new JProperty("displaymember", y));
                    }

                    NDRListSchemas.Add(converted);
                }
            #endregion

            #region CCA Authorisation
            var ccaAuthSource = GetSource(ref CCAAuthUrl);
                ccaAuthSource = Scrape.RemoveComments(ref ccaAuthSource);
                var scrapedAuthSource = Scrape.ScrapeSource(ref ccaAuthSource);
                foreach (var item in scrapedAuthSource)
                {
                    string parsed = CDATAParser.Parse(item);
                    JObject converted = JObject.Parse(parsed);

                    string x = converted.Property("title").ToString();
                    if (x == "\"title\": \"Authorisation View\"")
                    {
                        converted.Property("title").AddAfterSelf(new JProperty("displaymember", "(BASE SCHEMA)Authorisation View"));
                    }
                    else
                    {
                        string y = converted.Property("id").ToString();
                        int pos = y.LastIndexOf('/') + 1;
                        y = y.Substring(pos, y.Length - pos);
                        converted.Property("title").AddAfterSelf(new JProperty("displaymember", y));
                    }

                    CCAAuthSchemas.Add(converted);
                }
            #endregion

            #region NDR Valuation
            var ndrValuationSource = GetSource(ref NDRValuationUrl);
                ndrValuationSource = Scrape.RemoveComments(ref ndrValuationSource);
                var scrapedNdrValuationSource = Scrape.ScrapeSource(ref ndrValuationSource);
                foreach (var item in scrapedNdrValuationSource)
                {
                    string parsed = CDATAParser.Parse(item);
                    JObject converted = JObject.Parse(parsed);

                    string x = converted.Property("title").ToString();
                    if (x == "\"title\": \"Valuation Common Types\"")
                    {
                        converted.Property("title").AddAfterSelf(new JProperty("displaymember", "(BASE SCHEMA)Valuation Common Types"));
                    }
                    else
                    {
                        string y = converted.Property("id").ToString();
                        int pos = y.LastIndexOf('/') + 1;
                        y = y.Substring(pos, y.Length - pos);
                        converted.Property("title").AddAfterSelf(new JProperty("displaymember", y));
                    }
                    NDRValuationSchemas.Add(converted);
                }


            #endregion

            #region CCA Case

            try
            {
                Directory.CreateDirectory(path);
                //creates a WebClient to make a request to our URL
                var client = new WebClient();
                //Downloads files to directory specified
                client.DownloadFile(CCACaseUrl, path + "\\CCA Schemas.zip");
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Download", ex);
            }

            ZipFile.ExtractToDirectory(path + "\\CCA Schemas.zip", path + "\\CCA");
            File.Delete(path + "\\CCA Schemas.zip");
            var localCCASchemas = Directory.GetFiles(path + "\\CCA");

            try
            {
                foreach (var item in localCCASchemas)
                {

                    var readSchema = File.ReadAllText(item);
                    JObject converted = JObject.Parse(readSchema);
                    string x = converted.Property("title").ToString();
                    //names the base schema
                    if (converted.Property("title").ToString() == "\"title\": \"CCA Case Details\"" && converted.Property("id").ToString() == "\"id\": \"http://www.voa.gov.uk/schema/CCACheckCaseGet\"")
                    {
                        converted.Property("title").AddAfterSelf(new JProperty("displaymember", "(BASE SCHEMA)CCA Check Case Get Details"));
                    }
                    else
                    {
                        string y = converted.Property("id").ToString();
                        int pos = y.LastIndexOf('/') + 1;
                        y = y.Substring(pos, y.Length - pos);
                        converted.Property("title").AddAfterSelf(new JProperty("displaymember", y));
                    }
                    CCACaseSchemas.Add(converted);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            #endregion

            #region Customer

            try
            {
                //creates a WebClient to make a request to our URL
                var client = new WebClient();
                //Downloads files to directory specified
                client.DownloadFile(CustomerUrl, path + "\\Customer Schemas.zip");
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Download", ex);
            }

            ZipFile.ExtractToDirectory(path + "\\Customer Schemas.zip", path + "\\Customer");
            File.Delete(path+"\\Customer Schemas.zip");
            var localCustomerSchemas = Directory.GetFiles(path + "\\Customer");

            foreach (var item in localCustomerSchemas)
            {
                var readSchema = File.ReadAllText(item);
                JObject converted = JObject.Parse(readSchema);
                string x = converted.Property("title").ToString();
                //names base schema
                if (x == "\"title\": \"Organisation Details\"")
                {
                    converted.Property("title").AddAfterSelf(new JProperty("displaymember", "(BASE SCHEMA)Organisation - Get Details"));
                }
                else
                {
                    string y = converted.Property("id").ToString();
                    int pos = y.LastIndexOf('/') + 1;
                    y = y.Substring(pos, y.Length - pos);
                    converted.Property("title").AddAfterSelf(new JProperty("displaymember", y));
                }

                CustomerSchemas.Add(converted);
            }

            #endregion
            
            Directory.Delete(path, true);
        }

        //Method that Gets the source of the entered URL - uses ref to save memory
        public static string GetSource(ref Uri url)
        {
            //creates http request for the url
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //catches the response 
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse(); 
            //reads the response caught using a Stream Reader
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            //Stores response in string
            string sourceCode = sr.ReadToEnd();

            //close stream/response
            sr.Close();
            resp.Close();

            return sourceCode;
        }

    }
}
