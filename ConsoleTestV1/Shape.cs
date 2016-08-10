using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override string ToString()
        {
            return String.Format("Width:{0},Height:{1}", Width, Height);
        }
    }
    public class Rectangle : Shape
    {

    }
    public interface IIdenx<out T>
    {
        T this[int index] { get; }
        int count { get; }
    }
    public class Enter1
    {
        Rectangle[] rt = new Rectangle[]
        {
            new Rectangle() {Height=2,Width=5 },
            new Rectangle () {Height=1,Width=2 }
        };
        public void DisPlay()
        {
            foreach(var d in rt)
            {
                Console.WriteLine(d.ToString());
            }
        }
        Dictionary<string, string[]> dic = new Dictionary<string, string[]>
        {
            {"A",new string[] {"A1","A2","A3"} },
            {"B",new string[] {"A1","A2","A3"} },
            {"C",new string[] {"A1","A2","A3"} }
        };
    }
}
