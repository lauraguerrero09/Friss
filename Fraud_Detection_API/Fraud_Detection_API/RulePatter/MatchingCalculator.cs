using Fraud_Detection_API.RulePatter;
using Fraud_Detection_API.RulePatter.Rules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fraud_Detection_API.Model
{
    public class MatchingCalculator : IMatchingCalculator
    {

        private IdentificationNumberRule _mainRule;
        private List<IRule> _otherwiseRules = new List<IRule>();

        public MatchingCalculator()
        {
            _mainRule = new IdentificationNumberRule();

            _otherwiseRules.Add(new LastNameRule());
            _otherwiseRules.Add(new FirstNameRule());            
            _otherwiseRules.Add(new DateOfBirthRule());
            _otherwiseRules.Add(new SimilarFirstName());

        }


        public int Calculate(Person person1, Person person2)
        {
            
            var matching = _mainRule.CalculateMaching(person1, person2);

            if (matching > 0)
            {
                return matching;
            }

            matching += _otherwiseRules[0].CalculateMaching(person1, person2);
            matching += _otherwiseRules[1].CalculateMaching(person1, person2);
            matching += _otherwiseRules[2].CalculateMaching(person1, person2);
            matching += _otherwiseRules[4].CalculateMaching(person1, person2)

            return matching;
        }
    }
    public interface IMatchingCalculator
    {
        public int Calculate(Person person);
    }

}
