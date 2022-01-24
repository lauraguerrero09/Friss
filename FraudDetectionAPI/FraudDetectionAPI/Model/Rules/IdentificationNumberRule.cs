using FraudDetectionAPI.TableStorage;

namespace FraudDetectionAPI.Model.Rules
{
    public class IdentificationNumberRule : IRule
    {
        const int MatchingValue = 100;
        public int CalculateMaching(Person person1, Person person2)
        {
            if(string.IsNullOrEmpty(person1.IdentificationNumber) || string.IsNullOrEmpty(person2.IdentificationNumber))
            {
                return 0;
            }

            return person1.IdentificationNumber == person2.IdentificationNumber ? MatchingValue : 0;
        }
    }
}
