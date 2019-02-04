using FormInterface.model;
using System.Net;

namespace FormInterface.controller
{
    class DataRenderer
    {

        public static void WriteCookiesToGUI()
        {
            view.URLFormSubmitter.CookiesOutput.Text = "Content of the Cookies\r\n";
            view.URLFormSubmitter.CookiesOutput.AppendText("--------------------\r\n");
            view.URLFormSubmitter.CookiesOutput.AppendText(URLRequest.CookieHeader +"\r\n");
            foreach (Cookie cookie in URLRequest.SiteCookiesCollection)
            {
                view.URLFormSubmitter.CookiesOutput.AppendText(cookie.Name + ": " + cookie.Value + "\r\n");
                view.URLFormSubmitter.CookiesOutput.AppendText("Domain: " + cookie.Domain + "\r\n");
                view.URLFormSubmitter.CookiesOutput.AppendText("Path: " + cookie.Path + "\r\n");
                view.URLFormSubmitter.CookiesOutput.AppendText("Port: " + cookie.Port + "\r\n");
                view.URLFormSubmitter.CookiesOutput.AppendText("Secure: " + cookie.Secure + "\r\n");
                view.URLFormSubmitter.CookiesOutput.AppendText("\r\n");
                view.URLFormSubmitter.CookiesOutput.AppendText("When issued: " + cookie.TimeStamp + "\r\n");
                view.URLFormSubmitter.CookiesOutput.AppendText("Expires: " + cookie.Expires + " (expired? " + cookie.Expired + ")\r\n");
                view.URLFormSubmitter.CookiesOutput.AppendText("Don't save: " + cookie.Discard + "\r\n");
                view.URLFormSubmitter.CookiesOutput.AppendText("Comment: " + cookie.Comment + "\r\n");
                view.URLFormSubmitter.CookiesOutput.AppendText("Uri for comments: " + cookie.CommentUri + "\r\n");
                string CookieRFC = cookie.Version == 1 ? "2109" : "2965";
                view.URLFormSubmitter.CookiesOutput.AppendText("Version: RFC {0}" + CookieRFC + "\r\n");
                // Show the string representation of the cookie.
                view.URLFormSubmitter.CookiesOutput.AppendText("String: " + cookie.ToString() + "\r\n");
            }
        }

        public static void WriteURLToGUI()
        {
            view.URLFormSubmitter.UrlImput.Text = HtmlDocData.url;
        }
    }
}
