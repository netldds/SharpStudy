using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    /// <summary>
    /// 算法练习：
    /// 排序算法：直接插入，快速排序
    /// </summary>
    class Algorithm
    {
        /// <summary>
        /// 算法类型
        /// </summary>
        public enum Agtypes
        {
            //插入排序
            InsertSort,
            //快速排序
            QuickSort
        }
        private Random rd = new Random();

        const int ArrayLength = 10;
        const int Range = 100;
        int[] ary = new int[ArrayLength];

        public Algorithm(Agtypes agtype)
        {
            Init_random_array();

            switch (agtype)
            {
                case Algorithm.Agtypes.InsertSort:
                    InsertSortFunc();
                    break;
                case Agtypes.QuickSort:
                    QicukSortFunc();
                    break;
                default:
                    Console.WriteLine("Choose one type of Algorithm.");
                    break;
            }
        }

        private void QicukSortFunc()
        {
            int[] aryT = new int[ary.Length];
            for (int x = 0; x < aryT.Length; x++)
            {
                aryT[x] = ary[x];
            }
            QuickSortSort(aryT, 0, aryT.Length-1);
            PrintfArray(aryT,"快速排序演算");
        }

        private void QuickSortSort(int[] aryT, int v1, int v2)
        {
            if(v1<v2)
            {
                int i = QuickAlgorithm(aryT, v1, v2);
                QuickSortSort(aryT, v1, i - 1);
                QuickSortSort(aryT, i + 1, v2);
            }
        }

        private int QuickAlgorithm(int[] aryT, int v, int length)
        {
            int i = v, j = length, x = aryT[i];
            while(i<j)
            {
                while (i < j && aryT[j] >= x)
                    j--;
                if(i<j)
                {
                    aryT[i] = aryT[j];
                    i++;
                }
                while (i < j && aryT[i] < x)
                    i++;
                if(i<j)
                {
                    aryT[j] = aryT[i];
                    j--;
                }
            }
            aryT[i] = x;
            return i;
        }

        private void InsertSortFunc()
        {
            int[] aryT = new int[ary.Length];
            for (int x = 0; x < aryT.Length; x++)
            {
                aryT[x] = ary[x];
            }
            for (int i = 1; i < aryT.Length; i++)
            {
                int t = aryT[i];
                int j = i - 1;
                for (; j >= 0; j--)
                {
                    if (t >= aryT[j])
                        break;
                    aryT[j + 1] = aryT[j];

                }
                aryT[j + 1] = t;
            }
            PrintfArray(aryT,"插入排序演算");
        }
        private void PrintfArray(int[] resultary,string str)
        {
            Console.WriteLine(str);
            Console.Write("原始数列: ");
            foreach (var i in ary)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.Write("排序后数字序列： ");
            foreach (var i in resultary)
            {
                Console.Write(i + " ");
            }
        }

        protected void Init_random_array()
        {
            for (int i = 0; i < ary.Length; i++)
            {
                ary[i] = rd.Next(Range);
            }
        }

    }
}
