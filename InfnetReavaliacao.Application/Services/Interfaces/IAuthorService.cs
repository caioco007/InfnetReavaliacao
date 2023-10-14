using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Application.Services.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorViewModel> GetAll(string query);
        AuthorDetailsViewModel GetById(int id);
        int Create(NewAuthorInputModel inputModel);
        void Update(UpdateAuthorInputModel inputModel);
        void Delete(int id);
    }
}
