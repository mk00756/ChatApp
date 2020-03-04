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
            string ipAddress = IPTxt.Text;
            int port = int.Parse(PortTxt.Text);
            ChatServer server = new ChatServer(port, ipAddress);
            HostBtn.Enabled = false;
        }
    }
}
