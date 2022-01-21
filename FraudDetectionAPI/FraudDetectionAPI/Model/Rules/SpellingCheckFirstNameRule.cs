using FraudDetectionAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudDetectionAPI.Model.Rules
{
    public class SpellingCheckFirstNameRule : IRule
    {
        public int CalculateMaching(Person person1, Person person2)
        {
            return 15;
        }
    }
}
