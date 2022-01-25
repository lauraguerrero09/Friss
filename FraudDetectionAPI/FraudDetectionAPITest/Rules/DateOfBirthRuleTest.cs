using FraudDetectionAPI.Model;
using FraudDetectionAPI.Rules;
using Xunit;

namespace FraudDetectionAPITest.Rules
{
    public class MatchingCalculatorControllerTest
    {
        const int MatchSucess = 40;
        const int MatchFaild = 0;
        private IRule _rule;

        public MatchingCalculatorControllerTest()
        {
            _rule = new DateOfBirthRule();
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
            p2.DateOfBirth = "09/07/1959";

            //act
            var matchingValue = _rule.CalculateMaching(p1, p2);

            //assert
            Assert.Equal(MatchFaild, matchingValue);
        }

        [Fact]
        public void MatchingValueReturn_MatchFaild_When_DateOfBirth_Null()
        {
            //arrange
            var (p1, p2) = GetPersons();
            p1.DateOfBirth = null;
            p2.DateOfBirth = null;

            //act
            var matchingValue = _rule.CalculateMaching(p1, p2);

            //assert
            Assert.Equal(MatchFaild, matchingValue);
        }

        private (Person, Person) GetPersons()
        {
            Person p1 = new Person()
            {
                DateOfBirth = "09/08/1988"
            };

            Person p2 = new Person()
            {
                DateOfBirth = "09/08/1988"
            };

            return (p1, p2);
        }
    }
}
