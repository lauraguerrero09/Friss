namespace FraudDetectionAPI.Model
{
    /// <summary>
    /// Interface used to implement Rules patter design
    /// </summary>
    public interface IRule
    {
        public int CalculateMaching(Person person1, Person person2);
    }
}
