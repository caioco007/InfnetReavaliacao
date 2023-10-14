using InfnetReavaliacao.Core.Entities;
using InfnetReavaliacao.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly InfnetReavaliacaoDbContext _dbContext;
        public BookRepository(InfnetReavaliacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Book book)
        {
            _dbContext.Books.Add(book);

            return book.Id;
        }

        public List<Book> GetAll() => _dbContext.Books.ToList();

        public Book GetById(int id) => _dbContext.Books.SingleOrDefault(b => b.Id == id);

        public int GeneratedId()
        {
            var book = _dbContext.Books.OrderByDescending(b => b.Id).FirstOrDefault();
            return book == null ? 1 : (book.Id + 1) ;
        }
    }
}
