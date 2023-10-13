using System;
using System.Collections.Generic;

namespace Core;

public partial class Vacina
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Periodo { get; set; }

    public virtual ICollection<Petvacina> Petvacinas { get; set; } = new List<Petvacina>();
}
