using InfnetReavaliacao.Core.Entities;
using InfnetReavaliacao.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Infrastructure.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly InfnetReavaliacaoDbContext _dbContext;
        public AuthorRepository(InfnetReavaliacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Author author)
        {
            _dbContext.Authors.Add(author);

            return author.Id;
        }

        public List<Author> GetAll() => _dbContext.Authors.ToList();

        public Author GetById(int id) => _dbContext.Authors.SingleOrDefault(b => b.Id == id);

        public int CountBooksById(int id)
        {
            var author = _dbContext.Authors.SingleOrDefault(a => a.Id == id);
            if (author == null) return 0;

            var booksCount = _dbContext.Books.Count(b => b.IdAuthor == author.Id && !b.IsDeleted);
            return booksCount;
        }

        public int GeneratedId()
        {
            var author = _dbContext.Authors.OrderByDescending(b => b.Id).FirstOrDefault();
            return author == null ? 1 : (author.Id + 1);
        }
    }
}
