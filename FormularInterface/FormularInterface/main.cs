using FormInterface.view;
using System;
using System.Windows.Forms;

namespace FormInterface
{
    class main
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new URLFormSubmitter());
        }
    }
}
