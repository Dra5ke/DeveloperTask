﻿// <auto-generated />
using System;
using ChemicalsOverview.Controllers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChemicalsOverview.Migrations
{
    [DbContext(typeof(ChemicalContext))]
    [Migration("20200111120929_AddBackupSheets")]
    partial class AddBackupSheets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChemicalsOverview.Models.BackupSheet", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("SafetySheet");

                    b.HasKey("ProductId");

                    b.ToTable("BackupSheets","dbo");
                });

            modelBuilder.Entity("ChemicalsOverview.Models.Chemical", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("ProductName");

                    b.Property<string>("SupplierName");

                    b.Property<string>("Url");

                    b.Property<string>("UserName");

                    b.HasKey("ProductId");

                    b.ToTable("Chemicals","dbo");
                });
#pragma warning restore 612, 618
        }
    }
}