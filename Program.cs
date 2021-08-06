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
        }
    }
}
