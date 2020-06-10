﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using StateMachineDataAccess.Database;

namespace StateMachineDataAccess.Migrations
{
    [DbContext(typeof(StateMachineDbContext))]
    [Migration("20200610073123_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("StateMachineDataAccess.Database.StateMachineTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("DieselCarId")
                        .HasColumnName("DIESELCARID");

                    b.Property<int>("GasCarId")
                        .HasColumnName("GASCARID");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("State");

                    b.HasKey("Id");

                    b.ToTable("STATEMACHINE_CAR");
                });
#pragma warning restore 612, 618
        }
    }
}
