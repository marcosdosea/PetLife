using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ConsultumDTO
    {
        public DateTime DataAgendamento { get; set; }

        public DateTime DataConsulta { get; set; }

        public string Status { get; set; }
        public string NomeCliente { get; set; }

        public string NomePet { get; set; }

        public string Descricao { get; set; } = null!;
    }
}
