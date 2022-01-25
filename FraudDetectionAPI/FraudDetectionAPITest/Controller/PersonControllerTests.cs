using FraudDetectionAPI.Controllers;
using FraudDetectionAPI.Model;
using FraudDetectionAPI.Rules;
using FraudDetectionAPI.Service;
using FraudDetectionAPI.TableStorage;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace FraudDetectionAPITest.Controller
{
    public class PersonControlerTests
    {

        private Mock<IPersonEntityService> _personEntityService;

        [Fact]
        public void PutAsync_Return_Person_When_Success()
        {
            //arrange
            Person p1 = new Person()
            {
                FirstName = "Laura",
                LastName = "Guerrero",
                IdentificationNumber = "123456",
                DateOfBirth = "09/08/2000"
            };

            var pEntity = PersonEntity.Map(p1);
            
            _personEntityService = new Mock<IPersonEntityService>();
            _personEntityService.Setup(r => r.InsertOrMergeAsync(pEntity)).Returns(Task.FromResult(pEntity));
            var controller = new PersonController(_personEntityService.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.PutAsync(p1);

            // Assert
            Assert.True(result.IsCompletedSuccessfully);
        }       

    }
}
