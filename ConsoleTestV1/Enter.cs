using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using Microsoft.Win32;
using System.IO;
namespace MyConsole
{
    class Enter
    {
        static void Main(string[] args)
        {
            Console.WriteLine("当前FX版本:" + FXVersionInRegistry.GetFXVersion());
            //FileIO.FIleMSDN();
            //FileIO.DirectoryDO();
            //MyIO.StaticFileMethod(FileEnum.Read);
            DateTime bd = DateTime.Now;
            MyBufferedStream.StreamRead();
            //MyIO.DOread();
            DateTime ed = DateTime.Now;
            Console.WriteLine($"耗时{ed.Subtract(bd).TotalMilliseconds}ms");
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
