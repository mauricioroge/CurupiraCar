﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Context;

namespace Repository.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Domain.Model.ApoliceSeguro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdentificacaoSegurado")
                        .IsRequired();

                    b.Property<double>("NumeroApolice");

                    b.Property<string>("PlacaVeiculo")
                        .IsRequired();

                    b.Property<decimal>("ValorPremio");

                    b.HasKey("Id")
                        .HasName("PK_ApoliceSeguro_Id");

                    b.HasIndex("NumeroApolice")
                        .HasName("UK_ApoliceSeguro_NumeroApolice");

                    b.ToTable("ApoliceSeguro");
                });
#pragma warning restore 612, 618
        }
    }
}