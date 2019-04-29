using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MProgressBar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Tasks.Task pgBar = Task.Run(() =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CancellableProgressBar());
            });
            while(true)
            {
                Console.WriteLine("HEllo there");
                System.Threading.Thread.Sleep(1000);
            }
            
        }
    }
}
