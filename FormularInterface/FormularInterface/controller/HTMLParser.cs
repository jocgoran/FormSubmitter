using FormInterface.model;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;

namespace FormInterface.controller
{
    sealed class HTMLParser
    {

        public static void readTheUrl()
        { 
           HtmlDocData.url = view.URLFormSubmitter.UrlImput.Text;
        }

        public static void setPageSourceCode()
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HtmlDocData.url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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
                        if (HtmlFormNode.Attributes["type"] != null)
                           sInputType = HtmlFormNode.Attributes["type"].Value;
                        if (HtmlFormNode.Attributes["name"] != null)
                            sInputName = HtmlFormNode.Attributes["name"].Value;
                        if (HtmlFormNode.Attributes["value"] != null)
                            sInputValue = HtmlFormNode.Attributes["value"].Value;
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
            foreach (var item in HtmlDocData.FormExtractedData)
            {
                Console.Write(item.Key);
                Console.Write(item.Value.form);
                Console.Write(item.Value.action);
                string output = item.Value.name + " " + item.Value.value;
                view.URLFormSubmitter.XMLFormularText.Text = output;
            }

        }   


    }
}
