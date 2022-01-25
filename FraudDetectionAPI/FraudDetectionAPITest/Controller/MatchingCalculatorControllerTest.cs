using FraudDetectionAPI.Controllers;
using FraudDetectionAPI.Model;
using FraudDetectionAPI.Rules;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace FraudDetectionAPITest.Controller
{
    public class MatchingCalculatorControllerTest
    {

        private Mock<IMatchingCalculator> _matchingCalculator;
        private Mock<IRuleConfigurator> _ruleConfigurator;

        public MatchingCalculatorControllerTest()
        {
            var (p1, p2) = GetPersons();

            _ruleConfigurator = new Mock<IRuleConfigurator>();
            _ruleConfigurator.Setup(r => r.GetRules()).Returns(new System.Collections.Generic.List<IRule>());            
        }

        [Fact]
        public void MatchingController_Return_MatchingResult_When_Success()
        {
            //arrange
            var (p1, p2) = GetPersons();            
            MatchingRequest request = new MatchingRequest { Person1 = p1, Person2 = p2 };
            
            _matchingCalculator = new Mock<IMatchingCalculator>();
            _matchingCalculator.Setup(r => r.Calculate(p1, p2)).Returns(40);
            var controller = new MatchingCalculatorController(_matchingCalculator.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.Matching(request);

            // Assert
            Assert.Equal(40, result.Result);
            Assert.Equal(p1, result.Person1);
            Assert.Equal(p2, result.Person2);
        }

        [Fact]
        public void MatchingController_NoMatchingValue_When_Person_Null()
        {
            //arrange
            MatchingRequest request = new MatchingRequest { Person1 = null , Person2 = null};

            _matchingCalculator = new Mock<IMatchingCalculator>();
            var controller = new MatchingCalculatorController(_matchingCalculator.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.Matching(request);

            // Assert
            Assert.Equal(0, result.Result);
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
