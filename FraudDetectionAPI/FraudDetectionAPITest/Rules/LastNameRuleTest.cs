using FraudDetectionAPI.Model;
using FraudDetectionAPI.Rules;
using Xunit;

namespace FraudDetectionAPITest.Rules
{
    public class LastNameRuleTest
    {
        const int MatchSucess = 40;
        const int MatchFaild = 0;
        private IRule _rule;

        public LastNameRuleTest()
        {
            _rule = new LastNameRule();
        }

        [Fact]
        public void MatchingValueReturn_MatchSucess_When_Match()
        {
            //arrange
            var (p1, p2) = GetPersons();

            //act
            var matchingValue = _rule.CalculateMaching(p1, p2);

            //assert
            Assert.Equal(MatchSucess, matchingValue);
        }

        [Fact]
        public void MatchingValueReturn_MatchFaild_When_NoMatch()
        {
            //arrange
            var (p1, p2) = GetPersons();
            p2.LastName = "Sanchez";

            //act
            var matchingValue = _rule.CalculateMaching(p1, p2);

            //assert
            Assert.Equal(MatchFaild, matchingValue);
        }

        private (Person, Person) GetPersons()
        {
            Person p1 = new Person()
            {
                LastName = "Guerrero"
            };

            Person p2 = new Person()
            {
                LastName = "Guerrero"
            };

            return (p1, p2);
        }
    }
}
