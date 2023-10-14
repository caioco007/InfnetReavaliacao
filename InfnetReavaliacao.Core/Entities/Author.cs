using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Core.Entities
{
    public class Author : BaseEntity
    {
        public Author(string fullName, DateTime birthDate, string country)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Country = country;
            
            Books = new List<Book>(); 
            IsDeleted = false;
        }

        public void Cancel()
        {
            IsDeleted = true;
        }
        public void Update(string fullName, DateTime birthDate, string country)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Country = country;
        }

        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Country { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<Book> Books { get; private set; }
    }
}
