using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataAccess.Migrations
{
    public partial class UpdateRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ref",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "RefDeb",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "Ref",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "RefDeb",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "Num",
                table: "Estimates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Estimates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Num",
                table: "Bills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Bills",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Num",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "Num",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Bills");

            migrationBuilder.AddColumn<string>(
                name: "Ref",
                table: "Estimates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefDeb",
                table: "Estimates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ref",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefDeb",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
