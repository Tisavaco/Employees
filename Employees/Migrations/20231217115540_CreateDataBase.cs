using Microsoft.EntityFrameworkCore.Migrations;

namespace Employees.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employe",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<string>(nullable: true),
                    PassportSeries = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employe", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    ActualAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employe");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
