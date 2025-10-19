using System;
using System.IO;
using System.Text;

namespace BTH1_HuynhGiaThinh_24521680
{
    internal class Bai02
    {
        public static void Run()
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Nhap duong dan thu muc: ");
            string path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Thu muc khong ton tai!");
                return;
            }

            DirectoryInfo dir = new DirectoryInfo(path);

            Console.WriteLine($"\n Directory of {path}\n");

            int fileCount = 0, dirCount = 0;
            long totalSize = 0;

            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                Console.WriteLine($"{subDir.LastWriteTime:dd/MM/yyyy  hh:mm tt}    <DIR>          {subDir.Name}");
                dirCount++;
            }

            foreach (FileInfo file in dir.GetFiles())
            {
                Console.WriteLine($"{file.LastWriteTime:dd/MM/yyyy  hh:mm tt}         {file.Length,15:N0} {file.Name}");
                totalSize += file.Length;
                fileCount++;
            }

            Console.WriteLine($"               {fileCount} File(s)    {totalSize:N0} bytes");
            Console.WriteLine($"               {dirCount} Dir(s)     {GetDriveFreeSpace(path):N0} bytes free");

            Console.ReadKey();
        }

        static long GetDriveFreeSpace(string path)
        {
            DriveInfo drive = new DriveInfo(Path.GetPathRoot(path));
            return drive.AvailableFreeSpace;
        }   
    }
}
