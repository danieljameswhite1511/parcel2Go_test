using NUnit;
using Moq;
using NUnit.Framework;

namespace Tests.Parcel2Go_NUnit_UnitTests.API.Controllers
{
    [TestFixture]   
    public class QuotesController_Tests
    {
        
        [Test]
        public void GetQutoesByWeight_WeightIsZero_ReturnBadRequest(){
            //Arrange
            //Act
            //Assert

        }

        [Test]
        public void GetQutoesByWeight_QuotesListIsNull_ReturnNotFound(){
            //Arrange
            //Act
            //Assert
            
        }

        [Test]
        public void GetQutoesByWeight_QuotesListIsNotNull_ReturnOk(){
            //Arrange
            //Act
            //Assert
            
        }
        
    }
}