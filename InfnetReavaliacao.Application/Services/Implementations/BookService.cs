using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.Services.Interfaces;
using InfnetReavaliacao.Application.ViewModels;
using InfnetReavaliacao.Core.Entities;
using InfnetReavaliacao.Core.Repositories;
using InfnetReavaliacao.Infrastructure.Persistence;
using InfnetReavaliacao.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace InfnetReavaliacao.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }

        public int Create(NewBookInputModel inputModel)
        {
            var idBook = _bookRepository.GeneratedId();
            var book = new Book(idBook, inputModel.Title, inputModel.Description, inputModel.IdAuthor);

            _bookRepository.Create(book);

            return book.Id;
        }

        public void Delete(int id)
        {
            var book = _bookRepository.GetById(id);

            book.Cancel();
        }

        public List<BookViewModel> GetAll()
        {
            var books = _bookRepository.GetAll();

            var booksViewModel = books.Where(b => !b.IsDeleted).Select(b => new BookViewModel(b.Id, b.Title, b.CreatedAt)).ToList();

            return booksViewModel;
        }

        public BookViewModel GetById(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null) return null;

            var booksViewModel = new BookViewModel(book.Id, book.Title, book.CreatedAt);

            return booksViewModel;
        }

        public BookDetailsViewModel GetDetailsById(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null) return null;

            var booksDetailsViewModel = new BookDetailsViewModel(
                book.Id,
                book.Title,
                book.Description,
                book.CreatedAt,
                book.IdAuthor
                );

            return booksDetailsViewModel;
        }

        public void Update(UpdateBookInputModel inputModel)
        {
            var book = _bookRepository.GetById(inputModel.Id);

            book.Update(inputModel.Title, inputModel.Description);
        }
    }
}
