using FraudDetectionAPI.Rules;
using FraudDetectionAPI.Service;
using System.Collections.Generic;

namespace FraudDetectionAPI.Model
{
    public class RuleConfigurator : IRuleConfigurator
    {
        private List<IRule> _rules;

        public List<IRule> GetRules() {           
            return _rules;         
        }

        public RuleConfigurator(IDiminutiveService serviceStorage)
        {
            _rules = new List<IRule>();
            _rules.Add(new IdentificationNumberRule());
            _rules.Add(new LastNameRule());
            _rules.Add(new FirstNameRule());
            _rules.Add(new SimilarFirstName(serviceStorage));
            _rules.Add(new DateOfBirthRule());
        }    
    }
    public interface IRuleConfigurator 
    {
        public List<IRule> GetRules();
    }
}
