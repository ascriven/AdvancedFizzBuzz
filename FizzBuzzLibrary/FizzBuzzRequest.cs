using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLibrary
{
    public class FizzBuzzRequest
    {
        public List<FizzBuzzCondition> Conditions { get; set; }
        public int LowNumber { get; set; }
        public int HighNumber { get; set; }
    }
}
