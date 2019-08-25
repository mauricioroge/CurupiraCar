using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.EntitiesConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class MySqlContext: DbContext
    {

        public DbSet<ApoliceSeguro> ApoliceSeguros { get; set; }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApoliceSeguro>(new ApoliceSeguroConfig().Configure);
        }
    }
}
