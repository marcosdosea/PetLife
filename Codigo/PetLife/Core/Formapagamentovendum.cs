using System;
using System.Collections.Generic;

namespace Core;

public partial class Formapagamentovendum
{
    public uint IdFormaPagamento { get; set; }

    public uint IdVenda { get; set; }

    public double Valor { get; set; }

    public virtual Formapagamento IdFormaPagamentoNavigation { get; set; } = null!;

    public virtual Vendum IdVendaNavigation { get; set; } = null!;
}
