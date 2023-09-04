using System;
using System.Collections.Generic;

namespace Core;

public partial class Pet
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Especie { get; set; } = null!;

    public string Raca { get; set; } = null!;

    public DateTime? DataNascimento { get; set; }

    public string Sexo { get; set; } = null!;

    public double Peso { get; set; }

    public uint IdTutor { get; set; }

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual Pessoa IdTutorNavigation { get; set; } = null!;

    public virtual ICollection<Petmedicamento> Petmedicamentos { get; set; } = new List<Petmedicamento>();

    public virtual ICollection<Petvacina> Petvacinas { get; set; } = new List<Petvacina>();
}
