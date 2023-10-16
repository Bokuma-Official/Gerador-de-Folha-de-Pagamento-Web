using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gerador_de_Folha_de_Pagamento_Web.Models;
using Gerador_de_Folha_de_Pagamento_Web.Data;

namespace Gerador_de_Folha_de_Pagamento_Web.Banco_Dados
{
    public partial class Folha_Pagamento_Contexto : DbContext
    {
        public Folha_Pagamento_Contexto()
        {

        }

        public Folha_Pagamento_Contexto(DbContextOptions<Folha_Pagamento_Contexto> options)
            : base(options)
        {

        }

        public virtual DbSet<Folha_Pagamento> Folha_Pagamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MATHEUS-C5\\SQLEXPRESS;Database=Folha_Pagamento_Ataron;TrustServerCertificate=true;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folha_Pagamento>(entity =>
            {
                entity.HasKey(folha_pagamento => folha_pagamento.ID_Folha_Pagamento);

                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.ID_Folha_Pagamento));
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Data_Pagamento), 10);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Horas_Trabalhadas));
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Valor_Hora), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Horas_Faltas));
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Desconto_Horas_Faltas), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Horas_Extras));
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Valor_Horas_Extras), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Valor_Vale_Transporte), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Valor_Vale_Alimentacao), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Desconto_INSS), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Desconto_FGTS), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Desconto_IRRF), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Desconto_Vale_Transporte), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Desconto_Vale_Alimentacao), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Desconto_Seguro_Vida), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Dias_Ferias));
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Valor_Ferias), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Valor_13_Salario), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Salario_Bruto), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.Salario_Liquido), 9);
                SetEntityProperties(entity.Property(folha_pagamento => folha_pagamento.CPF), 14);
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
