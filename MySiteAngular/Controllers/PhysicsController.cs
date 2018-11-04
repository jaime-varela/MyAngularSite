using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParseUtilities;
using PhysicsFunctions;

namespace MySiteAngular.Controllers
{
    [Route("api/[controller]")]
    public class PhysicsController : Controller
    {

        [HttpGet("[action]/{speed}/{time}")]
        public async Task<IActionResult> TimeDilationStationaryTime(string speed,string time)
        {
            var parsResultSpeed = TryParser.TryDecimalParse(speed,0.0m,1.0m);
            var parsResultTime  = TryParser.TryDecimalParse(time,0.0m);
            if(parsResultSpeed.Item1 && parsResultTime.Item1)
            {
                var SPEED = parsResultSpeed.Item2;
                var TIME = parsResultTime.Item2;
                var result = await Task.Run(() => { return TimeDilation.TwinParadox(SPEED,TIME,false);});
                return Ok(result);
            }
            else
                return BadRequest("improper speed or time, or inproper input parameters");
        }

        [HttpGet("[action]/{speed}/{time}")]
        public async Task<IActionResult> TimeDilationShipTime(string speed,string time)
        {
            var parsResultSpeed = TryParser.TryDecimalParse(speed,0.0m,1.0m);
            var parsResultTime  = TryParser.TryDecimalParse(time,0.0m);
            if(parsResultSpeed.Item1 && parsResultTime.Item1)
            {
                var SPEED = parsResultSpeed.Item2;
                var TIME = parsResultTime.Item2;
                var result = await Task.Run(() => { return TimeDilation.TwinParadox(SPEED,TIME,true);});
                return Ok(result);
            }
            else
                return BadRequest("improper speed or time, or inproper input parameters");
        }

        [HttpGet("[action]/{mass}")]
        public async Task<IActionResult> SchwarzschildRadus(string mass)
        {
            var parsResultMass = TryParser.TryDoubleParse(mass);
            var G = 6.67408E-11;
            var Msol = 1.989E30;
            var c = 299792458.0;
            if(parsResultMass.Item1 && parsResultMass.Item2 > 0.0)
            {
                var M = parsResultMass.Item2;
                var result = (2.0*G*M*Msol)/(c*c);
                result /= 1000.0;//km conversion
                return Ok(result);
            }
            else
                return BadRequest("improper speed or time, or inproper input parameters");
        }


    }
}