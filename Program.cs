using System.Text;
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
            // using (var output = File.Create(path + "output.csv"))
            // {
                var data = File.ReadAllLines("D:/BT C#/GopFile/FILE2/20210719log - Copy1.csv",Encoding.ASCII);
                foreach (var file in data)
                {
                // using (var data=File.ReadAllLines(file))
                // {
                // data.CopyTo(output);
                Console.WriteLine(file);
                    // }
                }
            // }
        }
    }
}
