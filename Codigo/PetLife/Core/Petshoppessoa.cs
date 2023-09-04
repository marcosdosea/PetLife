using System;
using System.Collections.Generic;

namespace Core;

public partial class Petshoppessoa
{
    public uint IdPetshop { get; set; }

    public uint IdPessoa { get; set; }

    public string Papel { get; set; } = null!;

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;

    public virtual Petshop IdPetshopNavigation { get; set; } = null!;
}
