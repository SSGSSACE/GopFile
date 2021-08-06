using System;
using System.IO;
namespace GopFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = @"D:/BT C#/GopFile/FILE2/";
            string[] files = Directory.GetFiles(path, "*.csv", SearchOption.TopDirectoryOnly);
            using (var output = File.Create(path + "output.csv"))
            {
                foreach (var file in files)
                {
                    using (var data=File.OpenRead(file))
                    {
                        data.CopyTo(output);
                    }
                }
            }
        }
    }
}
