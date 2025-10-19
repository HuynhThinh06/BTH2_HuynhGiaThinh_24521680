using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BTH1_HuynhGiaThinh_24521680
{
    internal class Bai01
    {
             public static void Run()
        {
            Console.Write("Nhap thang: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Nhap nam: ");
            int year = int.Parse(Console.ReadLine());
            if (month < 1 || month > 12 || year < 0)
            {
                Console.WriteLine($"{month}/{year} khong hop le");
                return;
            }
                DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            Console.WriteLine($"Month {month}/{year}:");
            Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");

            int currentDayOfWeek = (int)firstDay.DayOfWeek;
            for (int i = 0; i < currentDayOfWeek; i++)
            {
                Console.Write("\t");
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                Console.Write($"{day}\t");
                currentDayOfWeek++;
                if (currentDayOfWeek > 6)
                {
                    Console.WriteLine();
                    currentDayOfWeek = 0;
                }
            }

            Console.WriteLine();
        }
    }
}
