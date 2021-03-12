using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ServoDriverPanel
{
    public partial class Form1 : Form
    {
        int i;
        long j;
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();  //Seri portları diziye ekleme
            foreach (string port in ports)
                comboBox1.Items.Add(port); //Seri portları comBox1' ekleme

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();  //Eğer port açıksa kapat
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString(); //comboBox1'de seçili olan portu port ismine ata
            serialPort1.Open(); //Seri portu aç
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;
            serialPort1.Write("*");
            for (j = 0; j < 400000000; j++)
            {

            }
            for (i = 0; i < message.Length; i++)
            {
                serialPort1.Write(Convert.ToString(message[i]));
                for (j=0; j < 400000000; j++)
                {

                }
            }
            label2.Text = "Message Sent";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = serialPort1.ReadLine();
        }
    }
}
