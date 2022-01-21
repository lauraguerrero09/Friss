using FraudDetectionAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FraudDetectionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateMatchingController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CalculateMatchingController> _logger;

        public CalculateMatchingController(ILogger<CalculateMatchingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MatchingResult> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new MatchingResult
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
