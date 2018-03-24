using FormInterface.model;
using System;

namespace FormInterface.controller
{
    class requestParser
    {

        internal static void BuildHeader()
        {
            URLRequest.HttpWebRequest.Method = "POST";
        }

        public static void BuildFormular()
        {
            // serialize xml formular

            URLRequest.RequestFormular = "b";
        }

        public static void BuildURLrequest()
        {
            URLRequest.PostRequest = "c";
        }
        
    }
}
