using Microsoft.EntityFrameworkCore.Migrations;

namespace Employees.Migrations
{
    public partial class SetForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "INN",
                table: "Organizations",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_INN",
                table: "Organizations",
                column: "INN",
                unique: true,
                filter: "[INN] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employe_OrganizationId",
                table: "Employe",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employe_Organizations_OrganizationId",
                table: "Employe",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employe_Organizations_OrganizationId",
                table: "Employe");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_INN",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Employe_OrganizationId",
                table: "Employe");

            migrationBuilder.AlterColumn<string>(
                name: "INN",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
