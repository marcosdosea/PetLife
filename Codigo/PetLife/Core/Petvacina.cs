using System;
using System.Collections.Generic;

namespace Core;

public partial class Petvacina
{
    public uint IdPet { get; set; }

    public uint IdVacina { get; set; }

    public DateTime DataAplicacao { get; set; }

    public uint? IdVeterinario { get; set; }

    public virtual Pet IdPetNavigation { get; set; } = null!;

    public virtual Vacina IdVacinaNavigation { get; set; } = null!;

    public virtual Pessoa? IdVeterinarioNavigation { get; set; }
}
