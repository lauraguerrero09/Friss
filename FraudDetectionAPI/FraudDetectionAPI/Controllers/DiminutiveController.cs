using FraudDetectionAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FraudDetectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiminutiveController : ControllerBase
    {
        private readonly ITableStorageService _storageService;
        public DiminutiveController(ITableStorageService storageService)
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
    }
}
