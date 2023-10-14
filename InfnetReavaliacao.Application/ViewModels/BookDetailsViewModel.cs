using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Application.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel(int id, string title, string description, DateTime createdAt, string authorName)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            AuthorName = authorName;
            Description = description;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string AuthorName { get; private set; }
    }
}
