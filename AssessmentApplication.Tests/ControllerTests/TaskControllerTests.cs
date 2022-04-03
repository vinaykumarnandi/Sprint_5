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
    public class TaskControllerTests
    {
        private readonly UserTask _userTask;
        private readonly UserTaskController _taskController;
        private readonly Mock<IUserTaskRepository> _userTaskRepoMock;

        public TaskControllerTests()
        {
            _userTask = new UserTask()
            {
                Id = 1,
                AssignedToUserId = 1,
                Status = 1,
                Detail = "Task 1",
                ProjectId = 1,
                CreatedOn = System.DateTime.Now
            };

            _userTaskRepoMock = new Mock<IUserTaskRepository>();
            _taskController = new UserTaskController(_userTaskRepoMock.Object)
            {
                ControllerContext = new ControllerContext()
            };
            _taskController.ControllerContext.HttpContext = new DefaultHttpContext();
            _taskController.ControllerContext.HttpContext.Request.Headers["Id"] = "1";
        }

        [Fact]
        public void CreateTest()
        {
            _userTaskRepoMock.Setup(x => x.Add(It.IsAny<UserTask>())).Returns(true);
            var data = _taskController.Create(_userTask);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateTest()
        {
            _userTaskRepoMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<UserTask>())).Returns(true);
            var data = _taskController.Update(1, _userTask);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetAllTest()
        {
            var tasks = new List<UserTask>()
            {
                _userTask
            };
            _userTaskRepoMock.Setup(x => x.GetAll()).Returns(tasks);
            var data = _taskController.GetAll();
            var result = data.ToList();

            Assert.Equal(tasks, result);
        }

        [Fact]
        public void GetByIdTest()
        {
            _userTaskRepoMock.Setup(x => x.GetById(1)).Returns(_userTask);
            var data = _taskController.GetById(1);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }
    }
}
