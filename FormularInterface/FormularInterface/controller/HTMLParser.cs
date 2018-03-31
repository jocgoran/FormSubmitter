using FormInterface.model;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;

namespace FormInterface.controller
{
    sealed class HTMLParser
    {

        public static void clear()
        {
            HtmlDocData.HtmlCode = "";
            HtmlDocData.HtmlDoc = null;
            HtmlDocData.HtmlFormCollection = null;
            HtmlDocData.FormExtractedData.Clear();
            view.URLFormSubmitter.XMLFormularText.Rows.Clear();
        }

        public static void readTheUrl()
        { 
           HtmlDocData.url = view.URLFormSubmitter.UrlImput.Text;
        }

        public static void setPageSourceCodeAndCookies()
        {
            //Create a request
            URLRequest.HttpRequest = (HttpWebRequest)WebRequest.Create(HtmlDocData.url);

            //Create a Cookies Container
            URLRequest.HttpRequest.CookieContainer = new CookieContainer();

            // Add Collection from previous Page
            URLRequest.HttpRequest.CookieContainer.Add(URLRequest.cookiesCollection);

            //Get the response from the server
            HttpWebResponse response = (HttpWebResponse)URLRequest.HttpRequest.GetResponse();

            // Save the cookies from the response
            URLRequest.cookiesCollection = response.Cookies;

             // Print the properties of each cookie.
            foreach (Cookie cook in response.Cookies)
            {
                Console.WriteLine("Cookie:");
                Console.WriteLine("{0} = {1}", cook.Name, cook.Value);
                Console.WriteLine("Domain: {0}", cook.Domain);
                Console.WriteLine("Path: {0}", cook.Path);
                Console.WriteLine("Port: {0}", cook.Port);
                Console.WriteLine("Secure: {0}", cook.Secure);

                Console.WriteLine("When issued: {0}", cook.TimeStamp);
                Console.WriteLine("Expires: {0} (expired? {1})",
                    cook.Expires, cook.Expired);
                Console.WriteLine("Don't save: {0}", cook.Discard);
                Console.WriteLine("Comment: {0}", cook.Comment);
                Console.WriteLine("Uri for comments: {0}", cook.CommentUri);
                Console.WriteLine("Version: RFC {0}", cook.Version == 1 ? "2109" : "2965");

                // Show the string representation of the cookie.
                Console.WriteLine("String: {0}", cook.ToString());
            }   

            StreamReader sr = new StreamReader(response.GetResponseStream());
            HtmlDocData.HtmlCode = sr.ReadToEnd();
            sr.Close();
        }

        public static void convertHTMLCodeToXML()
        {
            HtmlDocData.HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlDocData.HtmlDoc.LoadHtml(HtmlDocData.HtmlCode);
        }

        public static void extractFormFromXML()
        {
            HtmlNode.ElementsFlags.Remove("form");
            HtmlDocData.HtmlFormCollection = HtmlDocData.HtmlDoc.DocumentNode.SelectNodes("//form");
        }

        public static void fillFormToDataCollection()
        {
            try
            {
                int iFormNr = 0;
                int iKey = 0;
                foreach (HtmlAgilityPack.HtmlNode HtmlFormNode in HtmlDocData.HtmlFormCollection)
                {
                    ++iFormNr;
                    ++iKey;
                    string sFormAction = HtmlFormNode.Attributes["action"].Value;
                    FormularData actualFormularData = new FormularData(iFormNr, sFormAction, "", "", "");
                    HtmlDocData.FormExtractedData.Add(iKey, actualFormularData);

                    foreach (HtmlAgilityPack.HtmlNode InputNode in HtmlFormNode.SelectNodes("//input"))
                    {
                        ++iKey;
                        string sInputType = "", sInputName = "", sInputValue = "";
                        if (InputNode.Attributes["type"] != null)
                           sInputType = InputNode.Attributes["type"].Value;
                        if (InputNode.Attributes["name"] != null)
                            sInputName = InputNode.Attributes["name"].Value;
                        if (InputNode.Attributes["value"] != null)
                            sInputValue = InputNode.Attributes["value"].Value;
                        FormularData actualInputData = new FormularData(iFormNr, "", sInputType, sInputName, sInputValue);
                        HtmlDocData.FormExtractedData.Add(iKey, actualInputData);
                    }
                }
            }
            catch(Exception ex)
            {
                view.URLFormSubmitter.XMLFormularText.Text = ex.ToString();
            }

        }

        public static void renderFormDataCollection()
        {

            view.URLFormSubmitter.XMLFormularText.Columns.Add("Key", "key");
            view.URLFormSubmitter.XMLFormularText.Columns.Add("Form", "form");
            view.URLFormSubmitter.XMLFormularText.Columns.Add("Action", "action");
            view.URLFormSubmitter.XMLFormularText.Columns.Add("Type", "type");
            view.URLFormSubmitter.XMLFormularText.Columns.Add("Name", "name");
            view.URLFormSubmitter.XMLFormularText.Columns.Add("Value", "value");

            foreach (var item in HtmlDocData.FormExtractedData)
            {
                view.URLFormSubmitter.XMLFormularText.Rows.Add(item.Key, 
                                                                item.Value.form,
                                                                item.Value.action,
                                                                item.Value.type,
                                                                item.Value.name,
                                                                item.Value.value);
            }
          
        }   


    }
}
