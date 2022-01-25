using FraudDetectionAPI.Model;
using FraudDetectionAPI.Rules;
using Microsoft.AspNetCore.Mvc;

namespace FraudDetectionAPI.Controllers
{
    /// <summary>
    /// Matching controller calculate possible duplicate person base in 2 entries.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MatchingCalculatorController : ControllerBase
    {
        private readonly IMatchingCalculator _matchingCalculator;

        public MatchingCalculatorController(IMatchingCalculator matchingCalculator)
        {
            _matchingCalculator = matchingCalculator;
        }

        [HttpPost]
        public MatchingResponse Matching([FromBody] MatchingRequest request)
        {
            var matchingValue = _matchingCalculator.Calculate(request.Person1, request.Person2);
            var result = new MatchingResponse { Person1 = request.Person1, Person2 = request.Person2, Result = matchingValue };

            return result;
        }
    }
}
