using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace MyConsole
{
    class AsyncClass
    {
        /// <summary>
        /// 这是一个异步方法，调用此方法的方法必须也要加Async Await
        /// </summary>
        /// <returns></returns>
        public async Task<int> AccessTheWebAsync()
        {
            Func<Task<int>> taskFunc = () =>
            {
                return Task.Run<int>(() =>
                {
                    Console.WriteLine("我自己的异步方法");
                    return 0;
                });
            };
            int i = await taskFunc();
            await Task.Delay(5000);
            return i;

        }
        /// <summary>
        /// 异步调用方法,Async,Await
        /// </summary>
        public async static void callerWithAsync<T>(T param, Func<T, T> ac)
        {
            //匿名委托写法省去为Task<>专门写方法
            Func<T, Task<T>> taskFunc = x =>
             {
                 return Task.Run<T>(() =>
                 {
                     return ac(x);
                 });
             };
            Task<T> t1;
            //T st = await taskFunc(param);
            await ( t1= taskFunc(param));
            //await t1.ContinueWith(t =>
            //{
            //    T str = t.Result;
            //    Console.WriteLine(str.ToString());
            //});
        }
        /// <summary>
        /// 不用匿名委托为异步实现Task,其实没吊用就一个Run
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static Task<string> AsyncCalculate(string s)
        {
            return Task.Run<string>(() =>
            {
                return "Fuck you bitch!!!";
            });
        }
        /// <summary>
        /// 具体实现方法
        /// </summary>
        /// <param name="FloderName"></param>
        /// <returns></returns>
        private static string CalculateFloderSize(string FloderName)
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Count Time is:{0}", i);
            }
            return string.Format("Claculate...:{0}", FloderName);
        }
        /// <summary>
        /// 尝试
        /// </summary>
        /// <param name="st"></param>
        public static int Calculate(int st)
        {
            for (int i = 1; i <= st; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Count Time is:{0}", i);
            }
            return st;
        }
    }
}
//static void Main(string[] args)
//{
//    AsyncClass.callerWithAsync("zhangliu", AsyncClass.Claculate);
//    Console.WriteLine("异步：正在输出...");
//    Console.WriteLine(Console.ReadLine());
//    Thread.Sleep(8000);

//}