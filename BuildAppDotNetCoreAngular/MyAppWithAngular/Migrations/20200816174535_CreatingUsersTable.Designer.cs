﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAppWithAngular;

namespace MyAppWithAngular.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200816174535_CreatingUsersTable")]
    partial class CreatingUsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("MyAppWithAngular.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("USER_ID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("PASSWORD_HASH")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("PASSWORD_SALT")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("USER_NAME")
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("Id")
                        .HasName("PK_USERS");

                    b.HasAlternateKey("UserName")
                        .HasName("UQ1_USERS");

                    b.ToTable("TB_USERS");
                });

            modelBuilder.Entity("MyAppWithAngular.Models.Value", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VALUE_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("ID")
                        .HasName("PK_VALUES");

                    b.HasAlternateKey("Name")
                        .HasName("UQ1_ROLES");

                    b.ToTable("TB_VALUES");
                });
#pragma warning restore 612, 618
        }
    }
}
