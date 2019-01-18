using FormInterface.model;
using System.Net;
using System.Xml;

namespace FormInterface.controller
{
    class Navigator
    {

        public static void Init()
        {
            // create the URLRequest with its data
            new URLRequest();
        }

        // This is called from the button that send the URL to get the formular
        public static void ButtonURLGetRequest()
        {
            Init();
            // read the url
            HTMLParser.ReadTheUrl();
            // Get the Request and render form 
            GetAndRenderPageData();
        }

        // This is called from the button that send the formular
        public static void SendPostRequest()
        {
            // Build the Header
            requestParser.BuildHeader();
            // Build the FORM
            requestParser.BuildFormular();
            // Build the request
            requestParser.BuildURLRequest();
            // Get the Request and render form
            GetAndRenderPageData();
            
        }

        public static void GetAndRenderPageData()
        {
            // clear the data
            HTMLParser.Clear();
            // get HTML Code
            HTMLParser.SetPageSourceCodeAndCookies();
            //render cookies to GUI
            DataRenderer.WriteCookiesToGUI();
            //renderURL to GUI
            DataRenderer.WriteURLToGUI();
            // Convert to XML 
            HTMLParser.ConvertHTMLCodeToXML();
            // extract the form 
            HTMLParser.ExtractFormFromXML();
            // render XML to GUI
            HTMLParser.FillFormToDataCollection();
            // render XML to GUI
            HTMLParser.RenderFormDataCollection();
        }

    }
}
