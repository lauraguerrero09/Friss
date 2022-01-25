using FraudDetectionAPI.Model;

namespace FraudDetectionAPI.Rules
{
    public class DateOfBirthRule : IRule
    {
        const int MatchingValue = 40;
        public int CalculateMaching(Person person1, Person person2)
        {
            if(string.IsNullOrEmpty(person1.DateOfBirth) || string.IsNullOrEmpty(person2.DateOfBirth)) 
            {
                return 0;            
            }

            return person1.DateOfBirth == person2.DateOfBirth ? MatchingValue : 0;
        }
    }
}
