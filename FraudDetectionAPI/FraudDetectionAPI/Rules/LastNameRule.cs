using FraudDetectionAPI.Model;

namespace FraudDetectionAPI.Rules
{
    public class LastNameRule : IRule
    {
        const int MatchingValue = 40;
        public int CalculateMaching(Person person1, Person person2)
        {
            return person1.LastName.ToLower() == person2.LastName.ToLower() ? MatchingValue : 0;
        }
    }
}
