using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATM.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineNote_Machine_MachineId",
                table: "MachineNote");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineNote_Machine_MachineId",
                table: "MachineNote",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineNote_Machine_MachineId",
                table: "MachineNote");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineNote_Machine_MachineId",
                table: "MachineNote",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
