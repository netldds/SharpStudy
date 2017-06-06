using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net.Http;
namespace NetWorkStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            new Client();
        }
        static async Task Runn()
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            string response = await client.GetStringAsync("http://www.baidu.com");
            Console.WriteLine(response);
        }
        void temp()
        {
            //string name = Console.ReadLine();
            TcpClient client = new TcpClient("www.baidu.com", 80);
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());
            try
            {
                sw.WriteLine("GET / HTTP/1.0\n\n");
                sw.Flush();
                string data = sr.ReadLine();
                while (data != null)
                {
                    Console.WriteLine(data);
                    data = sr.ReadLine();
                }
                client.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
