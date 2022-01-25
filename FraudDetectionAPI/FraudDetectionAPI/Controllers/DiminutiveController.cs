using FraudDetectionAPI.Service;
using FraudDetectionAPI.TableStorage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FraudDetectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiminutiveController : ControllerBase
    {
        private readonly IDiminutiveService _storageService;
        public DiminutiveController(IDiminutiveService storageService)
        {
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        }

        [HttpGet]
        [ActionName(nameof(GetAsync))]
        public async Task<IActionResult> GetAsync([FromQuery] string name)
        {
            var result = await _storageService.RetrieveAsync(name);
            return Ok(result.Diminutive);
        }

        [HttpPut]
        [ActionName(nameof(PutAsync))]
        public async Task<IActionResult> PutAsync([FromQuery] string name, string diminutive)
        {
            var entity = new DiminutiveEntity()
            {
                PartitionKey = name,
                RowKey = name,
                Diminutive = diminutive
            };

            var result = await _storageService.InsertOrMergeAsync(entity);
            return Ok(result);
        }

    }
}
