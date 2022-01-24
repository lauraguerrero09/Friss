using FraudDetectionAPI.TableStorage;

namespace FraudDetectionAPI.Model.Rules
{
    public class LastNameRule : IRule
    {
        const int MatchingValue = 40;
        public int CalculateMaching(Person person1, Person person2)
        {
            return person1.LastName == person2.LastName ? MatchingValue : 0;
        }
    }
}
