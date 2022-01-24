using FraudDetectionAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FraudDetectionAPI.Controllers
{
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
        public MatchingResponse GetMatching([FromBody] MatchingRequest request)
        {
            var matchingValue = _matchingCalculator.Calculate(request.Person1, request.Person2);
            var result = new MatchingResponse { Person1 = request.Person1, Person2 = request.Person2, Result = matchingValue };

            return result;
        }
    }
}
