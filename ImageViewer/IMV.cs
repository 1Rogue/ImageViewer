using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageViewer
{
    class IMV
    {
        static CConsole consolebox;
        static string openingFile;

        public static CConsole getConsole()
        {
            return consolebox;
        }

        public static void setConsole(CConsole console)
        {
            consolebox = console;
        }

        public static string getOpeningFile()
        {
            return openingFile;
        }

        public static void setOpeningFile(string location)
        {
            openingFile = location;
        }
    }
}
