
using System.Text;
using System;
using System.IO;
using System.Text.Encodings.Pages;
namespace GopFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("���t");
            string path = @"D:/BT C#/GopFile/FILE2/";
            string[] files = Directory.GetFiles(path, "*.csv", SearchOption.TopDirectoryOnly);
            // using (var output = File.Create(path + "output.csv"))
            // {
                var data = File.ReadAllLines("D:/BT C#/GopFile/FILE2/20210719log - Copy1.csv");
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
