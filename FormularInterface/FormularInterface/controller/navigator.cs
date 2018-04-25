using FormInterface.model;
using System.Net;
using System.Xml;

namespace FormInterface.controller
{
    class navigator
    {

        public static void init()
        {
            URLRequest.cookiesCollection = new CookieCollection();
        }

        public static void ButtonURLGetRequest()
        {
            init();
            // clear the data
            HTMLParser.clear();
            // read the url
            HTMLParser.readTheUrl();
            // Get the Request and render form 
            getAndRenderPageData();
        }

        public static void sendPostRequest()
        {
            // Build the Header
            requestParser.BuildHeader();
            // Build the FORM
            requestParser.BuildFormular();
            // Build the request
            requestParser.BuildURLRequest();
            // Get the Request and render form
            getAndRenderPageData();
            
        }

        public static void getAndRenderPageData()
        {
            // get HTML Code
            HTMLParser.setPageSourceCodeAndCookies();
            // Convert to XML 
            HTMLParser.convertHTMLCodeToXML();
            // extract the form 
            HTMLParser.extractFormFromXML();
            // render XML to GUI
            HTMLParser.fillFormToDataCollection();
            // render XML to GUI
            HTMLParser.renderFormDataCollection();
        }

    }
}
