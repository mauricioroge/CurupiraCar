using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.EntitiesConfig
{
    public class ApoliceSeguroConfig : IEntityTypeConfiguration<ApoliceSeguro>
    {
        public void Configure(EntityTypeBuilder<ApoliceSeguro> builder)
        {
            builder.ToTable("ApoliceSeguro");

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasKey(c=> c.Id).HasName("PK_ApoliceSeguro_Id");

            builder.Property(c => c.IdentificacaoSegurado).IsRequired();
            builder.Property(c => c.NumeroApolice).IsRequired();
            builder.Property(c => c.PlacaVeiculo).IsRequired();
            builder.Property(c => c.ValorPremio).IsRequired();

            builder.HasIndex(c => c.NumeroApolice).HasName("UK_ApoliceSeguro_NumeroApolice").IsUnique();
        }
    }
}
