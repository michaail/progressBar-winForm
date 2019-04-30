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
        /// Example on how to use MProgressBar
        /// </summary>
        [STAThread]
        static void Main()
        {
            // apps setting
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // create cancellation token source
            System.Threading.CancellationTokenSource cts = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationToken ct = cts.Token;
            string infoText = "";

            // instantiate progress bar and pass CancellationTokenSource
            MProgressBar myProgress = new MProgressBar(cts);

            // runs a method (async gives cancellation exception handling)
            Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    i++;
                    Console.WriteLine("some work");
                    myProgress.infoText = $"counting... {i}";
                    System.Threading.Thread.Sleep(1000);
                    
                    // watch for cancelation request
                    ct.ThrowIfCancellationRequested();
                }
            });

            
            // run progress bar form
            Application.Run(myProgress);

        }
    }
}
