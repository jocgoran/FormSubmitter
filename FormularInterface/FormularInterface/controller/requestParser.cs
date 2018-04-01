using FormInterface.model;
using System;
using System.Net;

namespace FormInterface.controller
{
    class requestParser
    {

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
            // serialize xml formular

            //URLRequest.RequestFormular = "b";
        }

        public static void BuildURLRequest()
        {
            //URLRequest.PostRequest = "c";
        }

    }
}
