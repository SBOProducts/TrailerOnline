using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorageTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("loading a file from disk");
            string diskSourcePath = @"C:\Temp\sunset.jpg";
            byte[] original = File.ReadAllBytes(diskSourcePath);

            Console.WriteLine("Upload using BLL");
            ImageBLL.UploadImage("Sunset", original);

            Console.WriteLine("Download to a new location");
            ImageBLL.DownloadImage("Sunset", @"C:\Temp\SunsetRestored.jpg");

            Console.WriteLine("Done");
            Console.ReadLine();

        }
    }
}
