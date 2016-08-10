using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    class DelegateClass
    {
        delegate void DC(string s);
        public void test1(string st)
        {
            Console.WriteLine("test1");
        }
        public void  test2(string st)
        {
            Console.WriteLine("test2");
        }
    }
}
