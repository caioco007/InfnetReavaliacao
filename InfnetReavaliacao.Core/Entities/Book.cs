using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string description, int idAuthor)
        {
            Title = title;
            Description = description;
            IdAuthor = idAuthor;
            CreatedAt = DateTime.Now;

            IsDeleted = false;
        }

        public void Cancel()
        {
            IsDeleted = true;
        }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public int IdAuthor { get; private set; }
        public Author AuthorOfTheBook { get; private set; }
    }
}
