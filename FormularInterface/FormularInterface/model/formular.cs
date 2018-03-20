using HtmlAgilityPack;
using System.Xml;

namespace FormInterface.model
{
     
    // know the Formular structure and is know the data
    class formular
    {

        public static string url { get; set; }
        public static string HtmlCode { get; set; }
        public static HtmlAgilityPack.HtmlDocument HtmlDoc { get; set; }
        public static HtmlAgilityPack.HtmlNode HtmlForm { get; set; }
    }
}
