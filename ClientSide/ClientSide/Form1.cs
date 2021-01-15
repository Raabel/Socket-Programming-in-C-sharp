using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class Form1 : Form
    {
        // Getting Server
        TcpClient client = null;
        public Form1()
        {
            InitializeComponent();

            // Get message from server
            client = new TcpClient("127.0.0.1",8888);
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);

            txtServerMessage.Text = "Sever >> " + sr.ReadLine();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtServerMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        // Send message to the Server
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(txtMessage.Text != "")
            {
                NetworkStream ns = client.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine(txtMessage.Text);

                sw.Flush();
                sw.Close();
                ns.Close();
            
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
