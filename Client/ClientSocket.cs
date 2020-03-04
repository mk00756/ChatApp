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
        private static Socket client;
        private TcpClient clientSocket;
        private IPAddress ipAddress;
        private int PortNumber;


        public ClientSocket()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        }

        public void joinChatroom(string _ipAddress, int _portNumber)
        {
            try
            {
                // connect to the server
                client.Connect(_ipAddress, _portNumber);

                Console.WriteLine("User has joined the room");

            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
            }
        }

        public void sendMessage(string userInput)
        {
            try
            {
                while (true)
                {
                    // send messages
                    
                    byte[] buffSend = Encoding.ASCII.GetBytes(userInput);
                    client.Send(buffSend);

                    // append textbox
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
            }
        }

        private void recieveMessage()
        {
            try
            {
                while (true)
                {
                    // recieve messages
                    byte[] buffReceive = new byte[1024];
                    int nRecv = client.Receive(buffReceive);

                    string textRecieved = Encoding.ASCII.GetString(buffReceive, 0, nRecv);

                }
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
            }
        }

    }
}

