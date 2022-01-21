using FraudDetectionAPI.Model;

namespace FraudDetectionAPI.Model.Rules
{
    public class DiminutiveNameRule : IRule
    {
        public int CalculateMaching(Person person1, Person person2)
        {
            return 15;
        }
    }
}
