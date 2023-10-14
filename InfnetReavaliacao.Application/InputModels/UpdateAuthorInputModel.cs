using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfnetReavaliacao.Application.InputModels
{
    public class UpdateAuthorInputModel
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Country { get; private set; }
    }
}
