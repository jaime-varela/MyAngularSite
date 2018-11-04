using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParseUtilities;
using MF = MathFunctions;

namespace MySiteAngular.Controllers
{
    [Route("api/[controller]")]
    public class MathController : Controller
    {
        private long factorialMax = 50000;
        private long fibonacciMax = 500000;
        private long binomialMax = 2000000;
        private long gammaMax = 1000;


        [HttpGet("[action]/{number}")]
        public async Task<IActionResult> Factorial(string number)
        {
            var parseResult = TryParser.TryLongParse(number,factorialMax);
            var intval = parseResult.Item2;
            string result = "";
            if(parseResult.Item1)
            {
                result = await Task.Run(() => { return MF.Factorial.FString(intval);});
                return Ok(result);
            }
            else
                return BadRequest(String.Format("improper integer, or integer greater than {0}",factorialMax));
        }
        [HttpGet("[action]/{number}")]
        public async Task<IActionResult> Fibonacci(string number)
        {
            var parseResult = TryParser.TryLongParse(number,fibonacciMax);
            var intval = parseResult.Item2;
            string result = "";
            if(parseResult.Item1)
            {
                result = await Task.Run(() => { return MF.Fibonacci.FString(intval);});
                return Ok(result);
            }
            else
                return BadRequest(String.Format("improper integer, or integer greater than {0}",fibonacciMax));
        }

        [HttpGet("[action]/{number}/{knumber}")]
        public async Task<IActionResult> Binomial(string number,string knumber)
        {
            var parseResult1 = TryParser.TryLongParse(number,binomialMax);
            var parseResult2 = TryParser.TryLongParse(knumber,binomialMax);
            var intval = parseResult1.Item2;
            var intval2= parseResult2.Item2;
            string result = "";
            if(parseResult1.Item1 && parseResult2.Item1)
            {
                result = await Task.Run(() => { return MF.BinomialCoefficient.BinomialString(intval,intval2);});
                return Ok(result);
            }
            else
                return BadRequest(String.Format("improper integer, or integer greater than {0}",binomialMax));
        }
        [HttpGet("[action]/{number}")]
        public async Task<IActionResult> Gamma(string number)
        {
            var parseResult = TryParser.TryDoubleParse(number);
            var dval = parseResult.Item2;
            string result = "";
            if(parseResult.Item1)
            {
                result = await Task.Run(() => { return MF.SpecialFunctions.Gamma(dval).ToString();});
                return Ok(result);
            }
            else
                return BadRequest(String.Format("improper number, or integer number than {0}",gammaMax));
        }

    }
}
