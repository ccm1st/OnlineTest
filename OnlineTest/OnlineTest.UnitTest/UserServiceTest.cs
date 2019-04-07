using OnlineTest.Implementation.Service;
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
            UserService sut = new UserService();

            // act
            var result = sut.GetUser();

            // assert
            Assert.Equal("test", result.Name);
        }
    }
}
