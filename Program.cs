using BTH1_HuynhGiaThinh_24521680;
using BTH2_HuynhGiaThinh_24521680;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Chon bai 1-5: ");
        int n = int.Parse(Console.ReadLine());
        switch (n)
        {
            case 1: Bai01.Run(); break;
            case 2: Bai02.Run(); break;
            case 3: Bai03.Run(); break;
            case 4: Bai04.Run(); break;
            case 5: Bai05.Run(); break;
        }
    }
}
