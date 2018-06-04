using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

/*
 Реализовать клиент-серверное приложение, которое позволяет посредством UDP с сервера посылать все компьютерам в групповой
 рассылке по локальной сети разослать команду отключение питания. Команда должна быть выполнена.
     */

namespace ShutDownUdpServer
{
    class Program
    {
        static IPAddress remoteAddress;
        static void Main(string[] args)
        {
            remoteAddress = IPAddress.Parse("235.5.5.11");
            UdpClient sender = new UdpClient(); 
            IPEndPoint endPoint = new IPEndPoint(remoteAddress, 8888);

            string myString = "ShutDown";

            byte[] data = Encoding.Default.GetBytes(myString);

            sender.Send(data, data.Length, endPoint);
        }
    }
}
