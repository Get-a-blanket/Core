using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaB_Core.Migrations.UnprotectedDb
{
    /// <inheritdoc />
    public partial class AddAddressVM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "VendingMachines",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "VendingMachines");
        }
    }
}
