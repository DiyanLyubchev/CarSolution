﻿// <auto-generated />
using GasCarDataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

namespace GasCarDataAccess.Migrations
{
    [DbContext(typeof(GasCarDbContext))]
    partial class GasCarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("GasCarDataAccess.Database.GasCarTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("CarBrand")
                        .HasColumnName("CARBRAND");

                    b.Property<string>("CarModel")
                        .HasColumnName("CARMODEL");

                    b.HasKey("Id");

                    b.ToTable("GASCAR");
                });
#pragma warning restore 612, 618
        }
    }
}