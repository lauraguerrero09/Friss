namespace FraudDetectionAPI.Model.Rules
{
    public class IdentificationNumberRule : IRule
    {
        public int CalculateMaching(Person person1, Person person2)
        {
            return person1.IdentificationNumber == person2.IdentificationNumber ? 100 : 0;
        }
    }
}
