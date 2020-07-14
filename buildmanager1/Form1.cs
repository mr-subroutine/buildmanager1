using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buildmanager1
{
    public partial class Form1 : Form
    {
        protected string newBuildLoc;
        protected string archiveBuildLoc;
        
        // browser dialog for build copy
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        FolderBrowserDialog fbd2 = new FolderBrowserDialog();
        FolderBrowserDialog fbd3 = new FolderBrowserDialog();

        // set default path for build source on a server
        // <--------------------HERE-------------------->

        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "Select A Folder Destination For Builds";
            fbd.ShowNewFolderButton = false;

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fbd2.RootFolder = Environment.SpecialFolder.Desktop;
            fbd2.Description = "Select A Folder Destination For Builds";
            fbd2.ShowNewFolderButton = false;

            if (fbd2.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd2.SelectedPath;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fbd3.RootFolder = Environment.SpecialFolder.Desktop;
            fbd3.Description = "Select A Folder Destination For Builds";
            fbd3.ShowNewFolderButton = false;

            if (fbd3.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd3.SelectedPath;
            }
        }
    }
}
