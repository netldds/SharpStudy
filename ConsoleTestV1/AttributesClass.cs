using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    /// <summary>
    /// 自定义特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct |
        AttributeTargets.Class |
        AttributeTargets.Method,
        AllowMultiple = false)]
    public class Author : Attribute
    {
        public string Name;
        public double Version;
        public Author(string name)
        {
            this.Name = name;
            Version = 1.0;
        }
    }
    [AttributeUsage(AttributeTargets.All)]
    public class RefDll:Attribute
    {
        public RefDll()
        {

        }
    }
    //[Author("zhangliu", Version = 1.1f)]
    class FunctionInherited
    {

        public FunctionInherited()
        {
            Console.WriteLine("1");

        }
        [Author("Dos", Version = 1.1f)]
        public void  Dos()
        {
            Console.WriteLine("DO");
        }
    }
}
