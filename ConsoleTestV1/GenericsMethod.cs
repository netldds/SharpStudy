using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    /// <summary>
    /// 泛型方法
    /// </summary>
    class GenericsMethod
    {
        /// <summary>
        /// 匿名委托,Func<参数1，参数2，返回值>(符合委托的方法(匿名方法))
        /// </summary>
        Func<float, float, float> action = new Func<float, float, float>((float a, float b) => a + b);
        Func<string, string> Names = srt => srt.ToUpper();
        public static T GetComponent<T>()
        {
            T resualt = default(T);

            return resualt;
        }
        
        public static T2 Accumulate<T1,T2>(IEnumerable<T1> source,Func<T1,T2,T2> action) 
        {
            T2 sum = default(T2);
            foreach(T1 a in source)
            {
                sum = action(a, sum);
            }
            return sum;
        }
        public static decimal Accumulate<TAccount> (IEnumerable<TAccount> source)
            where TAccount :IAccount
        {
            decimal sum = 0;
            foreach(var a in source)
            {
                sum += a.Balance;
            }
            return sum;
        }
    }
    public interface IAccount
    {
        decimal Balance { get; }
        string Name { get; }
    }
}
