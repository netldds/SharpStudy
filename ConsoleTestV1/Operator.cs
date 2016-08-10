using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    /*
     *      var a = new Vector2(3f, 4f);
            var b = new Vector2(2f, 3f);
            Console.WriteLine((a + b).ToString());
            Console.WriteLine(a * b);
            Console.WriteLine(Vector2.Normalized(a).ToString());
     */
    /// <summary>
    ///重载运算符
    ///标准化二维坐标Normalized
    /// </summary>
    class Vector2
    {
        public double x;
        public double y;
        public override string ToString()
        {
            return string.Format("x={0},y={1}", x, y);
        }
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            Vector2 result = new MyConsole.Vector2(v1.x + v2.x, v1.y + v2.y);
            return result;
        }
        public static double operator *(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }
        /// <summary>
        /// 反余弦函数（返回角度）
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double AcosD(Vector2 v1,Vector2 v2)
        {
            var v3 = v1.Normailized() * v2.Normailized();
            return Math.Acos(v3) / Math.PI * 180;
        }
        public static Vector2 operator *(Vector2 v1, double f)
        {
            return new MyConsole.Vector2(v1.x * f, v1.y * f);
        }
        public static Vector2 operator *(double f, Vector2 v1)
        {
            return v1 * f;
        }
        /// <summary>
        /// 归一化
        /// </summary>
        /// <param name="v1">需要的Vector2实例</param>
        /// <returns></returns>
        public static Vector2 Normalized(Vector2 v1)
        {
            double distance = Math.Sqrt(Math.Pow(v1.x, 2f) + Math.Pow(v1.y, 2f));
            return new Vector2(Math.Round(v1.x / distance, 2), Math.Round(v1.y / distance, 2));
        }
        public Vector2 Normailized()
        {
            double distance = Math.Sqrt(this.x * this.x + this.y * this.y);
            return new Vector2(this.x / distance, this.y / distance);
        }
        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
