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
using System.Net.Http;
namespace MyConsole
{
    class Enter
    {
        static void Main(string[] args)
        {
            Console.WriteLine("当前FX版本:" + FXVersionInRegistry.GetFXVersion());
            DateTime bd = DateTime.Now;

            FunctionInherited fc = new FunctionInherited();

            MethodInfo minfo = FindMethodWithAttribute(typeof(Author), fc.GetType());
            if(minfo!=null)
            {
                Console.WriteLine("Author");
                minfo.Invoke(fc, null);
            }


            DateTime ed = DateTime.Now;
            Console.WriteLine($"耗时{ed.Subtract(bd).TotalMilliseconds}ms");
            //Console.WriteLine("Done");
            Console.ReadKey();
        }
        /// <summary>
        /// 查找未知实例方法有无指定特性
        /// </summary>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        static MethodInfo FindMethodWithAttribute(Type t,Type obj)
        {
            var _obj = obj.GetMethods(BindingFlags.Instance|BindingFlags.Public);
            foreach(var m in _obj)
            {
                if(m.GetCustomAttribute(t)!=null)
                {
                    //m.Invoke(obj, null);
                    return m;
                }
            }
            return null;
        }
        static async void dost()
        {
            AsyncClass ac = new AsyncClass();
            Task<int> stt = ac.AccessTheWebAsync();
            int st = await stt;
            await stt.ContinueWith(x =>
            {
                Console.WriteLine(x.IsCompleted.ToString());
            });
            Console.Write(st);
        }
        public void GetDllFile()
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo dinfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            FileInfo[] dllfile = dinfo.GetFiles("*.dll");
            //Console.WriteLine(dllfile[0].FullName);

            Assembly assembly = Assembly.LoadFile(dllfile[0].FullName);
            Type[] dlltypes = assembly.GetTypes();
            AssemblyName aname = assembly.GetName();
            Console.WriteLine(aname.Name);
            Console.WriteLine(dlltypes[0].Name);
            foreach (MethodInfo m in dlltypes[0].GetMethods())
            {
                var a = m.GetCustomAttribute(typeof(RefDll));
                if (a != null)
                {
                    Console.WriteLine("找到方法" + m.Name);
                    assembly.CreateInstance(dlltypes[0].Name);
                }
            }
        }
    }
}
