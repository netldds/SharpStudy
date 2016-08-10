using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    class Extended
    {
        public Extended()
        {
            Console.WriteLine("Construct..");
        }

    }
    /// <summary>
    /// 扩展类必须为静态（不能实例化，没有构造器，扩展方法也符合静态）
    /// </summary>
    static class ExtendClass
    {
        public static void Enter_Ext(this Extended e)
        {
            Console.WriteLine("Exten Func");
        }
    }
}
