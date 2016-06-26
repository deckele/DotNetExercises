using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Rational c = new Rational(numer, denom);
            return c;
        }
        public static Rational operator *(Rational rat1, Rational rat2)
        {
            int numer = rat1.Numer * rat2.Numer;
            int denom = rat1.Denom * rat2.Denom;
            Rational c = new Rational(numer, denom);
            return c;
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
            if (obj == null)
            {
                return false;                
            }
            Rational rat = (Rational) obj;
            if ((Object) rat == null)
            {
                return false;
            }

            return (rat.Numer * this.Denom == rat.Denom * this.Numer);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Rational rat1 = new Rational(1,2);
            Rational rat2 = new Rational(20,60);
            Rational rat3 = new Rational(50,100);

            Console.WriteLine((rat1 + rat2).ToString());
            Console.WriteLine((rat1 * rat3).ToString());
            Console.WriteLine(rat3.Equals(rat1));
            Console.WriteLine(rat3.Equals(rat2));
            Console.WriteLine((rat3).ToString());
            rat3.Reduce();            
            Console.WriteLine((rat3).ToString());
            rat1.Reduce();
        }
    }
}
