using System;

namespace AppendixRationals
{
    public struct Rational
    {
        private int _denominator;

        public int Numerator { get; private set; }
        public int Denominator
        {
            get
            {
                return _denominator;
            }
            private set
            {
                if (value != 0)
                {
                    _denominator = value;
                }
                else
                {
                    Console.WriteLine("Error: Can't devide by zero!");
                    _denominator = 1;
                }
            }
        }

        internal Rational(int numerator, int denom)
        {
            Numerator = numerator;
            if (denom != 0)
            {
                _denominator = denom;
            }
            else
            {
                Console.WriteLine("Error: Can't devide by zero!");
                _denominator = 1;
            }

        }
        internal Rational(int numerator) : this(numerator, 1) { }

        public double Value
        {
            get
            {
                if (Denominator != 0)
                {
                    return Numerator / Denominator;
                }
                else
                {
                    Console.WriteLine("Error: Can't devide by zero!");
                    return 0;
                }
            }
        }

        public static Rational operator +(Rational rat1, Rational rat2)
        {
            int numer = (rat1.Numerator * rat2.Denominator) + (rat1.Denominator * rat2.Numerator);
            int denom = rat1.Denominator * rat2.Denominator;
            return new Rational(numer, denom);
        }
        public static Rational operator -(Rational rat1, Rational rat2)
        {
            int numer = (rat1.Numerator * rat2.Denominator) - (rat1.Denominator * rat2.Numerator);
            int denom = rat1.Denominator * rat2.Denominator;
            return new Rational(numer, denom);
        }
        public static Rational operator *(Rational rat1, Rational rat2)
        {
            if ((rat1.Numerator == 0) || (rat2.Numerator == 0))
            {
                return new Rational(0, 1);
            }
            else if ((rat1.Denominator == 0) || (rat2.Denominator == 0))
            {
                throw new DivideByZeroException("Error: invalid operation. Can't devide by zero.");
            }

            int numer = rat1.Numerator * rat2.Numerator;
            int denom = rat1.Denominator * rat2.Denominator;
            return new Rational(numer, denom);
        }
        public static Rational operator /(Rational rat1, Rational rat2)
        {
            if ((rat1.Numerator == 0) || (rat2.Denominator == 0))
            {
                return new Rational(0, 1);
            }
            else if ((rat1.Denominator == 0) || (rat2.Numerator == 0))
            {
                throw new DivideByZeroException("Error: invalid operation. Can't devide by zero.");
            }

            int numer = rat1.Numerator * rat2.Denominator;
            int denom = rat1.Denominator * rat2.Numerator;
            return new Rational(numer, denom);
        }

        public void Reduce()
        {
            int counter = 0;
            if ((this.Numerator % this.Denominator) != 0)
            {
                for (int i = 2; i <= Math.Min(this.Numerator, this.Denominator);)
                {
                    if ((this.Numerator % i == 0) && (this.Denominator % i == 0))
                    {
                        this.Numerator /= i;
                        this.Denominator /= i;
                        counter++;
                        i = 2;
                    }
                    else
                    {
                        i++;
                    }
                }
                if (((this.Numerator % this.Denominator) != 0) && (counter <= 1))
                {
                    Console.WriteLine("No need to reduce.");
                }
            }
            else
            {
                Console.WriteLine("No need to reduce.");
            }
        }

        public override string ToString()
        {
            return string.Format("{0} / {1}", this.Numerator, this.Denominator);
        }
        public override bool Equals(Object obj)
        {
            Rational rat = (Rational)obj;
            if ((Object)rat == null)
            {
                return false;
            }
            return (rat.Numerator * this.Denominator == rat.Denominator * this.Numerator);
        }
        public override int GetHashCode()
        {
            return this.Numerator^this.Denominator;
        }
    }
}