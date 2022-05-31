using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPServerWhileLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP Server/Reciever");

            using (UdpClient socket = new UdpClient())
            {
                socket.Client.Bind(new IPEndPoint(IPAddress.Any, 5005));

                IPEndPoint endPoint = null;

                while (true)
                {
                    //indholde data
                    byte[] data = socket.Receive(ref endPoint);

                    //convert byte[] til string mennesklæseliget
                    string message = Encoding.UTF8.GetString(data);

                    // sender data, sender længden på dataen
                    socket.Send(data, data.Length, endPoint);

                    Console.WriteLine("Client sent message: " + message);

                }

            }
        }
    }
}
