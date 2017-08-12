using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace QRBarcode
{
    public partial class Form1 : Form
    {
        Bitmap qrCodeImg;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                qrCodeImg = qrCode.GetGraphic(20);
                pictureBox1.Image = qrCodeImg;
                button2.Enabled = true;
            }
            else
                MessageBox.Show("Enter text!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            qrCodeImg.Save(saveFileDialog1.FileName);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            Opacity = 0.5;
        }
    }
}
