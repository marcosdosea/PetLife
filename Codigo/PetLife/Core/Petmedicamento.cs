using System;
using System.Collections.Generic;

namespace Core;

public partial class Petmedicamento
{
    public uint IdPet { get; set; }

    public uint IdMedicamento { get; set; }

    public uint Dosagem { get; set; }

    public string Medida { get; set; } = null!;

    public DateTime DataInicio { get; set; }

    public DateTime? DataTermino { get; set; }

    public int Frequencia { get; set; }

    public int Intervalo { get; set; }

    public uint? IdVeterinario { get; set; }

    public sbyte Ativo { get; set; }

    public virtual Medicamento IdMedicamentoNavigation { get; set; } = null!;

    public virtual Pet IdPetNavigation { get; set; } = null!;

    public virtual Pessoa? IdVeterinarioNavigation { get; set; }
}
