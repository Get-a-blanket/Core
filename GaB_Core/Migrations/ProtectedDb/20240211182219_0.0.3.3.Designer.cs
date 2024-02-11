﻿// <auto-generated />
using System;
using GaB_Core.ProtectedDbConnector;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GaB_Core.Migrations
{
    [DbContext(typeof(ProtectedDbContext))]
    [Migration("20240211182219_0.0.3.3")]
    partial class _0033
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GaB_Core.ProtectedDbConnector.Models.ActiveBlanket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataOfIssue")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("PaymentTariffId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PaymentTariffId");

                    b.ToTable("ActiveBlankets");
                });

            modelBuilder.Entity("GaB_Core.ProtectedDbConnector.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<short?>("PhoneRegionCodeId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("PhoneRegionCodeId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("GaB_Core.ProtectedDbConnector.Models.PaymentTariff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("PaymentTariff");
                });

            modelBuilder.Entity("GaB_Core.ProtectedDbConnector.Models.PhoneRegionCode", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PhoneRegionCode");
                });

            modelBuilder.Entity("GaB_Core.ProtectedDbConnector.Models.ActiveBlanket", b =>
                {
                    b.HasOne("GaB_Core.ProtectedDbConnector.Models.Client", "Client")
                        .WithMany("ActiveBlankets")
                        .HasForeignKey("ClientId");

                    b.HasOne("GaB_Core.ProtectedDbConnector.Models.PaymentTariff", "PaymentTariff")
                        .WithMany()
                        .HasForeignKey("PaymentTariffId");

                    b.Navigation("Client");

                    b.Navigation("PaymentTariff");
                });

            modelBuilder.Entity("GaB_Core.ProtectedDbConnector.Models.Client", b =>
                {
                    b.HasOne("GaB_Core.ProtectedDbConnector.Models.PhoneRegionCode", "PhoneRegionCode")
                        .WithMany()
                        .HasForeignKey("PhoneRegionCodeId");

                    b.Navigation("PhoneRegionCode");
                });

            modelBuilder.Entity("GaB_Core.ProtectedDbConnector.Models.Client", b =>
                {
                    b.Navigation("ActiveBlankets");
                });
#pragma warning restore 612, 618
        }
    }
}
