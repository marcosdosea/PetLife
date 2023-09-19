using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PessoaDTO
    {
        public uint Id { get; set; }
        public string Nome { get; set; } = null!;

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public string Cidade { get; set; } = null!;

        public string? Rua { get; set; }

        public string? Numero { get; set; }

        public int? Cep { get; set; }
    }
}
