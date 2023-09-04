using System;
using System.Collections.Generic;

namespace Core;

public partial class Petshop
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Cnpj { get; set; }

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual ICollection<Petshoppessoa> Petshoppessoas { get; set; } = new List<Petshoppessoa>();

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
