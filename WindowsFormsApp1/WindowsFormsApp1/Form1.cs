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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //label1.Text = (trackBar1.Value * 32 ).ToString();
            foreach(var portname in SerialPort.GetPortNames())
            {
                var port = new SerialPort(portname)
                {
                    BaudRate = 9600,
                    ReadTimeout = 50,
                    WriteTimeout = 50,
                };
                try
                {
                    port.Open();
                    port.Write(trackBar1.Value.ToString());
                    //byte[] buf = new byte[64];
                    //int i = port.Read(buf, 0, buf.Length);
                    //label1.Text = BitConverter.ToString(buf.Take(1).ToArray());
                }
                catch
                {

                }
                finally
                {
                    port.Close();
                    label1.Text = trackBar1.Value.ToString();
                }
            }
        }
    }
}
