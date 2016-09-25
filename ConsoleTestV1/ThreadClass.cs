using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MyConsole
{
    class ThreadClass
    {
        public static void DoParallelThread()
        {
            ParallelLoopResult result = Parallel.For(0, 10, async (i, pls) =>
            {
                Console.WriteLine("{0},task:{1}Thread{1}", i,
                     Task.CurrentId,
                     Thread.CurrentThread.ManagedThreadId);
                //Thread.Sleep(1000);
                await Task.Delay(10);
                if (i > 5)
                {
                    Console.WriteLine("Break Thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
                    pls.Break();
                }
            });
            Console.WriteLine("Is Completed:{0}", result.IsCompleted);
            Console.WriteLine(result.LowestBreakIteration);
        }
        /// <summary>
        /// LOCK锁，用于对多线程访问同一资源和方法时的顺序。
        /// 线程1调用TASKMETHOD时，锁定taskMethod对象，其他线程就不能调用该方法
        /// 能用于文件读写等同一时间只能由一个线程访问的场景。
        /// </summary>
        static object taskMethodLock = new object();
        static void TaskMethod(object title)
        {
            lock (taskMethodLock)
            {
                Console.WriteLine(title);
                Console.WriteLine("Task id:{0},thread{1}", Task.CurrentId == null ? "no task" : Task.CurrentId.ToString(), Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
            }
        }
        static void TaskMethod2(object title)
        {
            Console.WriteLine(title);
            //Thread.Sleep(1000);
            Console.WriteLine("Task id:{0},thread:{1}", Task.CurrentId == null ? "no task" : Task.CurrentId.ToString(), Thread.CurrentThread.ManagedThreadId);
        }
    }
}
