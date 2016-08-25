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
        AttributeTargets.Class,
        AllowMultiple =false)]
    class Author : Attribute
    {
        public string Name;
        public double Version;
        public Author(string name)
        {
            this.Name = name;
            Version = 1.0;
        }
    }
    [Author("zhangliu",Version =1.1f)]
    class FunctionInherited
    {
        public FunctionInherited()
        {
            Console.WriteLine("1");
            
        }
    }
}
