using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2_HuynhGiaThinh_24521680
{
    class Phanso
    {
        private int tuso;
        private int mauso;

        public void Nhap()
        {
            Console.Write("- Tu so: ");
            tuso = int.Parse(Console.ReadLine());
            Console.Write("- Mau so: ");
            mauso = int.Parse(Console.ReadLine());
            while (mauso == 0)
            {
                Console.WriteLine("Mau so phai khac 0! Nhap lai:");
                Console.Write("- Mau so: ");
                mauso = int.Parse(Console.ReadLine());
            }
            RutGon();
        }

        public void Xuat()
        {
            if (mauso == 1)
                Console.Write("{0} ", tuso);
            else
                Console.Write("{0}/{1} ", tuso, mauso);
        }

        private void RutGon()
        {
            int a = Math.Abs(tuso);
            int b = Math.Abs(mauso);
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            int gcd = a == 0 ? 1 : a;
            tuso /= gcd;
            mauso /= gcd;
            if (mauso < 0)
            {
                tuso = -tuso;
                mauso = -mauso;
            }
        }

        public static Phanso operator +(Phanso a, Phanso b)
        {
            Phanso result = new Phanso();
            result.tuso = a.tuso * b.mauso + b.tuso * a.mauso;
            result.mauso = a.mauso * b.mauso;
            result.RutGon();
            return result;
        }

        public static Phanso operator -(Phanso a, Phanso b)
        {
            Phanso result = new Phanso();
            result.tuso = a.tuso * b.mauso - b.tuso * a.mauso;
            result.mauso = a.mauso * b.mauso;
            result.RutGon();
            return result;
        }

        public static Phanso operator *(Phanso a, Phanso b)
        {
            Phanso result = new Phanso();
            result.tuso = a.tuso * b.tuso;
            result.mauso = a.mauso * b.mauso;
            result.RutGon();
            return result;
        }

        public static Phanso operator /(Phanso a, Phanso b)
        {
            Phanso result = new Phanso();
            result.tuso = a.tuso * b.mauso;
            result.mauso = a.mauso * b.tuso;
            result.RutGon();
            return result;
        }

        public static bool operator >(Phanso a, Phanso b)
        {
            return (double)a.tuso / a.mauso > (double)b.tuso / b.mauso;
        }

        public static bool operator <(Phanso a, Phanso b)
        {
            return (double)a.tuso / a.mauso < (double)b.tuso / b.mauso;
        }
    }

    internal class Bai04
    {
        public static void Run()
        {
            Phanso a = new Phanso();
            Phanso b = new Phanso();

            Console.WriteLine("Phan so thu nhat:");
            a.Nhap();
            Console.WriteLine("Phan so thu hai:");
            b.Nhap();

            Phanso func;
            func = a + b; Console.Write("Tong: "); func.Xuat(); Console.WriteLine();
            func = a - b; Console.Write("Hieu: "); func.Xuat(); Console.WriteLine();
            func = a * b; Console.Write("Tich: "); func.Xuat(); Console.WriteLine();
            func = a / b; Console.Write("Thuong: "); func.Xuat(); Console.WriteLine();

            Console.Write("So phan tu: ");
            int n = int.Parse(Console.ReadLine());
            Phanso[] arr = new Phanso[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Phan so thu {i + 1}:");
                arr[i] = new Phanso();
                arr[i].Nhap();
            }


            Phanso max = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > max) max = arr[i];
            Console.Write("\nPhan so lon nhat: ");
            max.Xuat();
            Console.WriteLine();

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] > arr[j])
                    {
                        Phanso temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }

            Console.Write("\nDay sau khi sap xep tang dan: ");
            foreach (Phanso f in arr) f.Xuat();
            Console.WriteLine();
        }
    }
}
