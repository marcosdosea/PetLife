using System;
using System.Collections.Generic;

namespace Core;

public partial class Produtovendum
{
    public uint IdProduto { get; set; }

    public uint IdVenda { get; set; }

    public double Quantidade { get; set; }

    public double Valor { get; set; }

    public virtual Produto IdProdutoNavigation { get; set; } = null!;

    public virtual Vendum IdVendaNavigation { get; set; } = null!;
}
