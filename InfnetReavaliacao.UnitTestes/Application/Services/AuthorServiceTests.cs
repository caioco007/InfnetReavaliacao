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

namespace InfnetReavaliacao.UnitTestes.Application.Services
{
    public class AuthorServiceTests
    {
        [Fact]
        public void Create_Method_Returns_AuthorId()
        {
            // Arrange
            var authorRepository = new Mock<IAuthorRepository>();
            var authorService = new AuthorService(authorRepository.Object);
            var inputModel = new NewAuthorInputModel
            {
                FullName = "Sample FullName",
                BirthDate = new DateTime(2000, 10, 12),
                Country = "Suécia"
            };
            var generatedId = 1;

            authorRepository.Setup(repo => repo.GeneratedId()).Returns(generatedId);

            // Act
            var result = authorService.Create(inputModel);

            // Assert
            Assert.Equal(generatedId, result);
            authorRepository.Verify(repo => repo.Create(It.IsAny<Author>()), Times.Once);
        }

        [Fact]
        public void GetAll_Method_Returns_NonDeleted_Authors()
        {
            // Arrange
            var authorRepository = new Mock<IAuthorRepository>();
            var authorService = new AuthorService(authorRepository.Object);
            var authors = new List<Author>
            {
                new Author(1, "Author 1", new DateTime(1960, 12, 14), "Suíça"),
                new Author(2, "Author 2", new DateTime(1950, 11, 13), "França"),
                new Author(3, "Author 3", new DateTime(1940, 10, 12), "Nigéria"),
            };
            authorRepository.Setup(repo => repo.GetAll()).Returns(authors);

            // Act
            var result = authorService.GetAll();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetById_Method_Returns_AuthorViewModel()
        {
            // Arrange
            var authorRepository = new Mock<IAuthorRepository>();
            var authorService = new AuthorService(authorRepository.Object);
            var authorId = 1;
            var author = new Author(authorId, "Sample FullName", new DateTime(2000, 12, 12), "China");
            authorRepository.Setup(repo => repo.GetById(authorId)).Returns(author);

            // Act
            var result = authorService.GetById(authorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(authorId, result.Id);
            authorRepository.Verify(repo => repo.GetById(authorId), Times.Once);
        }

        [Fact]
        public void Delete_Method_Calls_Cancel_OnAuthor()
        {
            // Arrange
            var authorRepository = new Mock<IAuthorRepository>();
            var authorService = new AuthorService(authorRepository.Object);
            var authorId = 1;
            var author = new Author(authorId, "Sample FullName", new DateTime(2000, 10, 12), "Argentina");
            authorRepository.Setup(repo => repo.GetById(authorId)).Returns(author);

            // Act
            authorService.Delete(authorId);

            // Assert
            authorRepository.Verify(repo => repo.GetById(authorId), Times.Once);
            Assert.True(author.IsDeleted);
        }

        [Fact]
        public void Update_Method_Calls_Update_OnAuthor()
        {
            // Arrange
            var authorRepository = new Mock<IAuthorRepository>();
            var authorService = new AuthorService(authorRepository.Object);
            var authorId = 1;
            var author = new Author(authorId, "Sample FullName", new DateTime(2000, 10, 12), "Uruguai");
            var inputModel = new UpdateAuthorInputModel
            {
                Id = authorId,
                FullName = "New FullName",
                BirthDate= new DateTime(1998, 03, 17),
                Country = "Japão"
            };

            authorRepository.Setup(repo => repo.GetById(authorId)).Returns(author);

            // Act
            authorService.Update(inputModel);

            // Assert
            authorRepository.Verify(repo => repo.GetById(authorId), Times.Once);
            Assert.Equal(inputModel.FullName, author.FullName);
            Assert.Equal(inputModel.BirthDate, author.BirthDate);
            Assert.Equal(inputModel.Country, author.Country);
        }
    }
}
