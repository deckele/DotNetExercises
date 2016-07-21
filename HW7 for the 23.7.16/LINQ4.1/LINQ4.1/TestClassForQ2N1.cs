using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ4._1
{
    internal class TestClassForQ2N1
    {
        public TestClassForQ2N1(string name, List<int> monthrlyIncome, double hight, int age, 
            bool notDeadYet, string adress)
        {
            Name = name;
            MonthlyIncome = monthrlyIncome;
            Hight = hight;
            Age = age;
            NotDeadYet = notDeadYet;
            Adress = adress;
        }
        //tests for 4.1 question 2:
        //1.test copy
        public string Name { get; set; }

        //2.test copy of type List<>.
        public List<int> MonthlyIncome { get; set; }

        //3.test get with no set (should not work with same type TestClassForQ2N1).
        //Should work with other type "TestClassForQ2N2" with get and set, same name and property type.
        public double Hight { get; }

        //4.test copy to same type "TestClassForQ2N1", but no copy to other type "TestClassForQ2N2" (doesn't have Age property)
        public int Age { get; set; }

        //5.test private set.
        public bool NotDeadYet { get; private set; }

        //6.test private property.
        private string Adress { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name} made {MonthlyIncome[0]}$ last month, is {Hight} meters tall, {Age} years old. His being dead status is {NotDeadYet}, and lives at {Adress} street, ");
        }

        public void TestCopy(TestClassForQ2N1 originalObject, TestClassForQ2N1 targetObject)
        {
            Console.WriteLine("Test results:");
            Console.WriteLine($"1. Regular copy- string: {originalObject.Name == targetObject.Name}.");
            Console.WriteLine($"2. Regular copy- List<int>: {originalObject.MonthlyIncome == targetObject.MonthlyIncome}.");
            Console.WriteLine($"3. Copy Get but no Set- double: {originalObject.Hight.Equals(targetObject.Hight)}.");
            Console.WriteLine($"4. Regular copy- int: {originalObject.Age == targetObject.Age}.");
            Console.WriteLine($"5. Copy private set- bool: {originalObject.NotDeadYet == targetObject.NotDeadYet}.");
            Console.WriteLine($"6. Copy private property- string: {originalObject.Adress == targetObject.Adress}.");
        }
    }
}
