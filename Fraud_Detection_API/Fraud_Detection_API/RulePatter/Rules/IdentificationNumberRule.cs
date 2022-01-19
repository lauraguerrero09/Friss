using Fraud_Detection_API.Model;

namespace Fraud_Detection_API.RulePatter.Rules
{
    public class IdentificationNumberRule : IRule
    {
        public int CalculateMaching(Person person1, Person person2)
        {
            return person1.IdentificationNumber == person2.IdentificationNumber ? 100 : 0;
        }
    }
}
