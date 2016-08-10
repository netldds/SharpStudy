using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenTK;
using System.Reflection;
namespace MyConsole
{
    class Enter
    {
        static void Main(string[] args)
        {
            Person_Array pa = new Person_Array();
            Type t = typeof(Parallel);
            MemberInfo[] minfo = t.GetMembers();
            foreach(var a in minfo)
            {
                Console.WriteLine(a);
            }
        }

    }


}
