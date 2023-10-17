using FluentAssertions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDCustomers.API.Controllers;
using TDDCustomers.API.Services;
using Moq;
using TDDCustomers.API.Models;
using TDDCustomers.UnitTests.Fixtures;

namespace TDDCustomers.UnitTests.Systems.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_onSuccess_ReturnsStatusCode200() {
            //Arrange
            var mockUserService = new Mock<IUserSevice>();
            var sut = new UsersController(mockUserService.Object);
            mockUserService.Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());
            var result = (OkObjectResult)await sut.Get();
            //Assert
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task Get_onSuccess_InvokesUsersServiceExacltyOnce()
        {
            //Arrange
            var mockUserService = new Mock<IUserSevice>();
            var sut = new UsersController(mockUserService.Object);
            mockUserService.Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());

            //Act
            var result = await sut.Get();
            //Assert
            mockUserService.Verify(service => service.GetAllUsers(), Times.Once);
        }

        [Fact]
        public async Task Get_onSuccess_ReturnsListOfUsers()
        {
            //Arrange
            var mockUserService = new Mock<IUserSevice>();
            var sut = new UsersController(mockUserService.Object);
            mockUserService.Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());

            //Act
            var result = await sut.Get();
            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }
        [Fact]
        public async Task Get_onNoUsersFound_Returns404NotFound()
        {
            //Arrange
            var mockUserService = new Mock<IUserSevice>();
            var sut = new UsersController(mockUserService.Object);
            mockUserService.Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            //Act
            var result = await sut.Get();
            //Assert
            result.Should().BeOfType<NotFoundResult>();
           
        }

    }
}
