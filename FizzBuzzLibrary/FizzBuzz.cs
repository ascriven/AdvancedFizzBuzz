using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLibrary
{
    public class FizzBuzz
    {
        List<FizzBuzzCondition> Conditions;
        public FizzBuzz()
        {
            Conditions = new List<FizzBuzzCondition>();
            Conditions.Add(new FizzBuzzCondition(3, "Fizz"));
            Conditions.Add(new FizzBuzzCondition(5, "Buzz"));
        }
        public FizzBuzz(List<FizzBuzzCondition> Conditions)
        {
            this.Conditions = Conditions;
        }
        public string GetIndividualFizzBuzz(int Number)
        {
            string text = "";

            foreach (var item in Conditions)
            {
                if(Number%item.Divider==0)
                {
                    text += item.Word;
                }
            }

            if(text=="")
            {
                text = Number.ToString();
            }

            return text;
        }


        public List<string> GetFizzBuzz(int LowNumber, int HighNumber)
        {
            if (LowNumber >= HighNumber)
            {
                throw new Exception("LowNumber must be less than HighNumber");
            }

            List<string> FizzBuzzList = new List<string>();

            for (int i = LowNumber; i <= HighNumber; i++)
            {
                FizzBuzzList.Add(GetIndividualFizzBuzz(i));
            }

            return FizzBuzzList;
        }
    }
}
