using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWPF
{
    class Client
    {
        public void SendMessage(string Message, string ip, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, port);
            UnicodeEncoding encoding = new UnicodeEncoding();
            Socket socket = null;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(remoteEndPoint);

                //encode from a string format to bytes ("our packages")
                Byte[] bufferOut = encoding.GetBytes(Message);

                socket.Send(bufferOut);

                byte[] bytes = new byte[1024];
                int bytesRecieved = socket.Receive(bytes);

                string mess = encoding.GetString(bytes, 0, bytesRecieved);
                Console.WriteLine(mess);
                Console.ReadLine();
                socket.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool CheckLogin(string email)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.1");
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, 8145);
            UnicodeEncoding encoding = new UnicodeEncoding();
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(remoteEndPoint);

            byte[] bytes = new byte[1024];
            int bytesRecieved = socket.Receive(bytes);

            string mess = encoding.GetString(bytes, 0, bytesRecieved);
            if(mess == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
