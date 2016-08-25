using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
namespace MyConsole
{
    class Enter
    {
        static void Main(string[] args)
        {
            ParallelLoopResult result = Parallel.For(0, 10,(i,pls)=>
            {
                Console.WriteLine("{0},task:{1}Thread{1}", i,
                    Task.CurrentId,
                    Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
                if(i>5)
                {
                    pls.Break();
                }
            });
            Console.WriteLine("Is Completed:{0}", result.IsCompleted);
            Console.WriteLine(result.LowestBreakIteration);
        }

    }


}
