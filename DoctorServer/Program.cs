using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorServer
{
    class Program
    {
        static void Main(string[] args)
        {
           
                DatabaseConnections db = new DatabaseConnections();
          
                Server server = new Server();
                server.SocketServer("127.0.0.1", 8145);
            }
        }
    }

