using FraudDetectionAPI.Model;
using FraudDetectionAPI.Service;
using FraudDetectionAPI.TableStorage;
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

        [HttpPost]
        public MatchingResponse GetMatching([FromBody] MatchingRequest request)
        {
            var matchingValue = _matchingCalculator.Calculate(request.Person1, request.Person2);
            var result = new MatchingResponse { Person1 = request.Person1, Person2 = request.Person2, Result = matchingValue };

            return result;
        }
    }
}
