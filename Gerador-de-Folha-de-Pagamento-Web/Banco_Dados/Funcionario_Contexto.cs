using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gerador_de_Folha_de_Pagamento_Web.Models;

namespace Gerador_de_Folha_de_Pagamento_Web.Data
{
    public partial class Funcionario_Contexto : DbContext
    {
        public Funcionario_Contexto()
        {
        }

        public Funcionario_Contexto(DbContextOptions<Funcionario_Contexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Funcionario> Funcionario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-1JTSLQO\\SQLEXPRESS;Database=Folha_Pagamento_Ataron;TrustServerCertificate=true;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.CPF);

                SetEntityProperties(entity.Property(e => e.CPF), 14);
                SetEntityProperties(entity.Property(e => e.Senha), 20);
                SetEntityProperties(entity.Property(e => e.Nome), 40);
                SetEntityProperties(entity.Property(e => e.Data_Nascimento), 10);
                SetEntityProperties(entity.Property(e => e.Sexo), 11);
                SetEntityProperties(entity.Property(e => e.PCD), 3);
                SetEntityProperties(entity.Property(e => e.PIS), 14);
                SetEntityProperties(entity.Property(e => e.RG), 12);
                SetEntityProperties(entity.Property(e => e.Carteira_Trabalho), 20);
                SetEntityProperties(entity.Property(e => e.Titulo_Eleitor), 14);
                SetEntityProperties(entity.Property(e => e.Certificado_Militar), 15);
                SetEntityProperties(entity.Property(e => e.Matricula));
                SetEntityProperties(entity.Property(e => e.Telefone_Fixo), 14);
                SetEntityProperties(entity.Property(e => e.Telefone_Celular), 15);
                SetEntityProperties(entity.Property(e => e.Email), 40);
                SetEntityProperties(entity.Property(e => e.Dependentes));
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void SetEntityProperties(PropertyBuilder property, int maxLength = -1)
        {
            if (maxLength > -1)
            {
                property.HasMaxLength(maxLength);
            }

            property.IsUnicode(false);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}