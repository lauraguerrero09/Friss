namespace FraudDetectionAPI.Model.Rules
{
    public class FirstNameRule : IRule
    {
        const int MatchingValue = 20;
        public int CalculateMaching(Person person1, Person person2)
        {
            return person1.FirstName == person2.FirstName ? MatchingValue : 0;
        }
    }
}
