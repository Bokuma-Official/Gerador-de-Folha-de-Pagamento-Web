using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gerador_de_Folha_de_Pagamento_Web.Models;
using Microsoft.Extensions.Configuration;

namespace Gerador_de_Folha_de_Pagamento_Web.Controllers
{
    public partial class Banco_Folha_Pagamento_Ataron_Contexto : DbContext
    {
        private IConfiguration Configuration { get; }

        public Banco_Folha_Pagamento_Ataron_Contexto(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Banco_Folha_Pagamento_Ataron_Contexto(DbContextOptions<Banco_Folha_Pagamento_Ataron_Contexto> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Contrato_Empresa> Contrato_Empresa { get; set; }
        public virtual DbSet<Folha_Pagamento> Folha_Pagamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Conexao"));
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

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(endereco => endereco.ID_Endereco);

                SetEntityProperties(entity.Property(endereco => endereco.ID_Endereco));
                SetEntityProperties(entity.Property(endereco => endereco.CEP), 9);
                SetEntityProperties(entity.Property(endereco => endereco.Logradouro), 40);
                SetEntityProperties(entity.Property(endereco => endereco.Numero));
                SetEntityProperties(entity.Property(endereco => endereco.Bairro), 25);
                SetEntityProperties(entity.Property(endereco => endereco.Complemento), 20);
                SetEntityProperties(entity.Property(endereco => endereco.Cidade), 25);
                SetEntityProperties(entity.Property(endereco => endereco.Estado), 20);
                SetEntityProperties(entity.Property(endereco => endereco.CPF), 14);
            });

            modelBuilder.Entity<Contrato_Empresa>(entity =>
            {
                entity.HasKey(contrato_empresa => contrato_empresa.ID_Contrato_Empresa);

                SetEntityProperties(entity.Property(contrato_empresa => contrato_empresa.ID_Contrato_Empresa));
                SetEntityProperties(entity.Property(contrato_empresa => contrato_empresa.Data_Admissao), 10);
                SetEntityProperties(entity.Property(contrato_empresa => contrato_empresa.Numero_Conta), 9);
                SetEntityProperties(entity.Property(contrato_empresa => contrato_empresa.Numero_Agencia));
                SetEntityProperties(entity.Property(contrato_empresa => contrato_empresa.Nome_Agencia), 20);
                SetEntityProperties(entity.Property(contrato_empresa => contrato_empresa.Tipo_Contrato), 15);
                SetEntityProperties(entity.Property(contrato_empresa => contrato_empresa.Cargo), 40);
                SetEntityProperties(entity.Property(contrato_empresa => contrato_empresa.CBO_Cargo), 7);
                SetEntityProperties(entity.Property(contrato_empresa => contrato_empresa.Departamento), 40);
                SetEntityProperties(entity.Property(contrato_empresa => contrato_empresa.CPF), 14);
            });

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