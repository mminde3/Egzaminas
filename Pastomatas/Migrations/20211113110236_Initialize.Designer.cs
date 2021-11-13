﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pastomatas.Data;

namespace Pastomatas.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211113110236_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pastomatas.Models.PostPackageModel", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<string>("ReceiverName")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("TerminalId")
                        .HasColumnType("int");

                    b.Property<int?>("TerminalModelTerminalId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(6,3)");

                    b.HasKey("PackageId");

                    b.HasIndex("TerminalModelTerminalId");

                    b.ToTable("PostPackages");
                });

            modelBuilder.Entity("Pastomatas.Models.PostTerminalModel", b =>
                {
                    b.Property<int>("TerminalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Town")
                        .HasColumnType("varchar(55)");

                    b.HasKey("TerminalId");

                    b.ToTable("PostTerminals");
                });

            modelBuilder.Entity("Pastomatas.Models.PostPackageModel", b =>
                {
                    b.HasOne("Pastomatas.Models.PostTerminalModel", "TerminalModel")
                        .WithMany("Package")
                        .HasForeignKey("TerminalModelTerminalId");

                    b.Navigation("TerminalModel");
                });

            modelBuilder.Entity("Pastomatas.Models.PostTerminalModel", b =>
                {
                    b.Navigation("Package");
                });
#pragma warning restore 612, 618
        }
    }
}
