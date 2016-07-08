using System;

namespace AppendixRationals
{
    public struct Rational
    {
        private int _denominator;

        public static implicit operator int(Rational value)
        {
            return value.Numerator/value.Denominator;
        }
        public static implicit operator double(Rational value)
        {
            return value.Value;
        }

        internal Rational(int numerator, int denominator)
        {
            Numerator = numerator;
            if (denominator != 0)
            {
                _denominator = denominator;
            }
            else
            {
                Console.WriteLine("Error: Can't devide by zero!");
                _denominator = 1;
            }

        }
        internal Rational(int numerator) : this(numerator, 1) { }

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

        public double Value
        {
            get
            {
                if (Denominator != 0)
                {
                    return (double)Numerator / Denominator;
                }
                else
                {
                    Console.WriteLine("Error: Can't devide by zero!");
                    return 0;
                }
            }
        }

        public static Rational operator +(Rational rational1, Rational rational2)
        {
            int numerator = (rational1.Numerator * rational2.Denominator) + (rational1.Denominator * rational2.Numerator);
            int denominator = rational1.Denominator * rational2.Denominator;
            return new Rational(numerator, denominator);
        }
        public static Rational operator -(Rational rational1, Rational rational2)
        {
            int numerator = (rational1.Numerator * rational2.Denominator) - (rational1.Denominator * rational2.Numerator);
            int denominator = rational1.Denominator * rational2.Denominator;
            return new Rational(numerator, denominator);
        }
        public static Rational operator *(Rational rational1, Rational rational2)
        {
            if ((rational1.Numerator == 0) || (rational2.Numerator == 0))
            {
                return new Rational(0, 1);
            }
            else if ((rational1.Denominator == 0) || (rational2.Denominator == 0))
            {
                Console.WriteLine("Error: Can't devide by zero!");
                return new Rational(0, 1);
            }

            int numerator = rational1.Numerator * rational2.Numerator;
            int denominator = rational1.Denominator * rational2.Denominator;
            return new Rational(numerator, denominator);
        }
        public static Rational operator /(Rational rational1, Rational rational2)
        {
            if ((rational1.Numerator == 0) || (rational2.Denominator == 0))
            {
                return new Rational(0, 1);
            }
            else if ((rational1.Denominator == 0) || (rational2.Numerator == 0))
            {
                Console.WriteLine("Error: Can't devide by zero!");
                return new Rational(0, 1);
            }

            int numerator = rational1.Numerator * rational2.Denominator;
            int denominator = rational1.Denominator * rational2.Numerator;
            return new Rational(numerator, denominator);
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
            }
        }

        public override string ToString()
        {
            return string.Format($"{Numerator}/{Denominator}");
        }

        public override bool Equals(Object obj)
        {
            Rational rat = (Rational)obj;
            return (rat.Numerator * this.Denominator == rat.Denominator * this.Numerator);
        }

        public override int GetHashCode()
        {
            var rational = this;
            rational.Reduce();
            return rational.Numerator^rational.Denominator;
        }
    }
}