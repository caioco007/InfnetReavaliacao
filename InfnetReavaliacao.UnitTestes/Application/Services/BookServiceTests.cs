using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.Services.Implementations;
using InfnetReavaliacao.Core.Entities;
using InfnetReavaliacao.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace InfnetReavaliacao.UnitTestes.Application.Services
{
    public class BookServiceTests
    {
        [Fact]
        public void Create_Method_Returns_BookId()
        {
            // Arrange
            var bookRepository = new Mock<IBookRepository>();
            var bookService = new BookService(bookRepository.Object);
            var inputModel = new NewBookInputModel
            {
                Title = "Sample Title",
                Description = "Sample Description",
                IdAuthor = 1
            };
            var generatedId = 1;

            bookRepository.Setup(repo => repo.GeneratedId()).Returns(generatedId);

            // Act
            var result = bookService.Create(inputModel);

            // Assert
            Assert.Equal(generatedId, result);
            bookRepository.Verify(repo => repo.Create(It.IsAny<Book>()), Times.Once);
        }

        [Fact]
        public void GetAll_Method_Returns_NonDeleted_Books()
        {
            // Arrange
            var bookRepository = new Mock<IBookRepository>();
            var bookService = new BookService(bookRepository.Object);
            var books = new List<Book>
            {
                new Book(1, "Book 1", "Description 1", 1),
                new Book(2, "Book 2", "Description 2", 2),
                new Book(3, "Book 3", "Description 3", 1),
            };
            bookRepository.Setup(repo => repo.GetAll()).Returns(books);

            // Act
            var result = bookService.GetAll();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetById_Method_Returns_BookViewModel()
        {
            // Arrange
            var bookRepository = new Mock<IBookRepository>();
            var bookService = new BookService(bookRepository.Object);
            var bookId = 1;
            var book = new Book(bookId, "Sample Title", "Sample Description", 2);
            bookRepository.Setup(repo => repo.GetById(bookId)).Returns(book);

            // Act
            var result = bookService.GetById(bookId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bookId, result.Id);
            bookRepository.Verify(repo => repo.GetById(bookId), Times.Once);
        }

        [Fact]
        public void Delete_Method_Calls_Cancel_OnBook()
        {
            // Arrange
            var bookRepository = new Mock<IBookRepository>();
            var bookService = new BookService(bookRepository.Object);
            var bookId = 1;
            var book = new Book(bookId, "Sample Title", "Sample Description", 2);
            bookRepository.Setup(repo => repo.GetById(bookId)).Returns(book);

            // Act
            bookService.Delete(bookId);

            // Assert
            bookRepository.Verify(repo => repo.GetById(bookId), Times.Once);
            Assert.True(book.IsDeleted);
        }

        [Fact]
        public void Update_Method_Calls_Update_OnBook()
        {
            // Arrange
            var bookRepository = new Mock<IBookRepository>();
            var bookService = new BookService(bookRepository.Object);
            var bookId = 1;
            var book = new Book(bookId, "Sample Title", "Sample Description", 3);
            var inputModel = new UpdateBookInputModel
            {
                Id = bookId,
                Title = "New Title",
                Description = "New Description"
            };

            bookRepository.Setup(repo => repo.GetById(bookId)).Returns(book);

            // Act
            bookService.Update(inputModel);

            // Assert
            bookRepository.Verify(repo => repo.GetById(bookId), Times.Once);
            Assert.Equal(inputModel.Title, book.Title);
            Assert.Equal(inputModel.Description, book.Description);
        }
    }
}
