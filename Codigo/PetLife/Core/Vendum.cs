using System;
using System.Collections.Generic;

namespace Core;

public partial class Vendum
{
    public uint Id { get; set; }

    public DateTime DataVenda { get; set; }

    public string FormaPagamento { get; set; } = null!;

    public uint? Parcelas { get; set; }

    public sbyte Pago { get; set; }

    public uint IdAtendente { get; set; }

    public uint IdCliente { get; set; }

    public virtual ICollection<Formapagamentovendum> Formapagamentovenda { get; set; } = new List<Formapagamentovendum>();

    public virtual Pessoa IdAtendenteNavigation { get; set; } = null!;

    public virtual Pessoa IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Produtovendum> Produtovenda { get; set; } = new List<Produtovendum>();
}
