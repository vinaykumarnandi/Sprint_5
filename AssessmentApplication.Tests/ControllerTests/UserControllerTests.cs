using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AssessmentApplication.Models;
using AssessmentApplication.Controllers;
using AssessmentApplication.Repository;

namespace AssessmentApplication.Tests.ControllerTests
{
    public class UserControllerTest
    {
        private readonly User _user;
        private readonly UserController _userController;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserControllerTest()
        {
            _user = new User()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test2",
                Email = "test1@test.com",
                Password = "Password1"
            };
            _userRepositoryMock = new Mock<IUserRepository>();
            _userController = new UserController(_userRepositoryMock.Object)
            {
                ControllerContext = new ControllerContext()
            };
            _userController.ControllerContext.HttpContext = new DefaultHttpContext();
            _userController.ControllerContext.HttpContext.Request.Headers["Id"] = "1";
        }

        [Fact]
        public void CreateTest()
        {
            _userRepositoryMock.Setup(x => x.Add(It.IsAny<User>())).Returns(true);
            var data = _userController.Create(_user);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateTest()
        {
            _userRepositoryMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<User>())).Returns(true);
            var data = _userController.Update(1, _user);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetAllTest()
        {
            var users = new List<User>()
            {
                _user
            };
            _userRepositoryMock.Setup(x => x.GetAll()).Returns(users);
            var data = _userController.GetAll();
            var result = data.ToList();

            Assert.Equal(users, result);
        }

        [Fact]
        public void GetByIdTest()
        {
            _userRepositoryMock.Setup(x => x.GetById(1)).Returns(_user);
            var data = _userController.GetById(1);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

    }
}
