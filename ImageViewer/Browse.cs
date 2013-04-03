using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace ImageViewer
{
    class Browse
    {

        private string fileLoc = "";
        private string currentFile = "";
        private string fileDir = "";
        private string[] dirFiles;
        private int arrayloc = 0;

        public Browse(string newimage)
        {
            fileDir = new FileInfo(newimage).DirectoryName;
            dirFiles = System.IO.Directory.GetFiles(fileDir, "*.*").Where(file => file.ToLower().EndsWith("png") || file.ToLower().EndsWith("gif") || file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("bmp") || file.ToLower().EndsWith("dib") || file.ToLower().EndsWith("jfif") || file.ToLower().EndsWith("jpe") || file.ToLower().EndsWith("tif") || file.ToLower().EndsWith("tiff") || file.ToLower().EndsWith("wdp")).ToArray();
            setCurrentInfo(newimage);
            arrayloc = getLocationInArray(dirFiles);
        }

        private void setCurrentInfo(string input)
        {
            fileLoc = new FileInfo(input).FullName;
            currentFile = new FileInfo(input).Name;
        }

        public string getDirectory(string filePath)
        {
            return fileDir;
        }

        public string[] getFiles(string dir)
        {
            return dirFiles;
        }

        private int getNext()
        {
            if (arrayloc == dirFiles.Length - 1)
            {
                return 0;
            }
            return arrayloc + 1;
        }

        private int getPrev()
        {
            if (arrayloc == 0)
            {
                return dirFiles.Length - 1;
            }
            return arrayloc - 1;
        } 

        public int getLocationInArray(Array input)
        {
            int w = Array.IndexOf(input, fileLoc);
            if (w < 0)
            {
                IMV.getConsole().printLine("Index = -1!");
                w = (w * -1);
                IMV.getConsole().printLine("Converted to 1");
            }
            return w;
        }

        public string nextImage()
        {
            arrayloc = getNext();
            setCurrentInfo(dirFiles[arrayloc]);
            IMV.getConsole().printLine("Time taken for method A(milliseconds): " + TimeTo.getTime());
            return fileLoc;
        }

        public string nextImageB()
        {
            arrayloc = getNext();
            setCurrentInfo(dirFiles[arrayloc]);
            if (!verifyImage())
            {
                nextImageB();
            }
            IMV.getConsole().printLine("Time taken for method B(milliseconds): " + TimeTo.getTime());
            return fileLoc;
        }

        public string getNextImage()
        {
            return new FileInfo(dirFiles[getNext()]).Name;
        }

        public string prevImage()
        {
            arrayloc = getPrev();
            setCurrentInfo(dirFiles[arrayloc]);
            return fileLoc;
        }

        public string getPrevImage()
        {
            return new FileInfo(dirFiles[getPrev()]).Name;
        }

        public string getCurrentImage()
        {
            return currentFile;
        }

        public string getCurrentFile()
        {
            return fileLoc;
        }

        private bool verifyImage()
        {
            TimeTo.StartTimer();
            bool isImage;
            try
            {
                Image test = Image.FromFile(fileLoc);
                var ms = new MemoryStream();
                test.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                Image.FromStream(ms, false, false);
                isImage = true;
            }
            catch (Exception)
            {
                isImage = false;
            }
            TimeTo.StopTimer();
            return isImage;
        }

        ~Browse()
        {
            IMV.getConsole().printLine("A Browse Class instance has been ended.");
        }
    }
}
