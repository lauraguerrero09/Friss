using FraudDetectionAPI.TableStorage;
using System;

namespace FraudDetectionAPI.Model.Rules
{
    public class DateOfBirthRule : IRule
    {
        public int CalculateMaching(Person person1, Person person2)
        {
            if(string.IsNullOrEmpty(person1.DateOfBirth) || string.IsNullOrEmpty(person2.DateOfBirth)) 
            {
                return 0;            
            }

            return person1.DateOfBirth == person2.DateOfBirth ? 40 : 0;
        }
    }
}
