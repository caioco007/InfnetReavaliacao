using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Application.Services.Interfaces
{
    public interface IBookService
    {
        List<BookViewModel> GetAll();
        BookViewModel GetById(int id);
        BookDetailsViewModel GetDetailsById(int id);
        int Create(NewBookInputModel inputModel);
        void Update(UpdateBookInputModel inputModel);
        void Delete(int id);

    }
}
