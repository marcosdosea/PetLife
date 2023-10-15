using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ProdutoDTO
    {
        public string Nome { get; set; } = null!;

        public uint Codigo { get; set; }

        public sbyte Ativo { get; set; }

        public uint Quantidade { get; set; }

        public string? Descricao { get; set; }

        public double Preco { get; set; }
    }
}
