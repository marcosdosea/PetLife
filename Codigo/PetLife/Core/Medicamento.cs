using System;
using System.Collections.Generic;

namespace Core;

public partial class Medicamento
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Importado { get; set; }

    public string? Ativo { get; set; }

    public virtual ICollection<Petmedicamento> Petmedicamentos { get; set; } = new List<Petmedicamento>();
}
