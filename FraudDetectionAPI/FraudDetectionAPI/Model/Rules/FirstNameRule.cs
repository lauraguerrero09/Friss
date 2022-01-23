using FraudDetectionAPI.Model;

namespace FraudDetectionAPI.Model.Rules
{
    public class FirstNameRule : IRule
    {
        public int CalculateMaching(Person person1, Person person2)
        {
            return person1.FirstName == person2.FirstName ? 20 : 0;
        }
    }
}
