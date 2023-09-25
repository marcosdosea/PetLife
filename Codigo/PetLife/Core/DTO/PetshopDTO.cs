using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PetshopDTO
    {
        public uint Id { get; set; }

        public string Nome { get; set; } = null!;

        public string? Cnpj { get; set; }

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string Cidade { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public string Rua { get; set; } = null!;

        public string Numero { get; set; } = null!;

        public string Cep { get; set; } = null!;
    }
}
