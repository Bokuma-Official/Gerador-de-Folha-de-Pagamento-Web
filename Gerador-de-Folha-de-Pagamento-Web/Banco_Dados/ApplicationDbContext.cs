using Microsoft.EntityFrameworkCore;
using Gerador_de_Folha_de_Pagamento_Web.Models;

namespace Gerador_de_Folha_de_Pagamento_Web.Banco_Dados
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Folha_Pagamento> Folha_Pagamento { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Contrato_Ataron> Contrato_Ataron { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Contrato_Ataron>()
            .HasKey(c => c.ID_Contrato_Empresa);

                modelBuilder.Entity<Endereco>()
            .HasKey(e => e.ID_Endereco);

                modelBuilder.Entity<Folha_Pagamento>()
            .HasKey(fp => fp.ID_Folha_Pagamento);

                modelBuilder.Entity<Funcionario>()
            .HasKey(f => f.CPF);
        }
    }
}
