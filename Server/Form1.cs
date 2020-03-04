using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

            private void HostBtn_Click(object sender, EventArgs e)
        {

            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Any;
            IPEndPoint ipep = new IPEndPoint(ipaddr, 25000);
            listenerSocket.Bind(ipep);
            //int threadCount = 0;
            while (true)
            {
                try
                {
                    // Listen for new connections, up to the amount specified as argument
                    listenerSocket.Listen(5);
                    // Create a thread to deal with the client
                    // Accept the connection
                    Socket client = listenerSocket.Accept();
                    Console.WriteLine("Client connected: " + client.ToString()
                        + " - Ip End Point: " + client.RemoteEndPoint.ToString());
                    // define a buffer as byte array of 128 byte length.
                    byte[] buff = new byte[128];
                    // define number of received bytes as an int
                    int numberOfReceivedBytes = 0;

                    while (true)
                    {
                        numberOfReceivedBytes = client.Receive(buff);
                        Console.WriteLine("Number of received bytes: " +
                        numberOfReceivedBytes);
                        //convert from byte array to ascii, using Encoding.ASCII.GetString
                        string receivedText = Encoding.ASCII.GetString(buff, 0, numberOfReceivedBytes);
                        //print out text
                        Console.WriteLine("Data sent by client is: " + receivedText);
                        //Send data back to sender
                        client.Send(buff);
                        if (receivedText == "x")
                        {
                            listenerSocket.Close();
                            break;
                        }
                        Array.Clear(buff, 0, buff.Length);
                        numberOfReceivedBytes = 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
