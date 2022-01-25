using FraudDetectionAPI.Model;
using FraudDetectionAPI.Rules;
using Xunit;

namespace FraudDetectionAPITest.Rules
{
    public class IdentificationNumberTest
    {
        const int MatchSucess = 100;
        const int MatchFaild = 0;
        private IRule _rule;

        public IdentificationNumberTest()
        {
            _rule = new IdentificationNumberRule();
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
            p2.IdentificationNumber = "12345678";

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
            p1.IdentificationNumber = null;
            p2.IdentificationNumber = null;

            //act
            var matchingValue = _rule.CalculateMaching(p1, p2);

            //assert
            Assert.Equal(MatchFaild, matchingValue);
        }

        private (Person, Person) GetPersons()
        {
            Person p1 = new Person()
            {
                IdentificationNumber = "123456"
            };

            Person p2 = new Person()
            {
                IdentificationNumber = "123456"
            };

            return (p1, p2);
        }
    }
}
