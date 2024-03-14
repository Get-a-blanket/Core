using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GaB_Core.Migrations
{
    /// <inheritdoc />
    public partial class _0060 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentTariffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTariffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneRegionCodes",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneRegionCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneRegionCodeId = table.Column<short>(type: "smallint", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    DateOfRegistration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_PhoneRegionCodes_PhoneRegionCodeId",
                        column: x => x.PhoneRegionCodeId,
                        principalTable: "PhoneRegionCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveBlankets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentTariffId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataOfIssue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveBlankets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveBlankets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveBlankets_PaymentTariffs_PaymentTariffId",
                        column: x => x.PaymentTariffId,
                        principalTable: "PaymentTariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PhoneRegionCodes",
                columns: new[] { "Id", "Name" },
                values: new object[] { (short)7, "RU" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DateOfRegistration", "Email", "PhoneNumber", "PhoneRegionCodeId" },
                values: new object[] { new Guid("fa2e2a6f-6703-4ef0-8765-941d20d10a70"), new DateTime(2024, 3, 14, 9, 40, 33, 114, DateTimeKind.Utc).AddTicks(5591), "info@getablanket.ru", 1234567890L, (short)7 });

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
                name: "PaymentTariffs");

            migrationBuilder.DropTable(
                name: "PhoneRegionCodes");
        }
    }
}
