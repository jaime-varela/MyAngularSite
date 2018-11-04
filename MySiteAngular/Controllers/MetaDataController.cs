using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySiteAngular.Models;
using Newtonsoft.Json;
using ParseUtilities;

namespace MySiteAngular.Controllers
{
    [Route("api/[controller]")]
    public class MetaDataController : Controller
    {
        private List<ApiCallMetaData> _metaData;
        public MetaDataController()
        {
            using(StreamReader sr = new StreamReader(Directory.GetCurrentDirectory()+"/"+"ApiMetaData.json"))
            {
                _metaData = JsonConvert.DeserializeObject<List<ApiCallMetaData>>(sr.ReadToEnd());
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> All()
        {
            return await Task.Run(() => Ok(_metaData));
        }

    }
}