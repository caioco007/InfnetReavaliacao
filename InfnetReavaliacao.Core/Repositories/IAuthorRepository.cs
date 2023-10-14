using InfnetReavaliacao.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Core.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author GetById(int id);
        int Create(Author author);
        int CountBooksById(int id);
        int GeneratedId();
    }
}
