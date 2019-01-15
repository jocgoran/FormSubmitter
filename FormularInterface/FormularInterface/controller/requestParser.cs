using FormInterface.model;
using System;
using System.Net;
using System.Text;

namespace FormInterface.controller
{
    class requestParser
    {

        private static int iChoosenFormNr;
        private static string action;
        private static string postParam;

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
            // reset the param list
            postParam = "?";

            // read the form that have to be submitted  
            iChoosenFormNr = Convert.ToInt32(view.URLFormSubmitter.ChoosenForm.SelectedItem);

            // loop over each row  
            for (int i = 0; i < (view.URLFormSubmitter.XMLFormularText.Rows.Count - 1); i++)
            {
                // read only choosen form
                if (Convert.ToInt32(view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[1].Value) == iChoosenFormNr)
                {
                    // read the action
                    if (view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        action=view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[2].Value.ToString();

                    // handle only certain field types
                    string FieldType = view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[3].Value.ToString();
                    switch (FieldType.ToLower())
                    { 
                        case "text":
                        case "checkbox":
                        {
                            // read the name
                            if (view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[4].Value.ToString() != string.Empty)
                            {
                                if (postParam.Length > 1) postParam += "&";
                                postParam += view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[4].Value.ToString();
                            }
                            // read the value
                            if (view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[5].Value.ToString() != string.Empty)
                            {
                                postParam += "=" + view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[5].Value.ToString();
                            }
                        break;
                        }  // end case
                    } //endswitch
                } //end handling ofchoosen form
            } //End loop    
        }

        public static void BuildURLRequest()
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(postParam);

            // Set the ContentLength property of the WebRequest.  
            //URLRequest.HttpRequest.ContentLength = byteArray.Length;

            // Create the URL 
            if ("http" == action.Substring(0, 4))
               {
                // use the whole new path
                HtmlDocData.url = action;
               } 
            else 
               {
                //  extract path until last / and add new page
                HtmlDocData.url = HtmlDocData.url + action;
               }

            // Build the URI together
            HtmlDocData.url = HtmlDocData.url + postParam;

            // Create a request
            URLRequest.HttpRequest = (HttpWebRequest)WebRequest.Create(HtmlDocData.url);
        }

    }
}
