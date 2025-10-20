using System;

namespace BTH1_HuynhGiaThinh_24521680
{
    internal class Bai03
    {
        static int[,] NhapMaTran(int n, int m)
        {
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            return a;
        }

        static void XuatMaTran(int[,] a)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j] + "\t");
                Console.WriteLine();
            }
        }

        static bool TimKiem(int[,] a, int x)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (a[i, j] == x) return true;
            return false;
        }

        static bool LaSoNguyenTo(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i * i <= x; i++)
                if (x % i == 0) return false;
            return true;
        }

        static void XuatSoNguyenTo(int[,] a)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            Console.WriteLine("Cac so nguyen to trong ma tran:");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (LaSoNguyenTo(a[i, j]))
                        Console.Write(a[i, j] + " ");
            Console.WriteLine();
        }

        static int DongNhieuNguyenToNhat(int[,] a)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            int dongMax = -1, maxDem = 0;
            for (int i = 0; i < n; i++)
            {
                int dem = 0;
                for (int j = 0; j < m; j++)
                    if (LaSoNguyenTo(a[i, j])) dem++;
                if (dem > maxDem)
                {
                    maxDem = dem;
                    dongMax = i;
                }
            }
            return dongMax;
        }

        public static void Run()
        {
            Console.Write("Nhap so dong n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot m: ");
            int m = int.Parse(Console.ReadLine());
            int[,] a = NhapMaTran(n, m);

            Console.WriteLine("\nMa tran vua nhap:");
            XuatMaTran(a);

            Console.Write("\nNhap phan tu can tim: ");
            int x = int.Parse(Console.ReadLine());
            if (TimKiem(a, x))
                Console.WriteLine($"{x} co ton tai trong ma tran.");
            else
                Console.WriteLine($"{x} khong ton tai trong ma tran.");

            XuatSoNguyenTo(a);
            int dong = DongNhieuNguyenToNhat(a);
            Console.WriteLine($"Dong co nhieu so nguyen to nhat la dong {dong}.");
        }
    }
}
