using InfnetReavaliacao.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Application.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel(int id, string title, string description, DateTime createdAt, int idAuthor)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            IdAuthor = idAuthor;
            Description = description;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int IdAuthor { get; private set; }
    }
}
