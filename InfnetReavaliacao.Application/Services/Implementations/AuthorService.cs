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
    public class AuthorService : IAuthorService
    {
        private readonly InfnetReavaliacaoDbContext _dbContext;
        public AuthorService(InfnetReavaliacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewAuthorInputModel inputModel)
        {
            var author = new Author(inputModel.FullName, inputModel.BirthDate, inputModel.Country);

            _dbContext.Authors.Add(author);

            return author.Id;
        }

        public void Delete(int id)
        {
            var bookCount = _dbContext.Books.Count(b => b.IdAuthor == id);

            if (bookCount > 0) return;

            var author = _dbContext.Authors.SingleOrDefault(a => a.Id == id);

            author.Cancel();
        }

        public List<AuthorViewModel> GetAll(string query)
        {
            var authors = _dbContext.Authors;

            var authorsViewModel = authors.Select(a => new AuthorViewModel(a.Id, a.FullName, a.Country)).ToList();

            return authorsViewModel;
        }

        public AuthorDetailsViewModel GetById(int id)
        {

            var author = _dbContext.Authors.SingleOrDefault(a => a.Id == id);
            if (author == null) return null;

            var booksCount = _dbContext.Books.Count(b => b.IdAuthor == author.Id);

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
            var author = _dbContext.Authors.SingleOrDefault(b => b.Id == inputModel.Id);

            author.Update(inputModel.FullName, inputModel.BirthDate, inputModel.Country);
        }
    }
}
