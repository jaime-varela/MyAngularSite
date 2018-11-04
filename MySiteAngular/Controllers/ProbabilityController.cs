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
    public class ProbabilityController : Controller
    {
        private long binomialMax = 230;
        [HttpGet("[action]/{probability}/{number}/{knumber}")]
        public async Task<IActionResult> BinomialDistribution(string probability,string number,string knumber)
        {
            var parseResult1 = TryParser.TryDoubleParse(probability);
            var parseResult2 = TryParser.TryLongParse(number,binomialMax);
            var parseResult3 = TryParser.TryLongParse(knumber,binomialMax);
            var n = parseResult2.Item2;
            var k = parseResult3.Item2;
            var p = parseResult1.Item2;
            if(parseResult1.Item1 && parseResult2.Item1 && (p < 1.0 && p > 0.0) && n > k)
            {
                var result = await Task.Run(() => { return ((double) MF.BinomialCoefficient.Binomial(n,k)) * Math.Pow(p/(1-p),k) * Math.Pow(1-p,n);});
                return Ok(result);
            }
            else
                return BadRequest(String.Format("improper integers or probability, or integer greater than {0}",binomialMax));                        
        }
    }
}
