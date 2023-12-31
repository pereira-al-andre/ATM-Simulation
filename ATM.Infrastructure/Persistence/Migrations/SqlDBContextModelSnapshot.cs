﻿// <auto-generated />
using System;
using ATM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ATM.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(SqlDBContext))]
    partial class SqlDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ATM.Domain.Entities.Banknote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("Amount");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Banknote", (string)null);
                });

            modelBuilder.Entity("ATM.Domain.Entities.Machine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Machine", (string)null);
                });

            modelBuilder.Entity("ATM.Domain.Entities.MachineNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("Amount");

                    b.Property<Guid>("BanknoteId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BanknoteId");

                    b.Property<Guid>("MachineId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MachineId");

                    b.HasKey("Id");

                    b.HasIndex("BanknoteId");

                    b.HasIndex("MachineId");

                    b.ToTable("MachineNote", (string)null);
                });

            modelBuilder.Entity("ATM.Domain.Entities.MachineNote", b =>
                {
                    b.HasOne("ATM.Domain.Entities.Banknote", "Banknote")
                        .WithMany()
                        .HasForeignKey("BanknoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ATM.Domain.Entities.Machine", "Machine")
                        .WithMany("MachineNotes")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Banknote");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("ATM.Domain.Entities.Machine", b =>
                {
                    b.Navigation("MachineNotes");
                });
#pragma warning restore 612, 618
        }
    }
}
