using FormInterface.model;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;

namespace FormInterface.controller
{
    sealed class HTMLParser
    {

        public static void Clear()
        {
            HtmlDocData.HtmlCode = "";
            HtmlDocData.HtmlDoc = null;
            HtmlDocData.HtmlFormCollection = null;
            HtmlDocData.FormExtractedData.Clear();
            // clear DataGrid with form data 
            view.URLFormSubmitter.XMLFormularText.Rows.Clear();
            // clear drop down menu of choosen form
            view.URLFormSubmitter.ChoosenForm.Items.Clear();
        }

        public static void ReadTheUrl()
        { 
            HtmlDocData.url = view.URLFormSubmitter.UrlImput.Text;

           // Create a request
            URLRequest.HttpRequest = (HttpWebRequest)WebRequest.Create(HtmlDocData.url);
        }

        public static void SetPageSourceCodeAndCookies()
        {
            // Create a cookiescontainer for the response from the server
            URLRequest.HttpRequest.CookieContainer = new CookieContainer();

            // Add Collection from previous Page -  first time an empty collection
            URLRequest.HttpRequest.CookieContainer.Add(URLRequest.SiteCookiesCollection);

            // Get the response from the server
            HttpWebResponse response = (HttpWebResponse)URLRequest.HttpRequest.GetResponse();

            // Save the cookies from the response in the program collection
            URLRequest.SiteCookiesCollection = response.Cookies;

            // Read the remote stream
            StreamReader sr = new StreamReader(response.GetResponseStream());
            HtmlDocData.HtmlCode = sr.ReadToEnd();
            sr.Close();
            response.Close();
        }

        // used only to get the DOM structure
        public static void ConvertHTMLCodeToXML()
        {
            HtmlDocData.HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlDocData.HtmlDoc.LoadHtml(HtmlDocData.HtmlCode);
        }

        public static void ExtractFormFromXML()
        {
            HtmlNode.ElementsFlags.Remove("form");
            HtmlDocData.HtmlFormCollection = HtmlDocData.HtmlDoc.DocumentNode.SelectNodes("//form");
        }

        public static void FillFormToDataCollection()
        {
            try
            {
                // initialize metadata of DataGrid
                int iFormNr = 0;
                int iKey = 0;

                // loop over the HTML form element to extract the input fields
                foreach (HtmlAgilityPack.HtmlNode HtmlFormNode in HtmlDocData.HtmlFormCollection)
                {
                    ++iFormNr;
                    ++iKey;
                    view.URLFormSubmitter.ChoosenForm.Items.Add(iFormNr);

                    string sFormAction = HtmlFormNode.Attributes["action"].Value;
                    FormularData actualFormularData = new FormularData(iFormNr, sFormAction, "", "", "");
                    HtmlDocData.FormExtractedData.Add(iKey, actualFormularData);

                    // extract data from the input tag
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
                        //for each row create a new element to contain input node's values
                        FormularData actualFormularElements = new FormularData(iFormNr, "", sInputType, sInputName, sInputValue);
                        // add pair key - input values
                        HtmlDocData.FormExtractedData.Add(iKey, actualFormularElements);
                    }
                    
                }
            }
            catch(Exception ex)
            {
                view.URLFormSubmitter.XMLFormularText.Text = ex.ToString();
            }

        }

        public static void RenderFormDataCollection()
        {
            // this add the items extracted from the form to the DataGrid
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
