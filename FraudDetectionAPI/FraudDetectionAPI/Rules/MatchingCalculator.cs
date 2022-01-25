using FraudDetectionAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace FraudDetectionAPI.Rules
{
    public class MatchingCalculator : IMatchingCalculator
    {
        private List<IRule> _rules;

        public MatchingCalculator(IRuleConfigurator ruleConfigurator)
        {
            _rules = ruleConfigurator.GetRules();
        }

        public int Calculate(Person person1, Person person2)
        {            

            var matching = _rules.FirstOrDefault().CalculateMaching(person1, person2);

            if (matching > 0)
            {
                return matching;
            }

            return _rules.Skip(0).Sum(c => c.CalculateMaching(person1, person2));
        }
    }
    public interface IMatchingCalculator
    {
        public int Calculate(Person person1, Person person2);
    }

}
