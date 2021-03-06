﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StateMachineDataAccess.Database;

namespace StateMachineDataAccess.Migrations
{
    [DbContext(typeof(StateMachineDbContext))]
    partial class StateMachineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StateMachineDataAccess.Database.StateMachineTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DieselCarId")
                        .HasColumnName("DIESELCARID")
                        .HasColumnType("int");

                    b.Property<int>("GasCarId")
                        .HasColumnName("GASCARID")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("State")
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("STATEMACHINE_CAR");
                });
#pragma warning restore 612, 618
        }
    }
}
