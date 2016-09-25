using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using Microsoft.Win32;

namespace MyConsole
{
    class Enter
    {
        private static int count = 0;
        static void Main(string[] args)
        {
            Console.WriteLine(FXVersionInRegistry.GetFXVersion());
            Console.ReadKey();
        }
    }
}
