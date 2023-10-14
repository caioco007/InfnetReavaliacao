using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Application.InputModels
{
    public class NewBookInputModel
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdAuthor { get; private set; }
    }
}
