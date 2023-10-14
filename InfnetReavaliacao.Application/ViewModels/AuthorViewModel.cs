using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Application.ViewModels
{
    public class AuthorViewModel
    {
        public AuthorViewModel(int id, string fullName, string country)
        {
            Id = id;
            FullName = fullName;
            Country = country;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Country { get; private set; }
    }
}
