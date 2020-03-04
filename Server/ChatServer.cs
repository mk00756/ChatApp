using System;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class ChatServer
{
    public TcpListener listenerSocket { get; set; }
    public List<TcpClient> clientList { get; set; } = new List<TcpClient>();
    public IPAddress ipAddress { get; set; }
    public int port { get; set; }
    public IPEndPoint ipep { get; set; }
    public NetworkStream ns { get; set; }

    public ChatServer(int port, string ipAddress)
    {
        this.ipAddress = IPAddress.Parse(ipAddress);
        listenerSocket = new TcpListener(this.ipAddress, port);
        listenerSocket.Start();

        Thread connectThread = new Thread(() =>
        {
            clientList.Add(listenerSocket.AcceptTcpClient());
        });
        connectThread.Start();

    }

    public void broadcast(string msg)
    {
        for (int i = clientList.Count; --i > 0;)
        {
            ns = clientList[i].GetStream();
            byte[] data = Encoding.ASCII.GetBytes(msg);
            ns.Write(data, 0, data.Length);
        }
    }
}
