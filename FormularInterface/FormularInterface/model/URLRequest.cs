using System.Net;
using System.Text;

namespace FormInterface.model
{

    // know the URL structure and ist data meaning
    class URLRequest
    {

        //The cookies will be here.
        public static CookieCollection SiteCookiesCollection { get; set; }
        public static HttpWebRequest HttpRequest { get; set; }
        public static string CookieHeader{ get; set; }
        public static bool IsLoggedIn { get; set; }

        public URLRequest()
        {
            // Create a cookiescontainer for maintaining local data
            URLRequest.SiteCookiesCollection = new CookieCollection();
            IsLoggedIn = false;
        }
    }
}
