using Moq;
using OnlineTest.Service.Domain;
using OnlineTest.Service.Implementation;
using OnlineTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineTest.Service.UnitTest
{
    public class TrolleySerivceTest
    {
        [Fact]
        public async Task Calculate_GivenATrolley_ReturnTrolleyTotal()
        {
            // arrange
            decimal expected = 20;
            Mock<ITrolleyAPI> mock = new Mock<ITrolleyAPI>();
            mock.Setup(a => a.Calculate(It.IsAny<string>(), It.IsAny<Trolley>())).ReturnsAsync(expected);
            var sut = new TrolleyService(mock.Object);

            // act
           var actual = await sut.CalculateTotal("test", new Trolley());

            // assert
            Assert.Equal(expected,  actual, 0);  
        }
    }
}
