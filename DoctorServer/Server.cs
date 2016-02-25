using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DoctorServer
{
    class Server
    {
        
        DatabaseConnections db = new DatabaseConnections();
       
        static UnicodeEncoding encoding = new UnicodeEncoding();
        static Socket listeningSocket = null;
        static Socket socket = null;
        const Int32 BUFFERLENGTH = 80;

        public void SocketServer(string ip, int port)
        {
         
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
            try
            {
                listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listeningSocket.Bind(localEndPoint);
                listeningSocket.Listen(1);

                //Found a connection
                socket = listeningSocket.Accept();

                Byte[] buffer = new Byte[BUFFERLENGTH];
                socket.Receive(buffer);
                String message = encoding.GetString(buffer);

                bool test = db.IsUserRegisterad(message);
                string result;


                if(test)
                {
                    result = "1";

                }
                else
                {
                    result = "0";
                }
                //gn.IsUserRegisterad(message, message);//to send db..
                Console.WriteLine("Recived Message:" + message);
                byte[] resp = encoding.GetBytes(result);
                socket.Send(resp);

                Console.ReadLine();

            }
            catch (Exception exception)
            {
                Console.WriteLine("ERROR: " + exception.Message + "\n" + exception.StackTrace);
                Console.ReadLine();
            }
            finally
            {
                if (listeningSocket != null)
                    listeningSocket.Close();
                if (socket != null)
                    socket.Close();
            }
        }
    }
}
