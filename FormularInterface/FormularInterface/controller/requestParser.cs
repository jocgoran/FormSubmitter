using FormInterface.model;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace FormInterface.controller
{
    class requestParser
    {

        private static int iChoosenFormNr;
        private static string action;
        private static string postParam;
        private static string postData;

        internal static void BuildHeader()
        {
            URLRequest.HttpRequest.Method = "POST";

            URLRequest.HttpRequest.Method = WebRequestMethods.Http.Post;
            URLRequest.HttpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            URLRequest.HttpRequest.AllowWriteStreamBuffering = false;
            URLRequest.HttpRequest.ProtocolVersion = HttpVersion.Version11;
            URLRequest.HttpRequest.AllowAutoRedirect = false;
            URLRequest.HttpRequest.ContentType = "application/x-www-form-urlencoded";
        }

        public static void BuildFormular()
        {
            // read the form that have to be submitted  
            iChoosenFormNr = Convert.ToInt32(view.URLFormSubmitter.ChoosenForm.SelectedItem);

            // loop over each row  
            for (int i = 0; i < (view.URLFormSubmitter.XMLFormularText.Rows.Count - 1); i++)
            {
                // read only choosen form
                if (Convert.ToInt32(view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[0].Value) == iChoosenFormNr)
                {
                    // read the action
                    if (view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        action=view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[1].Value.ToString();
                    // read the name
                    if (view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[3].Value.ToString() != string.Empty)
                    {
                        if (postParam.Length == 0) postParam = "?";
                        else postParam = "&";
                        postParam = view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[1].Value.ToString();
                    }
                    // read the value
                    if (view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[3].Value.ToString() != string.Empty)
                    { 
                        postParam = postParam + "=" + view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[1].Value.ToString();
                    }
                }
            }


            postData = action + postParam;
        }

        public static void BuildURLRequest()
        {

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentLength property of the WebRequest.  
            URLRequest.HttpRequest.ContentLength = byteArray.Length;
            // Create the URL 
            if ("http" == HtmlDocData.url.Substring(0, 4))
               {
             // use the whole new path
               } 
            else 
               {
              //  extract path until last / and add new page
               }

            // Create a request
            URLRequest.HttpRequest = (HttpWebRequest)WebRequest.Create(HtmlDocData.url);
            // Get the request stream.  
            Stream dataStream = URLRequest.HttpRequest.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();


        }

    }
}
