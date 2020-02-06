using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace countrylist.api.ses.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public CountryController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            logger.Log(LogLevel.Information, "Test message");
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            using (StreamReader r = new StreamReader("/Users/Hemal/Projects/api.ses/countrylist.api.ses/Data/CountryList.json"))
            {
                string json = r.ReadToEnd();
                List<Country> items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Country>>(json);
                return items;
            }
        }
    }
}
