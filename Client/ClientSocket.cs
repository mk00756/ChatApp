using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class ClientSocket
    {
        private static Socket client;
        private IPAddress ipAddress;
        private int PortNumber;


        public ClientSocket()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        }

        public void Initialize()
        {
            // get ip from text box

            // get port number from text box

            // enter button and join chatroom

        }

        private void joinChatroom()
        {

        }

        private void sendMessage()
        {
            string userInput = string.Empty;

            while (true)
            {
                // send messages

                userInput = Console.ReadLine();
                byte[] buffSend = Encoding.ASCII.GetBytes(userInput);
                client.Send(buffSend);

                // append textbox
            }
        }

        private void recieveMessage()
        {
            while (true)
            {
                // recieve messages
                byte[] buffReceive = new byte[1024];
                int nRecv = client.Receive(buffReceive);

                // append textbox
                //Encoding.ASCII.GetString(buffReceive, 0, nRecv);
            }
        }

    }
}

