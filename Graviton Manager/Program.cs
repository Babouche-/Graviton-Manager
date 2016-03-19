using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Graviton_Manager
{
    static class Program
    {
        public static Server server;
             /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run((server = new Server("127.0.0.1",5000)).firstForm);
        }
    }
}
