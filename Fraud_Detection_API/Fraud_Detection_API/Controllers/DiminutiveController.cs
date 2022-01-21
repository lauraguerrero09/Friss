using Fraud_Detection_API.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fraud_Detection_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiminutiveController : ControllerBase
    {
        private readonly ITableStorageService _storageService;
        //public DiminutiveController(ITableStorageService storageService)
        //{
        //    _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        //}

        //[HttpGet]
        //[ActionName(nameof(GetAsync))]
        //public async Task<IActionResult> GetAsync([FromQuery] string name)
        //{
        //    return Ok(await _storageService.RetrieveAsync(name));
        //}

        [HttpGet]
        [ActionName(nameof(GetAsync))]
        public bool GetAsync([FromQuery] string name)
        {
            return true;
        }

    }
}
