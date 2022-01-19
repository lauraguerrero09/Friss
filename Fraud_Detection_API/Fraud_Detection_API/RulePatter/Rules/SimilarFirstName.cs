using Fraud_Detection_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud_Detection_API.RulePatter.Rules
{
    public static class SimilarFirstName
    {
        public static int Evaluate(Person person1, Person person2)
        {
            var result = 0;

            result = SameInitials(person1.FirstName, person2.FirstName);
            result = DiminutiveName(person1.FirstName, person2.FirstName);
            result = SpellingChek(person1.FirstName, person2.FirstName);

            return result;
        }

        private static int SameInitials(string firstName1, string firstName2)
        {

            return firstName1[0] == firstName2[0] ? 15 : 0;
        }
        private static int DiminutiveName(string firstName1, string firstName2)
        {

            return firstName1[0] == firstName2[0] ? 15 : 0;
        }
        private static int SpellingChek(string firstName1, string firstName2)
        {

            return firstName1[0] == firstName2[0] ? 15 : 0;
        }
    }
}
