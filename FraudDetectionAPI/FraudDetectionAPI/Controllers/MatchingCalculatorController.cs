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
    public class MatchingCalculatorController : ControllerBase
    {
        private readonly ILogger<MatchingCalculatorController> _logger;
        private readonly IMatchingCalculator _matchingCalculator;

        public MatchingCalculatorController(ILogger<MatchingCalculatorController> logger, IMatchingCalculator matchingCalculator)
        {
            _logger = logger;
            _matchingCalculator = matchingCalculator;
        }

        [HttpGet]
        public MatchingResult GetMatching([FromQuery] Person person)
        {
            Person p1 = new Person
            {
                FirstName = "Laura",
                LastName = "Guerrero",
                IdentificationNumber = "19501953",
                DateOfBirth = new DateTime(2015, 12, 31)
            };

            Person p2 = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                IdentificationNumber = person.IdentificationNumber,
                DateOfBirth = person.DateOfBirth
            };

            var matchingValue = _matchingCalculator.Calculate(p1, p2);
            var result = new MatchingResult { Person1 = p1, Person2 = p2, Result = matchingValue };

            return result;
        }
    }
}
