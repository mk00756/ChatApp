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
        bool connected = false;
        ClientSocket client = new ClientSocket();
        TcpClient tc = new TcpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                tc.Connect(textIP.Text, int.Parse(textPort.Text));
                chatTextbox.AppendText("You have joined the chat" + Environment.NewLine);
                btnConnect.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No connection found");
            }
            //    try
            //    {
            //        string _ipAddress = textIP.Text;
            //        string _portNumber = textPort.Text;
            //        client.joinChatroom(_ipAddress, int.Parse(_portNumber));

            //        //string _ipAddress = textIP.Text;
            //        //string _portNumber =textPort.Text;
            //        //client.joinChatroom(_ipAddress, int.Parse(_portNumber));

            //        //chatTextbox.AppendText("You have joined the chat room \n\n");
            //    }
            //    catch (Exception excp)
            //    {
            //        chatTextbox.AppendText("Cannot connect to the server \n\n");
            //    }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userinput = textMessage.Text.ToString();
            sendMessage(userinput);

            //client.sendMessage(textMessage.Text);
            //textMessage.Text = "";
            textMessage.Text = "";
        }

        public void sendMessage(string userInput)
        {
            NetworkStream ns;

            try
            {
                ns = tc.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(userInput);
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        //public void ReceiveMessage(IAsyncResult ar)
        //{
        //    try
        //    {
        //        int bytesRead;

        //        object[] para =
        //        {
        //            System.Text.Encoding.ASCII.GetString(data,0,bytesRead) };
        //        this.Invoke(new delUp)
        //    }
        //}

        public void appendText(string appendText)
        {
            chatTextbox.AppendText(appendText +"\n");
        }

    }
}
