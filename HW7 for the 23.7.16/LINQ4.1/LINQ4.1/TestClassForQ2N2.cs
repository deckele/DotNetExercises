using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ4._1
{
    internal class TestClassForQ2N2
    {
        public TestClassForQ2N2(string name, List<string> monthrlyIncome, double hight, int weight,
            bool notDeadYet, string adress)
        {
            Name = name;
            MonthlyIncome = monthrlyIncome;
            Hight = hight;
            Weight = weight;
            NotDeadYet = notDeadYet;
            Adress = adress;
        }
        //tests for 4.1 question 2:
        //1.test copy with different Object type
        public string Name { get; set; }

        //2.test copy of different property type but same Name (original is List<int>, now it's List<string>.
        public List<string> MonthlyIncome { get; set; }

        //3.test get with no set (should not work with same type TestClassForQ2N1 because it only has get).
        //Should work with other type "TestClassForQ2N2" with get and set, same name and property type.
        public double Hight { get; set; }

        //4.test copy to same type "TestClassForQ2N1", but no copy to other type "TestClassForQ2N2" (doesn't have Age property, was replaced with Weight)
        public int Weight { get; set; }

        //5.test private set.
        public bool NotDeadYet { get; private set; }

        //6.test private property.
        private string Adress { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name} made {MonthlyIncome[0]}of $ last month, is {Hight} meters tall, {Weight} Kgs. His being dead status is {NotDeadYet}, and lives at {Adress} street, ");
        }

        public void TestCopyDifferentType(TestClassForQ2N1 originalObject, TestClassForQ2N2 targetObject)
        {
            Console.WriteLine("Test results:");
            Console.WriteLine($"1. Copy same property name and type, different object type: {originalObject.Name == targetObject.Name}.");
            //Testing if different types are similar with ToString().
            Console.WriteLine($"2. Copy property with same name, but different type- List<int> and List<string>: {originalObject.MonthlyIncome[0].ToString() == targetObject.MonthlyIncome[0]}.");
            Console.WriteLine($"3. Copy Get but no Set original property to Get and Set target property- double: {originalObject.Hight.Equals(targetObject.Hight)}.");
            Console.WriteLine($"4. Copy with same property type, but different name- int age and int weight: {originalObject.Age == targetObject.Weight}.");
            Console.WriteLine($"5. Copy private set, same property, different object type- bool: {originalObject.NotDeadYet == targetObject.NotDeadYet}.");
            //No need to check 6... It's false
            Console.WriteLine($"6. Copy private property, same property, different object type: If test 1 was false, this has to be false.");
        }
    }
}
