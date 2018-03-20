using FormInterface.model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace FormInterface.controller
{
    sealed class HTMLParser
    {

        public static void readTheUrl()
        { 
           formular.url = view.URLFormSubmitter.UrlImput.Text;
        }

        public static void setPageSourceCode()
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(formular.url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            formular.HtmlCode = sr.ReadToEnd();
            sr.Close();
        }

        public static void convertHTMLCodeToXML()
        {
            formular.HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            formular.HtmlDoc.LoadHtml(formular.HtmlCode);
        }

        public static void extractFormFromXML()
        {
            HtmlNode.ElementsFlags.Remove("form");
            formular.HtmlForm = formular.HtmlDoc.DocumentNode.SelectSingleNode("//form");
        }

        public static void writeTheFormular()
        {
            try
            {
                view.URLFormSubmitter.XMLFormularText.Text = formular.HtmlForm.OuterHtml;
            }
            catch(Exception)
            {
                view.URLFormSubmitter.XMLFormularText.Text = "no form found !!";
            }

        }

        

    }
}
