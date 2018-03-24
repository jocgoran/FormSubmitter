using FormInterface.model;
using System.Xml;

namespace FormInterface.controller
{
    class navigator
    {

        public static void ButtonURLGetRequest()
        {
            // clear the data
            HTMLParser.clear();
            // read the url
            HTMLParser.readTheUrl(); 
            // get HTML Code
            HTMLParser.setPageSourceCode();
            // Convert to XML 
            HTMLParser.convertHTMLCodeToXML();
            // extract the form 
            HTMLParser.extractFormFromXML();
            // render XML to GUI
            HTMLParser.fillFormToDataCollection();
            // render XML to GUI
            HTMLParser.renderFormDataCollection();
        }

        public void sendPostRequest()
        {
            // Build the Header
            requestParser.BuildHeader();
            // Build the FORM
            requestParser.BuildFormular();
            // Build the request
            requestParser.BuildURLrequest();
            // Send the request

            // read the url
            // read the url
        }

    }
}
