using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employees.Migrations
{
    public partial class ReconstructionDataBese : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "INN",
                table: "Organizations",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassportSeries",
                table: "Employe",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassportNumber",
                table: "Employe",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Employe",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "INN",
                table: "Organizations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassportSeries",
                table: "Employe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "PassportNumber",
                table: "Employe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Employe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
