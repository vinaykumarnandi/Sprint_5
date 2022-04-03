using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using AssessmentApplication.Models;
using AssessmentApplication.Controllers;
using AssessmentApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AssessmentApplication.Tests.ControllerTests
{
    public class ProjectControllerTests
    {
        private readonly Project _project;
        private readonly ProjectController _projectController;
        private readonly Mock<IProjectRepository> _projectRepoMock;

        public ProjectControllerTests()
        {
            _project = new Project()
            {
                Id = 1,
                Name = "project 1",
                Detail = "This is a test Project",
                CreatedOn = DateTime.Now
            };

            _projectRepoMock = new Mock<IProjectRepository>();
            _projectController = new ProjectController(_projectRepoMock.Object)
            {
                ControllerContext = new ControllerContext()
            };
            _projectController.ControllerContext.HttpContext = new DefaultHttpContext();
            _projectController.ControllerContext.HttpContext.Request.Headers["Id"] = "1";
        }

        [Fact]
        public void AddTest()
        {
            _projectRepoMock.Setup(x => x.Add(It.IsAny<Project>())).Returns(true);
            var data = _projectController.Create(_project);
            var result = data as OkObjectResult;
            
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateTest()
        {
            _projectRepoMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Project>())).Returns(true);
            var data = _projectController.Update(1, _project);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetAllTest()
        {
            var projects = new List<Project>()
            {
                _project
            };
            _projectRepoMock.Setup(x => x.GetAll()).Returns(projects);
            var data = _projectController.GetAll();
            var result = data.ToList();

            Assert.Equal(projects, result);
        }

        [Fact]
        public void GetByIdTest()
        {
            _projectRepoMock.Setup(x => x.GetById(1)).Returns(_project);
            var data = _projectController.GetById(1);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }
    }
}
