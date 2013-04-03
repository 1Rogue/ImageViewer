using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageViewer
{
    class Utils
    {
        public static void printStringArray(string[] array)
        {
            int i = 0;
            foreach (string temp in array)
            {
                IMV.getConsole().printLine(string.Concat("arg[", i, "] ", temp));
                i++;
            }
        }
    }
}
