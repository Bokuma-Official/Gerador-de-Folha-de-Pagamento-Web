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
                optionsBuilder.UseSqlServer("Server=MATHEUS-C5\\SQLEXPRESS;Database=Folha_Pagamento_Ataron;TrustServerCertificate=true;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(funcionario => funcionario.CPF);

                SetEntityProperties(entity.Property(funcionario => funcionario.CPF), 14);
                SetEntityProperties(entity.Property(funcionario => funcionario.Senha), 20);
                SetEntityProperties(entity.Property(funcionario => funcionario.Nome), 40);
                SetEntityProperties(entity.Property(funcionario => funcionario.Data_Nascimento), 10);
                SetEntityProperties(entity.Property(funcionario => funcionario.Sexo), 11);
                SetEntityProperties(entity.Property(funcionario => funcionario.PCD), 3);
                SetEntityProperties(entity.Property(funcionario => funcionario.PIS), 14);
                SetEntityProperties(entity.Property(funcionario => funcionario.RG), 12);
                SetEntityProperties(entity.Property(funcionario => funcionario.Carteira_Trabalho), 20);
                SetEntityProperties(entity.Property(funcionario => funcionario.Titulo_Eleitor), 14);
                SetEntityProperties(entity.Property(funcionario => funcionario.Certificado_Militar), 15);
                SetEntityProperties(entity.Property(funcionario => funcionario.Matricula));
                SetEntityProperties(entity.Property(funcionario => funcionario.Telefone_Fixo), 14);
                SetEntityProperties(entity.Property(funcionario => funcionario.Telefone_Celular), 15);
                SetEntityProperties(entity.Property(funcionario => funcionario.Email), 40);
                SetEntityProperties(entity.Property(funcionario => funcionario.Dependentes));
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