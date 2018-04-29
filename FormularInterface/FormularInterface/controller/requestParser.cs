using FormInterface.model;
using System.IO;
using System.Net;
using System.Text;

namespace FormInterface.controller
{
    class requestParser
    {

        private static string action;
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
            for (int i = 0; i < (view.URLFormSubmitter.XMLFormularText.Rows.Count - 1); i++)
            {
                for (int j = 0; j < view.URLFormSubmitter.XMLFormularText.Columns.Count; j++)
                {
                    if (view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[j].Value.ToString() != string.Empty)
                    {
                        try
                        {
                            view.URLFormSubmitter.XMLFormularText.Rows[i].Cells[j].Value.ToString();
                        }
                        catch
                        {
                        }
                    }
                }
            }


            foreach (var item in HtmlDocData.FormExtractedData)
            {
                view.URLFormSubmitter.XMLFormularText.Rows.Add(item.Key,
                                                                item.Value.form,
                                                                item.Value.action,
                                                                item.Value.type,
                                                                item.Value.name,
                                                                item.Value.value);
            }

     //       postData = String.Format("j_username={0}&j_password={1}", username, password);
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
