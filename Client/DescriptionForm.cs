using Client.StreamServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class DescriptionForm : Form
    {
        StreamContractClient imageClient;
        public DescriptionForm(string description, string imageName)
        {
            InitializeComponent();

            if (imageName != null)
            {
                imageClient = new StreamContractClient();
                string filePath = Path.Combine(System.Environment.CurrentDirectory, imageName);
                Stream fs;
                long size;
                string fileName = imageName;
                fileName = imageClient.getMStream(fileName, out size, out fs);
                filePath = Path.Combine(System.Environment.CurrentDirectory, fileName);
                SaveFile(fs, filePath, size);
                pictureBox.ImageLocation = filePath;
            }

            textBox.Text = description;
        }

        private void SaveFile(Stream fs, string filePath, long size)
        {
            const int bufferLength = 8192;
            int bytecount = 0;
            int counter = 0;
            byte[] buffer = new byte[bufferLength];

            progressBar1.Maximum = (int) size;

            FileStream outstream = File.Open(filePath, FileMode.Create, FileAccess.Write);

            while ((counter = fs.Read(buffer, 0, bufferLength)) > 0)
            {
                outstream.Write(buffer, 0, counter);
                bytecount += counter;
                progressBar1.Value = bytecount;
            }

            outstream.Close();
            fs.Close();
        }
    }
}
