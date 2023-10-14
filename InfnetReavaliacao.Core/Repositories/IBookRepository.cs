using InfnetReavaliacao.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Core.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int id);
        int Create(Book book);
        int GeneratedId();
    }
}
