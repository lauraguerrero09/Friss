using FraudDetectionAPI.Model;
using FraudDetectionAPI.Service;
using FraudDetectionAPI.TableStorage;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FraudDetectionAPI.Controllers
{
    /// <summary>
    /// Person controller is used to store a person in an Azure table storage
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonEntityService _personEntityService;

        public PersonController(IPersonEntityService personEntityService)
        {
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
