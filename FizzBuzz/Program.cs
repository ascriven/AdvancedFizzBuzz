using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzLibrary;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FizzBuzzCondition> Conditions = new List<FizzBuzzCondition>();
            Conditions.Add(new FizzBuzzCondition(6, "Hat"));
            Conditions.Add(new FizzBuzzCondition(9, "Mitts"));
            Conditions.Add(new FizzBuzzCondition(21, "Shirt"));
            FizzBuzzLibrary.FizzBuzz myFizzBuzz = new FizzBuzzLibrary.FizzBuzz(Conditions);
            //FizzBuzzLibrary.FizzBuzz myFizzBuzz = new FizzBuzzLibrary.FizzBuzz();
            foreach (var item in myFizzBuzz.GetFizzBuzz(1, 100))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
