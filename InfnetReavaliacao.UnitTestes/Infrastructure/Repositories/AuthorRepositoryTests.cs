using InfnetReavaliacao.Core.Entities;
using InfnetReavaliacao.Infrastructure.Persistence.Repositories;
using InfnetReavaliacao.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.UnitTestes.Infrastructure.Repositories
{
    public class AuthorRepositoryTests
    {
        [Fact]
        public void Create_AddsAuthorToDatabase()
        {
            // Arrange
            var dbContext = new InfnetReavaliacaoDbContext();
            var repository = new AuthorRepository(dbContext);
            var author = new Author(3, "Test Author", new DateTime(1980, 5, 15), "Sérvia");

            // Act
            repository.Create(author);

            // Assert
            var addedAuthor = dbContext.Authors.Single(a => a.FullName == "Test Author");
            Assert.NotNull(addedAuthor);
        }

        [Fact]
        public void GetAll_ReturnsAllAuthors()
        {
            // Arrange
            var dbContext = new InfnetReavaliacaoDbContext();
            var repository = new AuthorRepository(dbContext);

            // Act
            var authors = repository.GetAll();

            // Assert
            Assert.Equal(3, authors.Count);
        }

        [Fact]
        public void GetById_ReturnsAuthorById()
        {
            // Arrange
            var dbContext = new InfnetReavaliacaoDbContext();
            var repository = new AuthorRepository(dbContext);

            // Act
            var author = repository.GetById(1);

            // Assert
            Assert.NotNull(author);
            Assert.Equal(1, author.Id);
        }

        [Fact]
        public void CountBooksById_ReturnsBookCountForAuthor()
        {
            // Arrange
            var dbContext = new InfnetReavaliacaoDbContext();
            var repository = new AuthorRepository(dbContext);

            // Act
            var bookCount = repository.CountBooksById(1);

            // Assert
            Assert.Equal(1, bookCount);
        }

        [Fact]
        public void GeneratedId_ReturnsNextAvailableId()
        {
            // Arrange
            var dbContext = new InfnetReavaliacaoDbContext();
            var repository = new AuthorRepository(dbContext);

            // Act
            var nextId = repository.GeneratedId();

            // Assert
            Assert.Equal(4, nextId);
        }
    }
}
