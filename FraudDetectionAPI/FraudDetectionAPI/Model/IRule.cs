namespace FraudDetectionAPI.Model
{
    public interface IRule
    {
        public int CalculateMaching(Person person1, Person person2);
    }
}
