using ApiNotes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ///  <response code="200"> Returns weather</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ///  <response code="202"> Status accepted</response>
        ///  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ///  <response code="204"> Status no contet</response>
        ///  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ///  <response code="404"> Status no found</response>
        ///  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ///  <response code="205"> Reset content</response>
        ///  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status205ResetContent)]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ///  <response code="205"> Reset content</response>
        ///  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status205ResetContent)]
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

    }
}
