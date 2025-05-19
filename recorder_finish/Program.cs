using System;
using System.Windows.Forms;
using recorder_finish; // <-- це важливо

namespace recorder_finish
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
