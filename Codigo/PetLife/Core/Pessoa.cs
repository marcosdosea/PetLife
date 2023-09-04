using System;
using System.Collections.Generic;

namespace Core;

public partial class Pessoa
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string? Rua { get; set; }

    public string? Numero { get; set; }

    public int? Cep { get; set; }

    public virtual ICollection<Consultum> ConsultumIdAtendenteNavigations { get; set; } = new List<Consultum>();

    public virtual ICollection<Consultum> ConsultumIdClienteNavigations { get; set; } = new List<Consultum>();

    public virtual ICollection<Consultum> ConsultumIdVeterinarioNavigations { get; set; } = new List<Consultum>();

    public virtual ICollection<Petmedicamento> Petmedicamentos { get; set; } = new List<Petmedicamento>();

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

    public virtual ICollection<Petshoppessoa> Petshoppessoas { get; set; } = new List<Petshoppessoa>();

    public virtual ICollection<Petvacina> Petvacinas { get; set; } = new List<Petvacina>();

    public virtual ICollection<Vendum> VendumIdAtendenteNavigations { get; set; } = new List<Vendum>();

    public virtual ICollection<Vendum> VendumIdClienteNavigations { get; set; } = new List<Vendum>();
}
