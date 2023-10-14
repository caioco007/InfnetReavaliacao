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

namespace InfnetReavaliacao.Application.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public int Create(NewAuthorInputModel inputModel)
        {
            var idAuthor = _authorRepository.GeneratedId();
            var author = new Author(idAuthor, inputModel.FullName, inputModel.BirthDate, inputModel.Country);

            _authorRepository.Create(author);

            return author.Id;
        }

        public void Delete(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null) return;

            var bookCount = _authorRepository.CountBooksById(author.Id);
            if (bookCount > 0) return;

            author.Cancel();
        }

        public List<AuthorViewModel> GetAll()
        {
            var authors = _authorRepository.GetAll();

            var authorsViewModel = authors.Where(a => !a.IsDeleted).Select(a => new AuthorViewModel(a.Id, a.FullName, a.Country)).ToList();

            return authorsViewModel;
        }

        public AuthorDetailsViewModel GetById(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null) return null;

            var booksCount = _authorRepository.CountBooksById(author.Id);

            var authorsDetailsViewModel = new AuthorDetailsViewModel(
                author.Id,
                author.FullName,
                author.BirthDate,
                author.Country,
                booksCount
                );

            return authorsDetailsViewModel;
        }

        public void Update(UpdateAuthorInputModel inputModel)
        {
            var author = _authorRepository.GetById(inputModel.Id);

            author.Update(inputModel.FullName, inputModel.BirthDate, inputModel.Country);
        }
    }
}
