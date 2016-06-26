using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2._5_MulBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = 0;
            int column=0;
            for (row = 1; row <= 10; row++)
            {
                for(column=1; column<=10; column++)
                {
                    Console.Write(String.Format("{0,4}", (row * column)));
                
                }
                Console.WriteLine("");
            }
        }
    }
}
