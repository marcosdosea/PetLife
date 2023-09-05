using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PetDTO
    {
        public string Nome { get; set; } = null!;
        public string Especie { get; set; } = null!;
        public string Raca { get; set; } = null!;
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; } = null!;
        public double Peso { get; set; }
    }
}
