using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Application.ViewModels
{
    public class AuthorDetailsViewModel
    {
        public AuthorDetailsViewModel(int id, string fullName, DateTime birthDate, string country, int totalBooks)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Country = country;
            TotalBooks = totalBooks;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Country { get; private set; }
        public int TotalBooks { get; private set; }
    }
}
