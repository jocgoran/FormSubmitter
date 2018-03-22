using HtmlAgilityPack;
using System.Xml;
using System.Collections.Generic;

namespace FormInterface.model
{

    // know the Formular structure and is know the data
    class HtmlDocData
    {

        public static string url { get; set; }
        public static string HtmlCode { get; set; }
        public static HtmlAgilityPack.HtmlDocument HtmlDoc { get; set; }
        public static HtmlAgilityPack.HtmlNodeCollection HtmlFormCollection { get; set; }
        public static Dictionary<int, FormularData> FormExtractedData = new Dictionary<int, FormularData>();
    }

    class FormularData
    {
        public int form { get; set; }
        public string action { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public FormularData (int form, string action, string type, string name, string value)
        {
            this.form = form;
            this.action = action;
            this.type = type;
            this.name = name;
            this.value = value;
        }
    }
}
