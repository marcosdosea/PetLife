using System;
using System.Collections.Generic;

namespace Core;

public partial class Consultum
{
    public uint Id { get; set; }
    public DateTime DataAgendamento { get; set; }
    public DateTime DataConsulta { get; set; }
    public string? Status { get; set; }
    public uint IdPetshop { get; set; }
    public uint IdAtendente { get; set; }
    public uint IdVeterinario { get; set; }
    public uint IdCliente { get; set; }
    public uint IdPet { get; set; }
    public string Descricao { get; set; } = null!;
    public double Preco { get; set; }
    public virtual Pessoa IdAtendenteNavigation { get; set; } = null!;
    public virtual Pessoa IdClienteNavigation { get; set; } = null!;
    public virtual Pet IdPetNavigation { get; set; } = null!;
    public virtual Petshop IdPetshopNavigation { get; set; } = null!;
    public virtual Pessoa IdVeterinarioNavigation { get; set; } = null!;
}
