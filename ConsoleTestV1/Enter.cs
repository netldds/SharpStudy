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
            Console.WriteLine("当前FX版本:"+FXVersionInRegistry.GetFXVersion());
            //FileIO.FIleMSDN();
            Console.WriteLine(Path.Combine(@"D:\abc", "data.chunk"));
            Console.ReadKey();
        }
    }
}
