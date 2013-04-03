using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageViewer
{
    class TimeTo
    {
        private static int time = 0;

        public static void StartTimer()
        {
            time = System.DateTime.Now.Millisecond;
        }

        public static void StopTimer()
        {
            time = System.DateTime.Now.Millisecond - time;
        }

        public static int getTime()
        {
            return time;
        }
    }
}
