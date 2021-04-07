using System;
using System.Threading;

namespace main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //int numberRepeat;
            int numberThread;
            int repeat;
            int timeDelay;
            string message;
            
            Console.WriteLine("Какое кол-во сообщений хотите вывести?");
            DadMomClass.numberRepeat = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("Какое кол-во тредов хотите создать?");
            numberThread = Int32.Parse(Console.ReadLine());

            Thread[] thr = new Thread[numberThread];
            DadMomClass[] properties = new DadMomClass[numberThread];
            
            for (int i = 0; i < numberThread; ++i) {
                Console.WriteLine("Что будет в " + (i+1) + " треде?");
                message = Console.ReadLine();
                Console.WriteLine("Какое кол-во раз вывести сообщение в " + (i+1) + " треде?");
                repeat = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Какая будет заддержка при выводе сообщения в " + (i+1) + " треде?");
                timeDelay = Int32.Parse(Console.ReadLine());
                DadMomClass DadMom = new DadMomClass(message, repeat, timeDelay);
                properties[i] = DadMom;
            }

            Console.WriteLine("Закончить программу по достижению общего кол-ва сообщений [Y/N]");
            DadMomClass.checkNumber = Console.ReadLine();

            for (int i = 0; i < numberThread; ++i) {
                thr[i] = new Thread(properties[i].Print);
            }

            for (int i = 0; i < numberThread; ++i) {
                thr[i].Start();
            }
            
            for (int i = 0; i < numberThread; ++i) {
                thr[i].Join();
            }
        }
    }

}