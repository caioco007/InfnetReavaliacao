using InfnetReavaliacao.API.Controllers;
using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.Services.Interfaces;
using InfnetReavaliacao.Application.ViewModels;
using InfnetReavaliacao.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.UnitTestes.API.Controllers
{
    public class AuthorsControllerTests
    {
        [Fact]
        public void Get_ReturnsOkResultWithAuthors()
        {
            // Arrange
            var authorServiceMock = new Mock<IAuthorService>();
            var controller = new AuthorsController(authorServiceMock.Object);
            var authorsViewModel = new List<AuthorViewModel>
            {
                new AuthorViewModel (1, "Author 1", "China"),
                new AuthorViewModel (2, "Author 2", "Japão")
            };
            authorServiceMock.Setup(service => service.GetAll()).Returns(authorsViewModel);

            // Act
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<AuthorViewModel>>(okResult.Value);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void GetById_ReturnsOkResultWithAuthor()
        {
            // Arrange
            var authorServiceMock = new Mock<IAuthorService>();
            var controller = new AuthorsController(authorServiceMock.Object);
            var authorDetailsViewModel = new AuthorDetailsViewModel(1, "Author 1", new DateTime(1968, 8, 16), "Paraguaí", 5);
            authorServiceMock.Setup(service => service.GetById(1)).Returns(authorDetailsViewModel);

            // Act
            var result = controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<AuthorDetailsViewModel>(okResult.Value);
            Assert.Equal(1, model.Id);
            Assert.Equal("Author 1", model.FullName);
        }

        [Fact]
        public void Post_WithValidModel_ReturnsCreatedAtAction()
        {
            // Arrange
            var authorServiceMock = new Mock<IAuthorService>();
            var controller = new AuthorsController(authorServiceMock.Object);
            var inputModel = new NewAuthorInputModel { FullName = "Valid Author", BirthDate = new DateTime(2000, 10, 12), Country = "Jamaica" };
            authorServiceMock.Setup(service => service.Create(inputModel)).Returns(1);

            // Act
            var result = controller.Post(inputModel);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetById", createdAtActionResult.ActionName);
            var routeValues = Assert.IsType<Microsoft.AspNetCore.Routing.RouteValueDictionary>(createdAtActionResult.RouteValues);
            Assert.Equal(1, routeValues["id"]);
        }

        [Fact]
        public void Put_WithValidModel_ReturnsNoContent()
        {
            // Arrange
            var authorServiceMock = new Mock<IAuthorService>();
            var controller = new AuthorsController(authorServiceMock.Object);
            var inputModel = new UpdateAuthorInputModel { Id = 1, FullName = "Valid Author", BirthDate = new DateTime(2000, 10, 12), Country = "Inglaterra" };

            // Act
            var result = controller.Put(1, inputModel);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent()
        {
            // Arrange
            var authorServiceMock = new Mock<IAuthorService>();
            var controller = new AuthorsController(authorServiceMock.Object);

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
