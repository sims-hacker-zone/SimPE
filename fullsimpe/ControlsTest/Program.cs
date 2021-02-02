using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlsTest
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt fÃ¼r die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}