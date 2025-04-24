using System;
using System.Windows.Forms;

namespace DayZLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();     // Zorgt voor moderne UI-styling
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());      // Start je hoofdvenster
        }
    }
}
