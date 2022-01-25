using FraudDetectionAPI.Model;
using FraudDetectionAPI.Rules;
using Xunit;

namespace FraudDetectionAPITest.Rules
{
    public class FirstNameRuleTest
    {
        const int MatchSucess = 20;
        const int MatchFaild = 0;
        private IRule _rule;

        public FirstNameRuleTest()
        {
            _rule = new FirstNameRule();
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
            p2.FirstName = "Antonio";

            //act
            var matchingValue = _rule.CalculateMaching(p1, p2);

            //assert
            Assert.Equal(MatchFaild, matchingValue);
        }

        private (Person, Person) GetPersons()
        {
            Person p1 = new Person()
            {
                FirstName = "Laura"
            };

            Person p2 = new Person()
            {
                FirstName = "Laura"
            };

            return (p1, p2);
        }
    }
}
