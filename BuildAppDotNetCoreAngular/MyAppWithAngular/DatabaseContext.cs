using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyAppWithAngular.Models;
using MyAppWithAngular.Models.Users;
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
        public DbSet<User> Users { get; set; }

        public DatabaseContext([NotNullAttribute] DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigureRolesTable(modelBuilder);
            this.ConfigureUsersTable(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureRolesTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Value>(valueEntity =>
            {
                valueEntity.ToTable("TB_VALUES");

                valueEntity
                    .Property(value => value.ID)
                    .HasColumnName("VALUE_ID")
                    .HasColumnType("INTEGER")
                    .IsRequired();

                valueEntity
                    .Property(value => value.Name)
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR(250)")
                    .IsRequired();

                valueEntity
                    .HasKey(value => value.ID)
                    .HasName("PK_VALUES");

                valueEntity
                    .HasAlternateKey(role => role.Name)
                    .HasName("UQ1_ROLES");
            });
        }

        private void ConfigureUsersTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Users.User>(userEntity =>
            {
                userEntity.ToTable("TB_USERS");

                userEntity
                    .Property(user => user.Id)
                    .HasColumnName("USER_ID")
                    .HasColumnType("INTEGER")
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                userEntity
                    .Property(user => user.UserName)
                    .HasColumnName("USER_NAME")
                    .HasColumnType("VARCHAR(250)")
                    .IsRequired();

                userEntity
                    .Property(user => user.PasswordSalt)
                    .HasColumnName("PASSWORD_SALT")
                    .HasColumnType("BLOB")
                    .IsRequired();

                userEntity
                    .Property(user => user.PasswordHash)
                    .HasColumnName("PASSWORD_HASH")
                    .HasColumnType("BLOB")
                    .IsRequired();

                userEntity
                    .HasKey(User => User.Id)
                    .HasName("PK_USERS");

                userEntity
                    .HasAlternateKey(user => user.UserName)
                    .HasName("UQ1_USERS");
            });
        }
    }

}
