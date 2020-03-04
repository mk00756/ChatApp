using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class ClientSocket
    {
        //private static Socket client;
        //private TcpClient clientSocket;
        //private IPAddress ipAddress;
        //private int PortNumber;
        //private static NetworkStream ns;
        private ClientSocket client;
        private TcpClient tc;




        public ClientSocket()
        {
            //client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        }

        public void joinChatroom(string _ipAddress, int _portNumber)
        {
            try
            {
                // connect to the server
                //clientSocket.Connect(_ipAddress, _portNumber);
                tc.Connect("127.0.0.1", 25000);

                Console.WriteLine("User has joined the room");

            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
            }
        }

        public void sendMessage(string userInput)
        {
            NetworkStream ns;

            try
            {
                ns = tc.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(userInput);
                ns.Write(data, 0, data.Length);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void ReceiveData()
        {

        }

    }
}

