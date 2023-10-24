using InfnetReavaliacao.API.Controllers;
using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.Services.Interfaces;
using InfnetReavaliacao.Application.ViewModels;
using InfnetReavaliacao.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.UnitTestes.API.Controllers
{
    public class BooksControllerTests
    {
        [Fact]
        public void Get_ReturnsOkResultWithBooks()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var controller = new BooksController(bookServiceMock.Object);
            var booksViewModel = new List<BookViewModel>
        {
            new BookViewModel (1, "Book 1", DateTime.Now),
            new BookViewModel (2, "Book 2", DateTime.Now)
        };
            bookServiceMock.Setup(service => service.GetAll()).Returns(booksViewModel);

            // Act
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<BookViewModel>>(okResult.Value);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void GetById_ReturnsOkResultWithBook()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var controller = new BooksController(bookServiceMock.Object);
            var bookViewModel = new BookViewModel(1, "Book 1", DateTime.Now);
            bookServiceMock.Setup(service => service.GetById(1)).Returns(bookViewModel);

            // Act
            var result = controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<BookViewModel>(okResult.Value);
            Assert.Equal(1, model.Id);
            Assert.Equal("Book 1", model.Title);
        }

        [Fact]
        public void Post_WithValidModel_ReturnsCreatedAtAction()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var controller = new BooksController(bookServiceMock.Object);
            var inputModel = new NewBookInputModel { Title = "Valid Book", Description = "Description" };
            bookServiceMock.Setup(service => service.Create(inputModel)).Returns(1);

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
            var bookServiceMock = new Mock<IBookService>();
            var controller = new BooksController(bookServiceMock.Object);
            var inputModel = new UpdateBookInputModel { Id = 1, Title = "Valid Book", Description = "Description" };

            // Act
            var result = controller.Put(1, inputModel);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var controller = new BooksController(bookServiceMock.Object);

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
