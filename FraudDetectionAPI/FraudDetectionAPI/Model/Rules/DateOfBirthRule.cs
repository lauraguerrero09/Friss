namespace FraudDetectionAPI.Model.Rules
{
    public class DateOfBirthRule : IRule
    {
        public int CalculateMaching(Person person1, Person person2)
        {
            return person1.DateOfBirth == person2.DateOfBirth ? 40 : 0; 
        }
    }
}
