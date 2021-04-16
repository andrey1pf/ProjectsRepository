using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace events
{
    public delegate void CalculatorEventHandler(object sender, CalcEventArgs e);
    class Calculator
    {
        private int delay;
        private bool startCalculation = true;
        public event CalculatorEventHandler calculationEvent;
        public static List<int> halfsimple = new List<int>();
        public Calculator(int _delay)
        {
            delay = _delay;
            if (halfsimple.Count == 0) {
                Thread threadPreCalculation = new Thread(this.preCalculation);
                threadPreCalculation.Start();
            }
        }
        private void preCalculation()
        {
            calculationEvent?.Invoke(this, new CalcEventArgs(0, -1, -1));
            for (int i = 2; i <= 1000000; ++i) {
                if (i % 10000 == 0) {
                    calculationEvent?.Invoke(this, new CalcEventArgs(i / 10000 , -1, -1));
                }
                int countOfDivisors = 0;
                int del = -1;
                for (int j = 2; j <= Math.Sqrt(i); ++j) {
                    if (i % j == 0) {
                        if (del == -1) {
                            del = j;
                        }
                        countOfDivisors++;   
                    }
                }
                if (countOfDivisors == 1 & i / del != Math.Pow(del, 2)) {
                    halfsimple.Add(i);
                }
            }
           Thread threadCalculation = new Thread(this.Calculation);
           threadCalculation.Start();
        }
        public void Calculation()
        {
            while (true) {
                if (!startCalculation) {
                    break;
                }
                Random rnd = new Random();
                int A = rnd.Next(2, 1000000);
                int B = rnd.Next(2, 1000000);
                if (A > B) {
                    A ^= B ^= A ^= B;
                }
                int countHalfsimple = 0;
                for (int i = 0; i <= halfsimple.Count(); ++i) {
                    if(halfsimple[i] >= A) {
                        if (halfsimple[i] >= B) { 
                            break; 
                        }
                        ++countHalfsimple;
                    }
                }
                calculationEvent?.Invoke(this, new CalcEventArgs(countHalfsimple, A, B));
                Thread.Sleep(delay);
            }
            calculationEvent?.Invoke(this, new CalcEventArgs(0, 0, 0));
            startCalculation = true;
        }
        public void Message(object sender, EventArgs ev)
        {
            startCalculation = false;
        }

    }
    public class CalcEventArgs : EventArgs
    {
        private int result;
        private int beg;
        private int end;
        public CalcEventArgs(int res, int a, int b)
        {
            result = res;
            beg = a;
            end = b;
        }
        public int Result
        {
            get { return result; }
        }
        public int Beg
        {
            get { return beg; }
        }
        public int End
        {
            get { return end; }
        }
    }
}
