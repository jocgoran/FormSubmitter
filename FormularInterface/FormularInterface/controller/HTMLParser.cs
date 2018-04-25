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

         // Create a request
            URLRequest.HttpRequest = (HttpWebRequest)WebRequest.Create(HtmlDocData.url);
        }

        public static void setPageSourceCodeAndCookies()
        {
            //Create a Cookies Container
            URLRequest.HttpRequest.CookieContainer = new CookieContainer();

            // Add Collection from previous Page
            URLRequest.HttpRequest.CookieContainer.Add(URLRequest.cookiesCollection);

            // Get the response from the server
            HttpWebResponse response = (HttpWebResponse)URLRequest.HttpRequest.GetResponse();

            // Save the cookies from the response
            URLRequest.cookiesCollection = response.Cookies;

            // Read the remote stream
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

                    foreach (HtmlAgilityPack.HtmlNode InputNode in HtmlFormNode.SelectNodes(".//input"))
                    {
                        ++iKey;
                        string sInputType = "", sInputName = "", sInputValue = "";
                        if (InputNode.Attributes["type"] != null)
                           sInputType = InputNode.Attributes["type"].Value;
                        if (InputNode.Attributes["name"] != null)
                            sInputName = InputNode.Attributes["name"].Value;
                        if (InputNode.Attributes["value"] != null)
                            sInputValue = InputNode.Attributes["value"].Value;
                        FormularData actualFrmularELements = new FormularData(iFormNr, "", sInputType, sInputName, sInputValue);
                        HtmlDocData.FormExtractedData.Add(iKey, actualFrmularELements);
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
