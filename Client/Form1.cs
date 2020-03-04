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
            try
            {
                string _ipAddress = textIP.Text;
                string _portNumber =textPort.Text;
                client.joinChatroom(_ipAddress, int.Parse(_portNumber));

                //chatTextbox.AppendText("You have joined the chat room \n\n");
            }
            catch (Exception excp)
            {
                chatTextbox.AppendText("Cannot connect to the server \n\n");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            testingMethod();

            //client.sendMessage(textMessage.Text);
            //textMessage.Text = "";
        }

        private void testingMethod()
        {
            TcpClient tc = new TcpClient();
            tc.Connect("127.0.0.1", 25000);

            NetworkStream ns = tc.GetStream();
            byte[] data = Encoding.ASCII.GetBytes("Hello");

            ns.Write(data, 0, data.Length);
        }

        public void appendText(string appendText)
        {
            chatTextbox.AppendText(appendText +"\n");
        }

    }
}
