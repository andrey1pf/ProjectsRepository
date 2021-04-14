using System;
using System.Threading;

namespace main
{
    public class DadMomClass
    {
        private int _repeat;

        private int _timeDelay;

        private string _message;

        public static int numberRepeat;

        public static string checkNumber;
        
        public DadMomClass(string message, int repeat, int timeDelay)
        {
            this._message = message;
            this._repeat = repeat;
            this._timeDelay = timeDelay;
        }
        
        public void Print() {
            if (checkNumber == "Y") {
                for (int i = 0; i < numberRepeat; ++i) {
                    if (numberRepeat == 0) {
                        break;
                    }
                    Thread.Sleep(_timeDelay);
                    Console.WriteLine(_message);
                    --numberRepeat;
                }
            }

            if (checkNumber == "N") {
                for (int i = 0; i < _repeat; ++i) {
                    Thread.Sleep(_timeDelay);
                    Console.WriteLine(_message);
                }
            }

            if (checkNumber != "Y" && checkNumber != "N") {
                Console.WriteLine("Вы не выбрали вариант окончания программы");
            }
        }
    };
}
