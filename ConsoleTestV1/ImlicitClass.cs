using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    struct Currency
    {
        public uint Dollars;
        public ushort Cents;
        public Currency(uint dollars,ushort cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;

        }
        public override string ToString()
        {
            return string.Format("${0}.{1,-2:00}", Dollars, Cents);
        }
        /// <summary>
        /// 隐式类型转换(访问级，静态，隐式，操作符，返回类型（转换目标）)
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator float (Currency value)
        {
            return value.Dollars + (value.Cents / 100.0f);
        }
    }
}
