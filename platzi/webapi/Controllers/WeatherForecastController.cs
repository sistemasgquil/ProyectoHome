using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
  // [Route("[webapi/controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private static List<WeatherForecast>Listweaterforecast= new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if(Listweaterforecast==null && !Listweaterforecast.Any())
            {
               var rng = new Random();
            Listweaterforecast= Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();  
            }
        }
        [HttpGet(Name="GetWeaterForecast")]
        [Route("[action]")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Listweaterforecast;
        }
        [HttpPost]
        public IActionResult Post(WeatherForecast Temperatura) 
        {
           Listweaterforecast.Add(Temperatura);
            return Ok();
        }
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            Listweaterforecast.RemoveAt(index);
            return Ok();
        }

    }
}
