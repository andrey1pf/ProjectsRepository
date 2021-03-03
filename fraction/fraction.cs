using System;

namespace fractions
{
    class Fraction
    {
        private long _numerator;
        private long _denominator;

        public Fraction()
        {
            _numerator = 0;
            _denominator = 1;
        }
        public Fraction(long numerator, long denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }

            _numerator = numerator;
            _denominator = denominator;
            ReduceFraction();
        }

        private void ReduceFraction()
        {
            checked
            {
                var temp = Math.Abs(Math.Abs(_numerator) > Math.Abs(_denominator) ? _denominator : _numerator);

                for (long i = 2; i < temp; ++i)
                {
                    if (_numerator % i != 0 || _denominator % i != 0) continue;
                    _numerator /= i;
                    _denominator /= i;
                }

                if (_numerator == 0)
                {
                    _denominator = 1;
                }
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            checked
            {
                var addition = new Fraction(f1._numerator * f2._denominator + f2._numerator * f1._denominator,
                    f1._denominator * f2._denominator);
                addition.ReduceFraction();
                return addition;
            }
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            checked
            {
                var difference = new Fraction(f1._numerator * f2._denominator - f2._numerator * f1._denominator,
                    f1._denominator * f2._denominator);
                difference.ReduceFraction();
                return difference;
            }
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            checked
            {
                var multiplication =
                    new Fraction(f1._numerator * f2._numerator, f1._denominator * f2._denominator);
                multiplication.ReduceFraction();
                return multiplication;
            }
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            checked
            {
                var division = new Fraction(f1._numerator * f2._denominator, f1._denominator * f2._numerator);
                division.ReduceFraction();
                return division;
            }
        }

        public static Fraction operator -(Fraction f1)
        {
            var unaryMinus = new Fraction(-f1._numerator, f1._denominator);
            return unaryMinus;
        }

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            checked
            {
                return f2 is { } && f1 is { } && f1._numerator * f2._denominator == f1._denominator * f2._numerator;
            }
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        public static bool operator >(Fraction f1, Fraction f2)
        {
            checked
            {
                return f1._numerator * f2._denominator > f1._denominator * f2._numerator;
            }
        }

        public static bool operator <(Fraction f1, Fraction f2)
        {
            checked
            {
                return f1._numerator * f2._denominator < f1._denominator * f2._numerator;
            }
        }

        public static bool operator >=(Fraction f1, Fraction f2)
        {
            return !(f1 < f2);
        }

        public static bool operator <=(Fraction f1, Fraction f2)
        {
            return !(f1 > f2);
        }

        public override string ToString()
        {
            if ((double) _numerator / _denominator >= 0)
            {
                return Math.Abs(_numerator) + "/" + Math.Abs(_denominator);
            }
            else
            {
                return "-" + Math.Abs(_numerator) + "/" + Math.Abs(_denominator);
            }
        }

        public double ToDouble()
        {
            checked
            {
                return (double) _numerator / _denominator;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Fraction fraction &&
                   _numerator == fraction._numerator &&
                   _denominator == fraction._denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_numerator, _denominator);
        }
    }

    internal class HashCode
    {
        public static int Combine(long numerator, long denominator)
        {
            throw new NotImplementedException();
        }
    }
}
