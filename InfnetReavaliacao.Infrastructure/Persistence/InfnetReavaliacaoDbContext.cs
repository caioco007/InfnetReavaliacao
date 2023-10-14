using InfnetReavaliacao.Core.Entities;

namespace InfnetReavaliacao.Infrastructure.Persistence
{
    public class InfnetReavaliacaoDbContext
    {
        public InfnetReavaliacaoDbContext() 
        {
            Books = new List<Book>
            {
                new Book(1, "Meu projeto ASPNET Core 1", "Minha descrição do Projeto 1", 1),
                new Book(2, "Meu projeto ASPNET Core 2", "Minha descrição do Projeto 2", 3),
                new Book(3, "Meu projeto ASPNET Core 3", "Minha descrição do Projeto 3", 2),
            };

            Authors = new List<Author>
            {
                new Author(1, "Caio Vitor", new DateTime(2001, 10, 11), "Brasil"),
                new Author(2, "Fabio", new DateTime(1966, 11, 03), "Africa"),
                new Author(3, "Solange", new DateTime(1975, 05, 01), "Russia"),
            };
        }

        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }
    }
}
