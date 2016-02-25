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
        public bool CheckOnRegister(string email)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, 8145);
            UnicodeEncoding encoding = new UnicodeEncoding();
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(remoteEndPoint);

            //encode from a string format to bytes ("our packages")
            Byte[] bufferOut = encoding.GetBytes(email);

            socket.Send(bufferOut);

            byte[] bytes = new byte[1024];
            int bytesRecieved = socket.Receive(bytes);

            string mess = encoding.GetString(bytes, 0, bytesRecieved);
            if (mess == "1")
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
            //socket.Connect(remoteEndPoint);

            //Byte[] bufferOut = encoding.GetBytes(email);


            //socket.Send(bufferOut);

            //byte[] bytes = new byte[1024];
            //int bytesRecieved = socket.Receive(bytes);

            //string mess = encoding.GetString(bytes, 0, bytesRecieved);

            //if (mess == "1")
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;

            //}
        
