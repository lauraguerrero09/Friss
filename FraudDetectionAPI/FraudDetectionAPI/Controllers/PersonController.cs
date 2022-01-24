using FraudDetectionAPI.Model;
using FraudDetectionAPI.Service;
using FraudDetectionAPI.TableStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FraudDetectionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<MatchingCalculatorController> _logger;
        private readonly IPersonEntityService _personEntityService;

        public PersonController(ILogger<MatchingCalculatorController> logger, IPersonEntityService personEntityService)
        {
            _logger = logger;
            _personEntityService = personEntityService;
        }

        [HttpPut]
        [ActionName(nameof(PutAsync))]
        public async Task<IActionResult> PutAsync([FromBody] Person person)
        {            
            var result = await _personEntityService.InsertOrMergeAsync(PersonEntity.Map(person));
            return Ok(result);
        }
    }
}
