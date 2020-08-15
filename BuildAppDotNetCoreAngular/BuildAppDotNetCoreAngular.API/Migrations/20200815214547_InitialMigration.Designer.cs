﻿// <auto-generated />
using BuildAppDotNetCoreAngular.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuildAppDotNetCoreAngular.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200815214547_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("BuildAppDotNetCoreAngular.API.Models.Value", b =>
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