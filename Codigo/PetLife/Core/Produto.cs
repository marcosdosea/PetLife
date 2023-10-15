using System;
using System.Collections.Generic;

namespace Core;

public partial class Produto
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public uint Codigo { get; set; }

    public sbyte Ativo { get; set; }

    public uint Quantidade { get; set; }

    public string? Descricao { get; set; }

    public double Preco { get; set; }

    public uint IdPetshop { get; set; }

    public virtual Petshop IdPetshopNavigation { get; set; } = null!;

    public virtual ICollection<Produtovendum> Produtovenda { get; set; } = new List<Produtovendum>();
}
