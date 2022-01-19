using Fraud_Detection_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud_Detection_API.RulePatter.Rules
{
    public class FirstNameRule : IRule
    {
        public int CalculateMaching(Person person1, Person person2)
        {
            return person1.FirstName == person2.FirstName ? 40 : 0;
        }
    }
}
