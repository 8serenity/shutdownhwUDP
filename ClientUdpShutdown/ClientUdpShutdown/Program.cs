using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientUdpShutdown
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient(8888);


            client.JoinMulticastGroup(IPAddress.Parse("235.5.5.11"), 50);

            IPEndPoint remoteIp = null;

            while (true)
            {
                byte[] data = client.Receive(ref remoteIp);

                string message = Encoding.Default.GetString(data);

                if (message == "ShutDown")
                    Process.Start("shutdown", "/s /t 0");
            }

        }
    }
}
