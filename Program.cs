using System;

namespace fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите числитель первой дроби: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите знаменатель первой дроби: ");
            int b = int.Parse(Console.ReadLine());
            Fraction f1 = new Fraction(a, b);
            Console.Write("Введите числитель второй дроби: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Введите знаменатель второй дроби: ");
            b = int.Parse(Console.ReadLine());
            try
            {
                if (b == 0) { }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Fraction f2 = new Fraction(a, b);
            Console.WriteLine("Первая дробь: " + f1.ToString());
            Console.WriteLine("Вторая дробь: " + f2.ToString());
            Console.WriteLine("Рациональный вид первой дроби: " + f1.ToDouble());
            Console.WriteLine("Рациональный вид второй дроби: " + f2.ToDouble());
            Console.WriteLine("Сумма в дробях:" + (f1 + f2));
            Console.WriteLine("Сумма в рациональном виде: " + (f1 + f2).ToDouble());
            Console.WriteLine("Разность в дробях: " + (f1 - f2));
            Console.WriteLine("Разность в рациональном виде: " + (f1 - f2).ToDouble());
            Console.WriteLine("Произведение в дробях: " + (f1 * f2));
            Console.WriteLine("Произведение в рациональном виде: " + (f1 * f2).ToDouble());
            Console.WriteLine("Деление в дробях: " + (f1 / f2));
            Console.WriteLine("Деление в рациональном виде: " + (f1 / f2).ToDouble());
            Console.WriteLine("Первая дробь с унарным минусом: " + f1.ToString());
            Console.WriteLine("Вторая дробь с унарным минусом: " + f2.ToString());
            Console.WriteLine("Первая дробь с унарным минусом в рациональном виде: " + f1.ToDouble());
            Console.WriteLine("Вторая дробь с унарным минусом в рациональном виде: " + f2.ToDouble());
            f1 = -f1;
            f2 = -f2;
            if (f1 == f2)
            {
                Console.WriteLine("Дроби равны");
            }
            if (f1 != f2)
            {
                Console.WriteLine("Дроби не равны");
            }
            if (f1 > f2)
            {
                Console.WriteLine("Первая дробь больше второй");
            }
            if (f1 < f2)
            {
                Console.WriteLine("Первая дробь меньше второй");
            }
            System.Console.ReadKey();
        }
    }
}
