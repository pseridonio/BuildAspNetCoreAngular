using Microsoft.EntityFrameworkCore;
using MyAppWithAngular.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppWithAngular
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Value> Values { get; set; }

        public DatabaseContext([NotNullAttribute] DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigureRolesTable(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureRolesTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Value>(roleEntity =>
            {
                roleEntity.ToTable("TB_VALUES");

                roleEntity
                    .Property(value => value.ID)
                    .HasColumnName("VALUE_ID")
                    .HasColumnType("INTEGER")
                    .IsRequired();

                roleEntity
                    .Property(value => value.Name)
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR(250)")
                    .IsRequired();

                roleEntity
                    .HasKey(value => value.ID)
                    .HasName("PK_VALUES");

                roleEntity
                    .HasAlternateKey(role => role.Name)
                    .HasName("UQ1_ROLES");
            });
        }

    }
}
