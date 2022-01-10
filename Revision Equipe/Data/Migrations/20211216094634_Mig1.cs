using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresseLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomEquipe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.EquipeId);
                });

            migrationBuilder.CreateTable(
                name: "Membre",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaisssance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    Poste = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membre", x => x.Identifiant);
                });

            migrationBuilder.CreateTable(
                name: "Trophee",
                columns: table => new
                {
                    TropheeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTrophee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recompense = table.Column<double>(type: "float", nullable: false),
                    TypeTrophee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipeId = table.Column<int>(type: "int", nullable: true),
                    EquipeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophee", x => x.TropheeId);
                    table.ForeignKey(
                        name: "FK_Trophee_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contrat",
                columns: table => new
                {
                    DateContrat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MembreFk = table.Column<int>(type: "int", nullable: false),
                    EquipeFk = table.Column<int>(type: "int", nullable: false),
                    DureeMois = table.Column<int>(type: "int", nullable: false),
                    Salaire = table.Column<double>(type: "float", nullable: false),
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrat", x => new { x.DateContrat, x.EquipeFk, x.MembreFk });
                    table.ForeignKey(
                        name: "FK_Contrat_Equipe_EquipeFk",
                        column: x => x.EquipeFk,
                        principalTable: "Equipe",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrat_Membre_MembreFk",
                        column: x => x.MembreFk,
                        principalTable: "Membre",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrat_EquipeFk",
                table: "Contrat",
                column: "EquipeFk");

            migrationBuilder.CreateIndex(
                name: "IX_Contrat_MembreFk",
                table: "Contrat",
                column: "MembreFk");

            migrationBuilder.CreateIndex(
                name: "IX_Trophee_EquipeId",
                table: "Trophee",
                column: "EquipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrat");

            migrationBuilder.DropTable(
                name: "Trophee");

            migrationBuilder.DropTable(
                name: "Membre");

            migrationBuilder.DropTable(
                name: "Equipe");
        }
    }
}
