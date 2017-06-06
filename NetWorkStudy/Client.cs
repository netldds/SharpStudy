using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace NetWorkStudy
{
   public class Client
    {
       public Client()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipe = new IPEndPoint(ip, 8080);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock.Connect(ipe);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            string words = "Hello World Again...via C#";
            byte[] bytesSendStr = new byte[words.Length];
            bytesSendStr = Encoding.ASCII.GetBytes(words);
            sock.Send(bytesSendStr);
            sock.Close();
        }
    }
}
