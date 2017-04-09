using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLibrary
{
    public class FizzBuzzCondition
    {
        public int Divider { get; set; }
        public string Word { get; set; }

        public FizzBuzzCondition(int Divider, string Word)
        {
            this.Divider = Divider;
            this.Word = Word;
        }
    }
}
