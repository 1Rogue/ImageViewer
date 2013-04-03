using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ImageViewer
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [MTAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length < 2)
            {
                IMV.setOpeningFile("C:/Users/Spencer/Documents/My Actual Documents/c#/Work/ImageTest/smalltest.png");
                //Application.Exit();
            }
            else
            {
                IMV.setOpeningFile(args[1]);
            }
            CConsole consolebox = new CConsole();
            Task newConsole = new Task (() => {
                System.Threading.CancellationTokenSource source = new System.Threading.CancellationTokenSource();

                Application.Run(consolebox);

                source.Cancel();
            });
            ImageViewer.IMV.setConsole(consolebox);
            newConsole.Start();
            consolebox.printLine("Console Started.");
            consolebox.getConsole().Select(1, 1);
            consolebox.getConsole().SelectionColor = System.Drawing.Color.Red;
            consolebox.printLine("Starting ImageViewer...");
            Application.Run(new Viewer());
            consolebox.end();
            over(newConsole);
        }

        static void over(Task newConsole)
        {
            if (newConsole.IsCompleted || newConsole.IsCanceled)
            {
                newConsole.Dispose();
            }
            else
            {
                over(newConsole);
            }
        }
    }
}
