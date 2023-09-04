using System;
using System.Collections.Generic;

namespace Core;

public partial class Formapagamento
{
    public uint Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Formapagamentovendum> Formapagamentovenda { get; set; } = new List<Formapagamentovendum>();
}
