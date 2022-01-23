namespace FraudDetectionAPI.Model.Rules
{
    public class LastNameRule : IRule
    {
        public int CalculateMaching(Person person1, Person person2)
        {
            return person1.LastName == person2.LastName ? 40 : 0;
        }
    }
}
