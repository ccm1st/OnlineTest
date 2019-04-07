using OnlineTest.Service.Implementation;
using System;
using Xunit;

namespace OnlineTest.UnitTest
{
    public class UserServiceTest
    {
        [Fact]
        public void GetUser_GivenBeenCalled_ReturnTest()
        {
            // arrange
            string expectedName = "Jack Chen";
            UserService sut = new UserService();

            // act
            var result = sut.GetUser(expectedName);

            // assert
            Assert.Equal(expectedName, result.Name);
        }
    }
}
