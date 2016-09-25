using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MyConsole
{
    class FileIO
    {
        private const string FILE_NAME = @"D:\date.txt";
        public static void DOread()
        {
            FileInfo fs = new FileInfo(FILE_NAME);
            Console.WriteLine(fs.Exists.ToString());
            FileStream ft = fs.OpenRead();
            byte[] bs = new byte[ft.Length];
            ft.Read(bs, 0, (Int32)ft.Length);
            Console.WriteLine(Encoding.UTF8.GetString(bs));
        }
        public static void DOStream()
        {
            using (StreamReader st = File.OpenText(FILE_NAME))
            {
                string sr;
                while ((sr = st.ReadLine()) != null)
                {
                    Console.WriteLine(sr);
                }
            }
        }
        public static void FIleMSDN()
        {
            // Create the new, empty data file.
            if (File.Exists(FILE_NAME))
            {
                Console.WriteLine("{0} already exists!", FILE_NAME);
                return;
            }
            FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew);
            // Create the writer for data.
            BinaryWriter w = new BinaryWriter(fs);
            // Write data to Test.data.
            for (int i = 0; i < 11; i++)
            {
                w.Write((int)i);
            }
            w.Close();
            fs.Close();
            // Create the reader for data.
            fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            // Read data from Test.data.
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(r.ReadInt32());
            }
            r.Close();
            fs.Close();
        }
    }

}
