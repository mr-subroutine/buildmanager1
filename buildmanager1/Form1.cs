using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace buildmanager1
{
    public partial class Form1 : Form
    {
        static protected string fileName = "";
        static protected string sourceLoc;
        static protected string destiLoc;
        protected string archiveBuildLoc;

        protected string sourceFile;
        protected string destFile;

        // browser dialog for build copy
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        FolderBrowserDialog fbd2 = new FolderBrowserDialog();
        FolderBrowserDialog fbd3 = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent();
        }

        // set source
        private void button5_Click(object sender, EventArgs e)
        {
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "Select A Source Folder For Builds";
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
                sourceLoc = fbd.SelectedPath;
                sourceFile = System.IO.Path.Combine(sourceLoc, fileName);
            }
        }

        // set archive
        private void button8_Click(object sender, EventArgs e)
        {
            fbd2.RootFolder = Environment.SpecialFolder.Desktop;
            fbd2.Description = "Select An Archive Folder For Builds";
            fbd2.ShowNewFolderButton = false;

            if (fbd2.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd2.SelectedPath;
                archiveBuildLoc = fbd2.SelectedPath;
            }
        }

        // set destination
        private void button10_Click(object sender, EventArgs e)
        {
            fbd3.RootFolder = Environment.SpecialFolder.Desktop;
            fbd3.Description = "Select A Destination Folder For Builds";
            fbd3.ShowNewFolderButton = false;

            if (fbd3.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = fbd3.SelectedPath;
                destiLoc = fbd3.SelectedPath;
                destFile = System.IO.Path.Combine(destiLoc, fileName);
            }
        }

        // copy new data to destination
        private void btn_getbuild_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            label5.Visible = true;

            // get all the file names
            string[] allFiles = System.IO.Directory.GetFiles(sourceLoc);

            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = allFiles.Length;
            progressBar1.Value = 1;
            progressBar1.Step = 1;

            if (System.IO.Directory.Exists(sourceLoc))
            {
                string[] files = System.IO.Directory.GetFiles(sourceLoc);
                
                // WIP delete any files in destination dir FIRST!
                

                // begin copy
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(destiLoc, fileName);

                    // new thread to prevent blocking UI thread
                    new Thread(() =>
                    {
                        System.IO.File.Copy(s, destFile, true);
                    }).Start();

                    progressBar1.Refresh();
                    progressBar1.PerformStep();
                }

                // turn off label and progress bar
                progressBar1.Visible = true;
                label5.Visible = true;
            }

            else
            {
                MessageBox.Show("Source location not set.");
            }
        }
    }
}