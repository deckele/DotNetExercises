using System;

namespace _3._2_Rationals
{
    public struct Rational
    {
        private int _denom;

        public int Numer { get; private set; }
        public int Denom
        {
            get
            {
                return _denom;
            }
            private set
            {
                if (value != 0)
                {
                    _denom = value;
                }
                else
                {
                    Console.WriteLine("Error: Can't devide by zero!");
                    _denom = 1;
                }
            }
        }
           
        internal Rational(int numer, int denom)
        {
            Numer = numer;
            if(denom != 0)
            {
                _denom = denom;
            }
            else
            {
                Console.WriteLine("Error: Can't devide by zero!");
                _denom = 1;
            }
            
        }
        internal Rational(int numer) : this(numer, 1) { }
        
        public double Value
        {
            get
            {
                if (Denom != 0)
                {
                    return Numer / Denom;
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
            int numer = (rat1.Numer * rat2.Denom) + (rat1.Denom * rat2.Numer);
            int denom = rat1.Denom * rat2.Denom;
            return new Rational(numer, denom);
        }
        public static Rational operator -(Rational rat1, Rational rat2)
        {
            int numer = (rat1.Numer * rat2.Denom) - (rat1.Denom * rat2.Numer);
            int denom = rat1.Denom * rat2.Denom;
            return new Rational(numer, denom);
        }
        public static Rational operator *(Rational rat1, Rational rat2)
        {
            if ((rat1.Numer == 0) || (rat2.Numer == 0))
            {
                return new Rational(0,1);
            }
            else if ((rat1.Denom == 0) || (rat2.Denom == 0))
            {
                throw new DivideByZeroException("Error: invalid operation. Can't devide by zero.");
            }

            int numer = rat1.Numer * rat2.Numer;
            int denom = rat1.Denom * rat2.Denom;
            return new Rational(numer, denom);
        }
        public static Rational operator /(Rational rat1, Rational rat2)
        {
            if ((rat1.Numer == 0) || (rat2.Denom == 0))
            {
                return new Rational(0, 1);
            }
            else if ((rat1.Denom == 0) || (rat2.Numer == 0))
            {
                throw new DivideByZeroException("Error: invalid operation. Can't devide by zero.");
            }

            int numer = rat1.Numer * rat2.Denom;
            int denom = rat1.Denom * rat2.Numer;
            return new Rational(numer, denom);
        }

        public void Reduce()
        {
            int counter=0;
            if ((this.Numer % this.Denom) != 0)
            {
                for(int i=2; i<=Math.Min(this.Numer,this.Denom);)
                {
                    if ((this.Numer % i == 0) && (this.Denom % i == 0))
                    {
                        this.Numer /= i;
                        this.Denom /= i;
                        counter++;
                        i = 2;
                    }
                    else
                    {
                        i++;
                    }
                }
                if (((this.Numer % this.Denom)!=0) && (counter <= 1))
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
            return string.Format("{0} / {1}", this.Numer, this.Denom);
        }
        public override bool Equals(Object obj)
        {
            Rational rat = (Rational)obj;
            if ((Object) rat == null)
            {
                return false;
            }
            return (rat.Numer * this.Denom == rat.Denom * this.Numer);
        }
    }
}