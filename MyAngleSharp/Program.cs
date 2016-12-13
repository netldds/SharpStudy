using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using AngleSharp.Parser.Html;
using AngleSharp.Dom.Html;
using System.Threading;
namespace MyAngleSharp
{
    class Program
    {
        static HtmlParser parser = new HtmlParser();
        static  void Main(string[] args)
        {
            Get(parser, GetHtml());
            Console.WriteLine("我是主线程.");
            Thread.Sleep(3000);
        }
        static async void  Get(HtmlParser parser,string source)
        {
            //Task<IHtmlDocument> a;
            //await( a = parser.ParseAsync(source));
            //Console.WriteLine("subThread");
            await Task.Delay(1000);
            Task<IHtmlDocument> tsk = parser.ParseAsync(source);
            IHtmlDocument res = await tsk;

            Console.WriteLine(res.Title);
        }
        static async void see()
        {
            var document = await parser.ParseAsync(GetHtml());
            Console.WriteLine(document.Title);
        }
        static string GetHtml()
        {
            HttpWebRequest  MyReq= (HttpWebRequest)WebRequest.Create("http://www.cnblogs.com");
            HttpWebResponse response = (HttpWebResponse)MyReq.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream,Encoding.UTF8);
            return readStream.ReadToEnd();
        }
    }
}
