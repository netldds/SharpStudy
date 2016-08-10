using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    /// <summary>
    /// 数组实现IComparable接口，被Array.Sort()调用来比较
    /// </summary>
    class Person_Array : IComparable<Person_Array>, IEnumerable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        int[] ints = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        ArraySegment<int> segment;
        public Person_Array()
        {
            segment = new ArraySegment<int>(ints, 2, 4);
        }
        public int CompareTo(Person_Array obj)
        {
            if (obj == null) return 1;
            int result = string.Compare(this.LastName, obj.LastName);
            if (result == 0)
            {
                result = string.Compare(this.FirstName, obj.FirstName);
            }
            return result;
        }
        public override string ToString()
        {
            return String.Format("FirstName:{0}     LastName:{1}", FirstName, LastName);
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = segment.Offset; i < segment.Offset + segment.Count; i++)
            {
                yield return segment.Array[i];
            }
        }
        public IEnumerator Start()
        {
            for (int i = segment.Offset; i < segment.Offset + segment.Count; i++)
            {
                yield return segment.Array[i];
            }
        }
        private void refense()
        {
            Person_Array[] person =
                {
                new Person_Array { FirstName="Ajon",LastName="Dam"},
                new Person_Array { FirstName="BJon",LastName="Cam"},
                new Person_Array { FirstName="Cjon",LastName="Bam"},
                new Person_Array { FirstName="Djon",LastName="Aam"}
            };
            Array.Sort(person);
            foreach (var a in person)
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
    /// <summary>
    /// 模拟Foreach
    /// </summary>
    public class foreach2
    {
        public static void Action<T>(IEnumerator<T> enumer)
        {
            while (enumer.MoveNext())
            {
                Console.WriteLine(enumer.Current);
            }
        }
    }
}
