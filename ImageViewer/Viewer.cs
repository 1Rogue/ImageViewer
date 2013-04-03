using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageViewer
{
    public partial class Viewer : Form
    {
        private Browse instance = new Browse(IMV.getOpeningFile());

        public Viewer()
        {
            InitializeComponent();
            setImage(instance.getCurrentFile());
        }

        public void setImage(string location)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(location);
            }
            catch (Exception e)
            {
                Console.WriteLine("Bad things happened.");
                Console.WriteLine(e.StackTrace);
            }
            IMV.getConsole().printLine("{\nPrevious: " + instance.getPrevImage());
            IMV.getConsole().printLine("Current: " + instance.getCurrentImage());
            IMV.getConsole().printLine(string.Concat("Next: ", instance.getNextImage(), "\n}"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setImage(instance.nextImage());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setImage(instance.prevImage());
        }

        private void Viewer_KeyDown(object sender, KeyEventArgs e)
        {
            IMV.getConsole().printLine("Event accessed");
            IMV.getConsole().printLine("KeyCode=" + e.KeyCode +", KeyValue=" + e.KeyValue + ", KeyData=" + e.KeyData);
            if (e.KeyCode == Keys.Right)
            {
                TimeTo.StartTimer();
                setImage(instance.nextImage());
                TimeTo.StopTimer();
                IMV.getConsole().printLine("Time to change image: " + TimeTo.getTime());
            }
            else if (e.KeyCode == Keys.Left)
            {
                setImage(instance.prevImage());
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Viewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            IMV.getConsole().printLine("KeyPress Event accessed");
        }
    }
}
