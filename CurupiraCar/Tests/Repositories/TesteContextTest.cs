using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.EntitiesConfig;
using System.Linq;

namespace Tests.Repositories
{
    public class TesteContextTest: DbContext
    {
        public DbSet<ApoliceSeguro> Apolices { get; set; }
        public TesteContextTest(DbContextOptions<TesteContextTest> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApoliceSeguro>(new ApoliceSeguroConfig().Configure);
        }

        public static void RunSeed(TesteContextTest db)
        {
            db.Apolices.AddRange(
                new ApoliceSeguro { IdentificacaoSegurado="0123456789",NumeroApolice=10,PlacaVeiculo="ABC123",ValorPremio=1.23m},
                new ApoliceSeguro { IdentificacaoSegurado="9876543210",NumeroApolice=20,PlacaVeiculo="DFG456",ValorPremio=1.23m},
                new ApoliceSeguro { IdentificacaoSegurado="56789012345",NumeroApolice=30,PlacaVeiculo="HIJ789",ValorPremio=1.23m},
                new ApoliceSeguro { IdentificacaoSegurado="45612378901",NumeroApolice=40,PlacaVeiculo="KLM012",ValorPremio=1.23m} 
                );
            db.SaveChanges();
        }
        public static void CleanContext(TesteContextTest db)
        {
            db.Apolices.RemoveRange(db.Apolices.Where(x => true));
            db.SaveChanges();
        }
    }
}