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
            string text = "";
            string ipAddress = IPTxt.Text;
            int port = int.Parse(PortTxt.Text);
            ChatServer server = new ChatServer(port, ipAddress);
            HostBtn.Enabled = false;
            //Thread read = new Thread(() => 
            //{
            //    while (true)
            //    {
            //        if (server.clientList.Count > 0)
            //        {
            //            try
            //            {
            //                server.ns = server.clientList[0].GetStream();
            //                byte[] data = new byte[server.clientList[0].ReceiveBufferSize];
            //                int numBytesRead = server.ns.Read(data, 0, System.Convert.ToInt32(server.clientList[0].ReceiveBufferSize));
            //                text = Encoding.ASCII.GetString(data, 0, numBytesRead);
            //            }
            //            catch { }
            //        }
            //    }
            //});
            //read.Start();

            while (true)
            {
                try
                {
                    server.ns = server.clientList[server.clientList.Count - 1].GetStream();
                    byte[] data = new byte[server.clientList[0].ReceiveBufferSize];
                    int numBytesRead = server.ns.Read(data, 0, System.Convert.ToInt32(server.clientList[0].ReceiveBufferSize));
                    ChatTxt.AppendText(Encoding.ASCII.GetString(data, 0, numBytesRead));
                }
                catch { }
            }
        }
    }
}
