using FraudDetectionAPI.Model;
using FraudDetectionAPI.Rules;
using FraudDetectionAPI.Service;
using FraudDetectionAPI.TableStorage;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace FraudDetectionAPITest.Rules
{
    public class SimilarFirstNameRuleTest
    {
        const int MatchSucess = 15;
        const int MatchFaild = 0;
        private IRule _rule;
        private Mock<IDiminutiveService> _diminutiveServiceStorage;

        public SimilarFirstNameRuleTest()
        {
            var mockEntity = new DiminutiveEntity { PartitionKey = "laura", Diminutive = "nickname" };
            _diminutiveServiceStorage = new Mock<IDiminutiveService>();
            _diminutiveServiceStorage.Setup(r => r.RetrieveAsync("laura")).Returns(Task.FromResult(mockEntity));

            _rule = new SimilarFirstName(_diminutiveServiceStorage.Object);
        }

        [Fact]
        public void MatchingValueReturn_MatchSucess_When_Match_With_Inicial()
        {
            //arrange
            var (p1, p2) = GetPersons();

            //act
            var matchingValue = _rule.CalculateMaching(p1, p2);

            //assert
            Assert.Equal(MatchSucess, matchingValue);
        }

        [Fact]
        public void MatchingValueReturn_MatchSucess_When_HasDiminutive()
        {
            //arrange
            var (p1, p2) = GetPersons();
            p2.FirstName = "nickname";

            //act
            var matchingValue = _rule.CalculateMaching(p1, p2);

            //assert
            Assert.Equal(MatchSucess, matchingValue);
        }

        [Fact]
        public void MatchingValueReturn_MatchSucess_When_PossibleTypo()
        {
            //arrange
            var (p1, p2) = GetPersons();
            p2.FirstName = "lara";

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
            p2.FirstName = "carlota";

            //act
            var matchingValue = _rule.CalculateMaching(p1, p2);

            //assert
            Assert.Equal(MatchFaild, matchingValue);
        }


        private (Person, Person) GetPersons()
        {
            Person p1 = new Person()
            {
                FirstName = "laura"
            };

            Person p2 = new Person()
            {
                FirstName = "l"
            };

            return (p1, p2);
        }
    }
}
