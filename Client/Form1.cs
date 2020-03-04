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
        TcpClient tcpClient = new TcpClient();
        NetworkStream networkStream;


        public Form1()
        {
            InitializeComponent();

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient.Connect(textIP.Text, int.Parse(textPort.Text));
                chatTextbox.AppendText("You have joined the chat" + Environment.NewLine);
                btnConnect.Enabled = false;

                Thread thread = new Thread(receiveMessage);
                thread.Start();

            }
            catch (Exception ex)
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
            try
            {
                networkStream = tcpClient.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(userInput);
                networkStream.Write(data, 0, data.Length);
                networkStream.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private void receiveMessage()
        {
            while (true)
            {
                try
                {
                    networkStream = tcpClient.GetStream();
                    int buffSize = 0;
                    byte[] inStream = new byte[1024];
                    buffSize = tcpClient.ReceiveBufferSize;
                    networkStream.Read(inStream, 0, buffSize);
                    string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    chatTextbox.AppendText(returndata);

                }
                catch (Exception ex)
                {

                }
            }

        }
    }
}
