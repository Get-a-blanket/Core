﻿// <auto-generated />
using System;
using GaB_Core.UnprotectedDbConnector;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GaB_Core.Migrations.UnprotectedDb
{
    [DbContext(typeof(UnprotectedDbContext))]
    [Migration("20240207215755_0.0.2.12")]
    partial class _00212
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GaB_Core.UnprotectedDbConnector.Models.VendingMachine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric");

                    b.Property<int>("NumberOfCellsWBlankets")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfEmptyCells")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("VendingMachines");
                });
#pragma warning restore 612, 618
        }
    }
}
