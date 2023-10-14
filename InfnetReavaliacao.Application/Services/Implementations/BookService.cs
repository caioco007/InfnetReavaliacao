using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.Services.Interfaces;
using InfnetReavaliacao.Application.ViewModels;
using InfnetReavaliacao.Core.Entities;
using InfnetReavaliacao.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly InfnetReavaliacaoDbContext _dbContext;
        public BookService(InfnetReavaliacaoDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public int Create(NewBookInputModel inputModel)
        {
            var book = new Book(inputModel.Title, inputModel.Description, inputModel.IdAuthor);

            _dbContext.Books.Add(book);

            return book.Id;
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

            book.Cancel();
        }

        public List<BookViewModel> GetAll(string query)
        {
            var books = _dbContext.Books;

            var booksViewModel = books.Select(b => new BookViewModel(b.Id, b.Title, b.CreatedAt)).ToList();

            return booksViewModel;
        }

        public BookDetailsViewModel GetById(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);
            if (book == null) return null;
            
            var author = _dbContext.Authors.SingleOrDefault(a => a.Id == book.IdAuthor);
            if (author == null) return null;

            var booksDetailsViewModel = new BookDetailsViewModel(
                book.Id,
                book.Title,
                book.Description,
                book.CreatedAt,
                author.FullName
                );

            return booksDetailsViewModel;
        }

        public void Update(UpdateBookInputModel inputModel)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == inputModel.Id);

            book.Update(inputModel.Title, inputModel.Description);
        }
    }
}
