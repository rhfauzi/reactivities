using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static readonly string[] CarName = new[]
        {
            "Honda", "Toyota", "Suzuki", "Tesla", "Carera", "Yamaha"
        };
        // private readonly IMediator mediator;
        // public WeatherForecastController(IMediator mediator)
        // {
        //     this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        // }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // [HttpGet("car")]
        // public IEnumerable<WeatherForecast> GetCar()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }

        /// <summary>
        /// Get car
        /// </summary>
        // PUT api/car
        // [HttpGet("car")]
        // public async Task<CarDetails> GetCar([FromQuery] int Id, [FromQuery] string Name)
        // {
        //     var rng = new Random();
        //     var result = await mediator.Send(new CarDetails
        //     {
        //         Id = rng.Next(1, 9999999),
        //         Name = CarName[rng.Next(CarName.Length)],
        //         Created = DateTime.Now.AddDays(1),
        //         LastModified = DateTime.Now.AddDays(2),
        //     });
        //     return new JsonResult(result);
        // }
    }
}
