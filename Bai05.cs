using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2_HuynhGiaThinh_24521680
{
    class KhuDat
    {
        protected string Diem;
        protected long GiaBan;
        protected double DienTich;

        public virtual void Nhap()
        {
            Console.Write("Nhap dia diem: ");
            Diem = Console.ReadLine();
            Console.Write("Nhap gia ban (VND): ");
            GiaBan = long.Parse(Console.ReadLine());
            Console.Write("Nhap dien tich (m2): ");
            DienTich = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }

        public virtual void Xuat()
        {
            Console.WriteLine($"Dia diem: {Diem}, Gia ban: {GiaBan:N0} VND, Dien tich: {DienTich} m2");
        }

        public long GetGia() => GiaBan;
        public double GetDienTich() => DienTich;
        public string GetDiem() => Diem;
    }

    class NhaPho : KhuDat
    {
        private int NamXD;
        private int SoTang;

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap nam xay dung: ");
            NamXD = int.Parse(Console.ReadLine());
            Console.Write("Nhap so tang: ");
            SoTang = int.Parse(Console.ReadLine());
        }

        public override void Xuat()
        {
            Console.WriteLine($"[Nha pho] Dia diem: {Diem}, Gia ban: {GiaBan:N0} VND, Dien tich: {DienTich} m2, Nam XD: {NamXD}, So tang: {SoTang}");
        }

        public int GetNamXD() => NamXD;
    }

    class ChungCu : KhuDat
    {
        private int TangXD;

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap tang xay dung: ");
            TangXD = int.Parse(Console.ReadLine());
        }

        public override void Xuat()
        {
            Console.WriteLine($"[Chung cu] Dia diem: {Diem}, Gia ban: {GiaBan:N0} VND, Dien tich: {DienTich} m2, Tang XD: {TangXD}");
        }
    }

    internal class Bai05
    {
        static public void Run()
        {
            List<KhuDat> ds = new List<KhuDat>();

            Console.Write("Nhap so luong bat dong san: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhap thong tin thu {i + 1}:");
                Console.WriteLine("1. Khu dat");
                Console.WriteLine("2. Nha pho");
                Console.WriteLine("3. Chung cu");
                Console.Write("Chon loai: ");
                int loai = int.Parse(Console.ReadLine());

                KhuDat obj = null;
                switch (loai)
                {
                    case 1:
                        obj = new KhuDat();
                        break;
                    case 2:
                        obj = new NhaPho();
                        break;
                    case 3:
                        obj = new ChungCu();
                        break;
                    default:
                        Console.WriteLine("Loai khong hop le!");
                        i--;
                        continue;
                }
                obj.Nhap();
                ds.Add(obj);
            }

            Console.WriteLine("\n=== DANH SACH BAT DONG SAN ===");
            foreach (var x in ds)
                x.Xuat();

            long tongKhuDat = 0, tongNhaPho = 0, tongChungCu = 0;
            foreach (var x in ds)
            {
                if (x is NhaPho) tongNhaPho += x.GetGia();
                else if (x is ChungCu) tongChungCu += x.GetGia();
                else tongKhuDat += x.GetGia();
            }

            Console.WriteLine("\n=== TONG GIA BAN TUNG LOAI ===");
            Console.WriteLine($"Tong khu dat: {tongKhuDat:N0} VND");
            Console.WriteLine($"Tong nha pho: {tongNhaPho:N0} VND");
            Console.WriteLine($"Tong chung cu: {tongChungCu:N0} VND");

            Console.WriteLine("\n=== CAC BAT DONG SAN THOA DIEU KIEN ===");
            foreach (var x in ds)
            {
                if (x is NhaPho np)
                {
                    if (x.GetDienTich() > 60 && np.GetNamXD() >= 2019)
                        x.Xuat();
                }
                else if (!(x is ChungCu))
                {
                    if (x.GetDienTich() > 100)
                        x.Xuat();
                }
            }

            Console.WriteLine("\n=== TIM KIEM BAT DONG SAN ===");
            Console.Write("Nhap chuoi dia diem can tim: ");
            string key = Console.ReadLine().ToLower();
            Console.Write("Nhap gia ban toi da: ");
            long gia = long.Parse(Console.ReadLine());
            Console.Write("Nhap dien tich toi thieu: ");
            double dientich = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("\n=== KET QUA TIM KIEM ===");
            foreach (var x in ds)
            {
                if (x is NhaPho || x is ChungCu)
                {
                    if (x.GetDiem().ToLower().Contains(key) && x.GetGia() <= gia && x.GetDienTich() >= dientich)
                        x.Xuat();
                }
            }
        }
    }

}
