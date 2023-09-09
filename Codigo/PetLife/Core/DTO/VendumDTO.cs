using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class VendumDTO
    {
        public uint Id { get; set; }

        public DateTime DataVenda { get; set; }

        public string FormaPagamento { get; set; } = null!;

        public sbyte Pago { get; set; }
    }
}
