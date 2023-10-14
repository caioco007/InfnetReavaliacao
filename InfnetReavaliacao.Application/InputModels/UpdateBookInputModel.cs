using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Application.InputModels
{
    public class UpdateBookInputModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
    }
}
