using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        ClientSocket client = new ClientSocket();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string _ipAddress = textIP.Text;
            int _portNumber = Int32.Parse(textPort.Text);
            client.joinChatroom(_ipAddress,_portNumber);
            textMessage.Text = "Button is clicked";
            Console.WriteLine("Button is clicked");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.sendMessage(textMessage.Text);
            textMessage.Text = "";
        }
    }
}
