using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MyConsole
{
    public enum FileEnum
    {
        Read = 0,
        Write = 1
    }
    /// <summary>
    /// 缓冲流
    /// </summary>
    class MyBufferedStream
    {
        private const string FILE_NAME = @"D:\data.txt";
        public MyBufferedStream()
        {

        }
        public static void ComplexMH()
        {
            FileInfo ff = new FileInfo(FILE_NAME);
            if (ff.Exists)
            {
                FileStream fs = ff.Open(FileMode.Open, FileAccess.ReadWrite);
                BufferedStream bs = new BufferedStream(fs);
                Console.WriteLine($"流能否读:{bs.CanRead}");  //此流于基础流的设置有关，当fs设FileAccess.Read时就为true，Write时就为false
                Console.WriteLine("文件流可查找:" + fs.CanSeek + " " + bs.CanSeek);  //True True  支持查找
                Console.WriteLine("文件流可超时:" + fs.CanTimeout + " " + bs.CanTimeout);   //False False 既然不支持超时，那就更加不存在超过多久的问题了，因此最后两个属性都会异常。
                Console.WriteLine("流可写:" + bs.CanWrite + fs.CanWrite); //这个也是和基础流的可读属性一致
                Console.WriteLine("文件流长度:" + fs.Length + "流长度: " + bs.Length);    //输出 7649 7649
                Console.WriteLine("文件流长度:" + fs.Length + "流位置:" + bs.Position); //输出7649  0   文件流Open打开就在最后了，但是BufferedStream是在开始。
                                                                                //byte[] by = new byte[bs.Length];
                                                                                //bs.Read(by, 0, (int)bs.Length);
                                                                                //Console.WriteLine(Encoding.Default.GetString(by));
                Console.WriteLine(bs.Position);
                byte[] byw = Encoding.Default.GetBytes("我就试试看了");
                bs.Seek(bs.Length, SeekOrigin.Begin);
                bs.Write(byw, 0, byw.Length);
                bs.Flush();
                bs.Close();
            }
            else
            {
                Console.WriteLine("文件不存在");
            }
        }
        /// <summary>
        /// 用缓冲耗时39679.5752ms
        /// </summary>
        public static void StreamRead()
        {
            FileStream fs = File.Open(FILE_NAME, FileMode.Open, FileAccess.ReadWrite);
            BufferedStream bf = new BufferedStream(fs);
            byte[] bys = new byte[1024];
            while (bf.Read(bys, 0, bys.Length) > 0)
            {
                Console.WriteLine(bf.Position);
                Console.WriteLine(Encoding.Default.GetString(bys));

                for (int i = 0; i < bys.Length; i++)
                {
                    bys[i] = 0;
                }
            }
            bf.Close();
            fs.Close();
        }
    }
    class MyIO
    {
        /// <summary>
        /// 不用缓冲，直接文件读写,耗时1079.1808ms,耗时39806.3587ms 耗时38679.5752ms
        /// </summary>
        private const string FILE_NAME = @"D:\data.txt";
        public static void DOread()
        {
            FileInfo fs = new FileInfo(FILE_NAME);
            Console.WriteLine(fs.Exists.ToString());
            FileStream ft = fs.Open(FileMode.Open, FileAccess.ReadWrite);
            byte[] bs = new byte[1024];
            while (ft.Read(bs, 0, bs.Length)>0)
            {
                Console.WriteLine(Encoding.Default.GetString(bs));
                for (int i=0;i<bs.Length;i++)
                {
                    bs[i] = 0;
                }
            }
            ft.Close();
            
        }

        /// <summary>
        /// 使用Flie.RealLine  File.Writeline
        /// </summary>
        public static void StaticFileMethod(FileEnum fe)
        {
            switch (fe)
            {
                case FileEnum.Read:
                    foreach (var a in File.ReadLines(FILE_NAME, Encoding.Default))
                    {
                        Console.WriteLine(a);
                    }
                    break;
                case FileEnum.Write:
                    //string[] st = new string[20];
                    StringBuilder stt = new StringBuilder();
                    for (int i = 0; i < 20; i++)
                    {
                        stt.Append(i);
                    }
                    File.WriteAllText(FILE_NAME, stt.ToString());
                    break;

            }
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
        /// <summary>
        /// 文件流
        /// </summary>
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
        protected const string DIRECTORY = @"D:\";
        public static void DirectoryDO()
        {
            DirectoryInfo df = new DirectoryInfo(DIRECTORY);
            foreach (var d in df.GetDirectories())
            {
                Console.WriteLine($"现有目录:{d.FullName}");
            }
            foreach (var f in df.GetFiles(@"*.txt"))
            {
                if (f.Exists)
                {
                    Console.WriteLine($"找到文件：{f.Name}");
                }
            }

        }
    }

}
