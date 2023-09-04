using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class PetLifeContext : DbContext
{
    public PetLifeContext()
    {
    }

    public PetLifeContext(DbContextOptions<PetLifeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consultum> Consulta { get; set; }

    public virtual DbSet<Formapagamento> Formapagamentos { get; set; }

    public virtual DbSet<Formapagamentovendum> Formapagamentovenda { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Petmedicamento> Petmedicamentos { get; set; }

    public virtual DbSet<Petshop> Petshops { get; set; }

    public virtual DbSet<Petshoppessoa> Petshoppessoas { get; set; }

    public virtual DbSet<Petvacina> Petvacinas { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Produtovendum> Produtovenda { get; set; }

    public virtual DbSet<Vacina> Vacinas { get; set; }

    public virtual DbSet<Vendum> Venda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
       // {
       //     #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //            => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=PetLife");
        //}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("consulta");

            entity.HasIndex(e => e.IdAtendente, "fk_Consulta_Pessoa1_idx");

            entity.HasIndex(e => e.IdVeterinario, "fk_Consulta_Pessoa2_idx");

            entity.HasIndex(e => e.IdCliente, "fk_Consulta_Pessoa3_idx");

            entity.HasIndex(e => e.IdPet, "fk_Consulta_Pet1_idx");

            entity.HasIndex(e => e.IdPetshop, "fk_Consulta_Petshop1_idx");

            entity.HasIndex(e => e.Id, "idConsulta_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.DataAgendamento).HasColumnType("datetime");
            entity.Property(e => e.DataConsulta).HasColumnType("datetime");
            entity.Property(e => e.Descricao)
                .HasMaxLength(1000)
                .HasColumnName("descricao");
            entity.Property(e => e.IdAtendente)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idAtendente");
            entity.Property(e => e.IdCliente)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idCliente");
            entity.Property(e => e.IdPet)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idPet");
            entity.Property(e => e.IdPetshop)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idPetshop");
            entity.Property(e => e.IdVeterinario)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idVeterinario");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'A'")
                .HasColumnType("enum('A','R','C')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdAtendenteNavigation).WithMany(p => p.ConsultumIdAtendenteNavigations)
                .HasForeignKey(d => d.IdAtendente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Consulta_Pessoa1");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ConsultumIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Consulta_Pessoa3");

            entity.HasOne(d => d.IdPetNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPet)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Consulta_Pet1");

            entity.HasOne(d => d.IdPetshopNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPetshop)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Consulta_Petshop1");

            entity.HasOne(d => d.IdVeterinarioNavigation).WithMany(p => p.ConsultumIdVeterinarioNavigations)
                .HasForeignKey(d => d.IdVeterinario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Consulta_Pessoa2");
        });

        modelBuilder.Entity<Formapagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("formapagamento");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .HasColumnName("descricao");
        });

        modelBuilder.Entity<Formapagamentovendum>(entity =>
        {
            entity.HasKey(e => new { e.IdFormaPagamento, e.IdVenda }).HasName("PRIMARY");

            entity.ToTable("formapagamentovenda");

            entity.HasIndex(e => e.IdFormaPagamento, "fk_FormaPagamentoVenda_FormaPagamento1_idx");

            entity.HasIndex(e => e.IdVenda, "fk_FormaPagamentoVenda_Venda1_idx");

            entity.Property(e => e.IdFormaPagamento)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idFormaPagamento");
            entity.Property(e => e.IdVenda)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idVenda");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdFormaPagamentoNavigation).WithMany(p => p.Formapagamentovenda)
                .HasForeignKey(d => d.IdFormaPagamento)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_FormaPagamentoVenda_FormaPagamento1");

            entity.HasOne(d => d.IdVendaNavigation).WithMany(p => p.Formapagamentovenda)
                .HasForeignKey(d => d.IdVenda)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_FormaPagamentoVenda_Venda1");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medicamento");

            entity.HasIndex(e => e.Nome, "Idx_Nome");

            entity.HasIndex(e => e.Id, "idMedicamento_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Ativo).HasMaxLength(3);
            entity.Property(e => e.Importado).HasMaxLength(3);
            entity.Property(e => e.Nome).HasMaxLength(30);
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.Email, "Email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Email, "Idx_Email");

            entity.HasIndex(e => e.Telefone, "Telefone_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "idTutor_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Cep).HasColumnType("int(11)");
            entity.Property(e => e.Cidade).HasMaxLength(40);
            entity.Property(e => e.DataNascimento).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Numero).HasMaxLength(10);
            entity.Property(e => e.Rua).HasMaxLength(60);
            entity.Property(e => e.Senha).HasMaxLength(50);
            entity.Property(e => e.Telefone).HasMaxLength(13);
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pet");

            entity.HasIndex(e => e.Nome, "Idx_Nome");

            entity.HasIndex(e => e.IdTutor, "fk_Pet_Tutor1_idx");

            entity.HasIndex(e => e.Id, "idPet_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.DataNascimento).HasColumnType("date");
            entity.Property(e => e.Especie).HasMaxLength(20);
            entity.Property(e => e.IdTutor)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idTutor");
            entity.Property(e => e.Nome).HasMaxLength(30);
            entity.Property(e => e.Raca).HasMaxLength(25);
            entity.Property(e => e.Sexo).HasMaxLength(10);

            entity.HasOne(d => d.IdTutorNavigation).WithMany(p => p.Pets)
                .HasForeignKey(d => d.IdTutor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Pet_Tutor1");
        });

        modelBuilder.Entity<Petmedicamento>(entity =>
        {
            entity.HasKey(e => new { e.IdPet, e.IdMedicamento }).HasName("PRIMARY");

            entity.ToTable("petmedicamento");

            entity.HasIndex(e => e.IdMedicamento, "fk_PetMedicamento_Medicamento1_idx");

            entity.HasIndex(e => e.IdVeterinario, "fk_PetMedicamento_Pessoa1_idx");

            entity.HasIndex(e => e.IdPet, "fk_PetMedicamento_Pet1_idx");

            entity.Property(e => e.IdPet)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idPet");
            entity.Property(e => e.IdMedicamento)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idMedicamento");
            entity.Property(e => e.Ativo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("ativo");
            entity.Property(e => e.DataInicio).HasColumnType("date");
            entity.Property(e => e.DataTermino).HasColumnType("date");
            entity.Property(e => e.Dosagem).HasColumnType("int(10) unsigned");
            entity.Property(e => e.Frequencia).HasColumnType("int(11)");
            entity.Property(e => e.IdVeterinario)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idVeterinario");
            entity.Property(e => e.Intervalo).HasColumnType("int(11)");
            entity.Property(e => e.Medida).HasMaxLength(5);

            entity.HasOne(d => d.IdMedicamentoNavigation).WithMany(p => p.Petmedicamentos)
                .HasForeignKey(d => d.IdMedicamento)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_PetMedicamento_Medicamento1");

            entity.HasOne(d => d.IdPetNavigation).WithMany(p => p.Petmedicamentos)
                .HasForeignKey(d => d.IdPet)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_PetMedicamento_Pet1");

            entity.HasOne(d => d.IdVeterinarioNavigation).WithMany(p => p.Petmedicamentos)
                .HasForeignKey(d => d.IdVeterinario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_PetMedicamento_Pessoa1");
        });

        modelBuilder.Entity<Petshop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("petshop");

            entity.HasIndex(e => e.Cnpj, "Cnpj_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Email, "Email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Telefone, "Telefone_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "idAtendente_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Cep).HasMaxLength(8);
            entity.Property(e => e.Cidade).HasMaxLength(40);
            entity.Property(e => e.Cnpj).HasMaxLength(14);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Numero).HasMaxLength(10);
            entity.Property(e => e.Rua).HasMaxLength(60);
            entity.Property(e => e.Senha).HasMaxLength(50);
            entity.Property(e => e.Telefone).HasMaxLength(13);
        });

        modelBuilder.Entity<Petshoppessoa>(entity =>
        {
            entity.HasKey(e => new { e.IdPetshop, e.IdPessoa }).HasName("PRIMARY");

            entity.ToTable("petshoppessoa");

            entity.HasIndex(e => e.IdPessoa, "fk_PetshopPessoa_Pessoa1_idx");

            entity.HasIndex(e => e.IdPetshop, "fk_PetshopPessoa_Petshop1_idx");

            entity.Property(e => e.IdPetshop)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idPetshop");
            entity.Property(e => e.IdPessoa)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idPessoa");
            entity.Property(e => e.Papel)
                .HasDefaultValueSql("'A'")
                .HasColumnType("enum('A','V','C')")
                .HasColumnName("papel");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.Petshoppessoas)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_PetshopPessoa_Pessoa1");

            entity.HasOne(d => d.IdPetshopNavigation).WithMany(p => p.Petshoppessoas)
                .HasForeignKey(d => d.IdPetshop)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_PetshopPessoa_Petshop1");
        });

        modelBuilder.Entity<Petvacina>(entity =>
        {
            entity.HasKey(e => new { e.IdPet, e.IdVacina }).HasName("PRIMARY");

            entity.ToTable("petvacina");

            entity.HasIndex(e => e.IdVeterinario, "fk_PetVacina_Pessoa1_idx");

            entity.HasIndex(e => e.IdPet, "fk_PetVacina_Pet1_idx");

            entity.HasIndex(e => e.IdVacina, "fk_PetVacina_Vacina1_idx");

            entity.Property(e => e.IdPet)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idPet");
            entity.Property(e => e.IdVacina)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idVacina");
            entity.Property(e => e.DataAplicacao).HasColumnType("date");
            entity.Property(e => e.IdVeterinario)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idVeterinario");

            entity.HasOne(d => d.IdPetNavigation).WithMany(p => p.Petvacinas)
                .HasForeignKey(d => d.IdPet)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_PetVacina_Pet1");

            entity.HasOne(d => d.IdVacinaNavigation).WithMany(p => p.Petvacinas)
                .HasForeignKey(d => d.IdVacina)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_PetVacina_Vacina1");

            entity.HasOne(d => d.IdVeterinarioNavigation).WithMany(p => p.Petvacinas)
                .HasForeignKey(d => d.IdVeterinario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_PetVacina_Pessoa1");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("produto");

            entity.HasIndex(e => e.Codigo, "Codigo_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "Idx_Nome");

            entity.HasIndex(e => e.IdPetshop, "fk_Produto_Petshop1_idx");

            entity.HasIndex(e => e.Id, "idProduto_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("ativo");
            entity.Property(e => e.Codigo)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(10) unsigned");
            entity.Property(e => e.Descricao).HasMaxLength(400);
            entity.Property(e => e.IdPetshop)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idPetshop");
            entity.Property(e => e.Nome).HasMaxLength(40);
            entity.Property(e => e.Quantidade).HasColumnType("int(10) unsigned");

            entity.HasOne(d => d.IdPetshopNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdPetshop)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Produto_Petshop1");
        });

        modelBuilder.Entity<Produtovendum>(entity =>
        {
            entity.HasKey(e => new { e.IdProduto, e.IdVenda }).HasName("PRIMARY");

            entity.ToTable("produtovenda");

            entity.HasIndex(e => e.IdProduto, "fk_ProdutoVenda_Produto1_idx");

            entity.HasIndex(e => e.IdVenda, "fk_ProdutoVenda_Venda1_idx");

            entity.Property(e => e.IdProduto)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idProduto");
            entity.Property(e => e.IdVenda)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idVenda");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Produtovenda)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ProdutoVenda_Produto1");

            entity.HasOne(d => d.IdVendaNavigation).WithMany(p => p.Produtovenda)
                .HasForeignKey(d => d.IdVenda)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ProdutoVenda_Venda1");
        });

        modelBuilder.Entity<Vacina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vacina");

            entity.HasIndex(e => e.Nome, "Idx_Nome");

            entity.HasIndex(e => e.Id, "idVacina_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Nome).HasMaxLength(25);
            entity.Property(e => e.Periodo).HasColumnType("int(10) unsigned");
        });

        modelBuilder.Entity<Vendum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("venda");

            entity.HasIndex(e => e.DataVenda, "Idx_DataVenda");

            entity.HasIndex(e => e.IdAtendente, "fk_Venda_Pessoa1_idx");

            entity.HasIndex(e => e.IdCliente, "fk_Venda_Pessoa2_idx");

            entity.HasIndex(e => e.Id, "idVenda_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.DataVenda).HasColumnType("date");
            entity.Property(e => e.FormaPagamento).HasMaxLength(20);
            entity.Property(e => e.IdAtendente)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idAtendente");
            entity.Property(e => e.IdCliente)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idCliente");
            entity.Property(e => e.Pago).HasColumnType("tinyint(4)");
            entity.Property(e => e.Parcelas).HasColumnType("int(10) unsigned");

            entity.HasOne(d => d.IdAtendenteNavigation).WithMany(p => p.VendumIdAtendenteNavigations)
                .HasForeignKey(d => d.IdAtendente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Venda_Pessoa1");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.VendumIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Venda_Pessoa2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
