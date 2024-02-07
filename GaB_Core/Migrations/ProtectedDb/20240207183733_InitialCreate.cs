using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GaB_Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentTariff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTariff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneRegionCode",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneRegionCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    DateOfRegistration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PhoneRegionCodeId = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_PhoneRegionCode_PhoneRegionCodeId",
                        column: x => x.PhoneRegionCodeId,
                        principalTable: "PhoneRegionCode",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActiveBlankets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataOfIssue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaymentTariffId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveBlankets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveBlankets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActiveBlankets_PaymentTariff_PaymentTariffId",
                        column: x => x.PaymentTariffId,
                        principalTable: "PaymentTariff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveBlankets_ClientId",
                table: "ActiveBlankets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveBlankets_PaymentTariffId",
                table: "ActiveBlankets",
                column: "PaymentTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PhoneRegionCodeId",
                table: "Clients",
                column: "PhoneRegionCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveBlankets");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "PaymentTariff");

            migrationBuilder.DropTable(
                name: "PhoneRegionCode");
        }
    }
}
