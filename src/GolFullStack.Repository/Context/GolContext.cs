using System;
using System.Linq;
using GolFullStack.Entity.Entities.Business;
using Microsoft.EntityFrameworkCore;

namespace GolFullStack.Repository.Context
{
    public class GolContext : DbContext
    {
        public GolContext(DbContextOptions<GolContext> options) : base(options)        {        }        protected override void OnModelCreating(ModelBuilder modelBuilder)        {            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(                e => e.GetProperties().Where(                p => p.ClrType == typeof(string))))            {                property.Relational().ColumnType = "varchar(100)";            }            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GolContext).Assembly);            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;            base.OnModelCreating(modelBuilder);        }


        #region Tables

        #region Business

        public DbSet<Airplane> Airplane { get; set; }

        #endregion

        #endregion

    }
}
