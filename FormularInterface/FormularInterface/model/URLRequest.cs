using System.Net;
using System.Text;

namespace FormInterface.model
{

    // know the URL structure and ist data meaning
    class URLRequest
    {

        //The cookies will be here.
        public static CookieCollection cookiesCollection { get; set; }
        public static HttpWebRequest HttpRequest { get; set; }
    }
}
