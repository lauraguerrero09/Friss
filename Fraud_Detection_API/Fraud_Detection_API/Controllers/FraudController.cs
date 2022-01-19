using Fraud_Detection_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud_Detection_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FraudController : ControllerBase
    {
        private readonly IMatchingCalculator _matchingCalculator;

        public FraudController(IMatchingCalculator matchingCalculator)
        {
            _matchingCalculator = matchingCalculator;
        }

        [HttpGet]
        public List<MachingResult> GetMachingResult() 
        {
           
            Person person = new Person
            {
                FirstName = "Laura",
                LastName = "Guerrero",
                IdentificationNumber = "19501953",
                DateOfBirth = "1988-08-09"
            };

            //TODO get person from azure storage

            var value =  _matchingCalculator.Calculate(person);

            return null;
        
        }
    }
}
