using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FizzBuzzLibrary;

namespace FizzBuzzService.Controllers
{
    public class FizzBuzzController : ApiController
    {
        [HttpPost]
        public IEnumerable<string> Post(FizzBuzzRequest Request)
        {
            FizzBuzzLibrary.FizzBuzz myFizzBuzz = new FizzBuzzLibrary.FizzBuzz(Request.Conditions);
            return myFizzBuzz.GetFizzBuzz(Request.LowNumber,Request.HighNumber);
        }
    }
}

