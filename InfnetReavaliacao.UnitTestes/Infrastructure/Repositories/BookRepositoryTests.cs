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
    public class BookRepositoryTests
    {
        [Fact]
        public void Create_AddsBookToDatabase()
        {
            // Arrange
            var dbContext = new InfnetReavaliacaoDbContext();
            var repository = new BookRepository(dbContext);
            var book = new Book (1, "Test Book", "Description Book", 2 );

            // Act
            repository.Create(book);

            // Assert
            var addedBook = dbContext.Books.Single(b => b.Title == "Test Book");
            Assert.NotNull(addedBook);
        }

        [Fact]
        public void GetAll_ReturnsAllBooks()
        {
            // Arrange
            var dbContext = new InfnetReavaliacaoDbContext();
            var repository = new BookRepository(dbContext);

            // Act
            var books = repository.GetAll();

            // Assert
            Assert.Equal(3, books.Count);
        }

        [Fact]
        public void GetById_ReturnsBookById()
        {
            // Arrange
            var dbContext = new InfnetReavaliacaoDbContext();
            var repository = new BookRepository(dbContext);

            // Act
            var book = repository.GetById(1);

            // Assert
            Assert.NotNull(book);
            Assert.Equal(1, book.Id);
        }

        [Fact]
        public void GeneratedId_ReturnsNextAvailableId()
        {
            // Arrange
            var dbContext = new InfnetReavaliacaoDbContext();
            var repository = new BookRepository(dbContext);

            // Act
            var nextId = repository.GeneratedId();

            // Assert
            Assert.Equal(4, nextId);
        }
    }
}
