using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyConsole;
namespace ClassLibrary1
{
    public class Class1
    {
        public Class1()
        {
            Console.WriteLine("Class1 Run");
        }
        [RefDll]
        public void CFoo()
        {
            Console.WriteLine("C Foo");
        }
    }

    public class MyStaticFuc
    {
        [RefDll]
        public static void Foo()
        {
            Console.Write("Dll Foo");
        }
    }
}
