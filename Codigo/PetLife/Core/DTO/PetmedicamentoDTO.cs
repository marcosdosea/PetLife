using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PetmedicamentoDTO
    {
        public uint IdPet { get; set; }

        public uint IdMedicamento { get; set; }

        public uint Dosagem { get; set; }

        public string Medida { get; set; } = null!;
    }
}
