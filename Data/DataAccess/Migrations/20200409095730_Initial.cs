using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<string>(nullable: true),
                    RefDeb = table.Column<int>(nullable: false),
                    Objet = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    ModeR = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    mDate = table.Column<DateTime>(nullable: false),
                    DateP = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statut = table.Column<int>(nullable: false),
                    Societe = table.Column<string>(nullable: true),
                    Civil = table.Column<int>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Pays = table.Column<string>(nullable: true),
                    CP = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estimates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<string>(nullable: true),
                    RefDeb = table.Column<int>(nullable: false),
                    Objet = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    ModeR = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    mDate = table.Column<DateTime>(nullable: false),
                    DateP = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Estimates");
        }
    }
}
