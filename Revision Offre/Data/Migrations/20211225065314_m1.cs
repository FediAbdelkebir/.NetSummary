using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entreprise",
                columns: table => new
                {
                    IdEntreprise = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiffreAffaire = table.Column<int>(type: "int", nullable: false),
                    DateFondation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Effectif = table.Column<int>(type: "int", nullable: false),
                    NomEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Secteur = table.Column<int>(type: "int", nullable: false),
                    AdresseEntreprise_Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseEntreprise_Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseEntreprise_CodePostal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise", x => x.IdEntreprise);
                });

            migrationBuilder.CreateTable(
                name: "Postulant",
                columns: table => new
                {
                    IdPstulant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postulant", x => x.IdPstulant);
                });

            migrationBuilder.CreateTable(
                name: "Offre",
                columns: table => new
                {
                    IdOffre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TitreOffre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeContrat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntrepriseFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offre", x => x.IdOffre);
                    table.ForeignKey(
                        name: "FK_Offre_Entreprise_EntrepriseFK",
                        column: x => x.EntrepriseFK,
                        principalTable: "Entreprise",
                        principalColumn: "IdEntreprise",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidature",
                columns: table => new
                {
                    OffresIdOffre = table.Column<int>(type: "int", nullable: false),
                    PostulantsIdPstulant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidature", x => new { x.OffresIdOffre, x.PostulantsIdPstulant });
                    table.ForeignKey(
                        name: "FK_Candidature_Offre_OffresIdOffre",
                        column: x => x.OffresIdOffre,
                        principalTable: "Offre",
                        principalColumn: "IdOffre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidature_Postulant_PostulantsIdPstulant",
                        column: x => x.PostulantsIdPstulant,
                        principalTable: "Postulant",
                        principalColumn: "IdPstulant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_PostulantsIdPstulant",
                table: "Candidature",
                column: "PostulantsIdPstulant");

            migrationBuilder.CreateIndex(
                name: "IX_Offre_EntrepriseFK",
                table: "Offre",
                column: "EntrepriseFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidature");

            migrationBuilder.DropTable(
                name: "Offre");

            migrationBuilder.DropTable(
                name: "Postulant");

            migrationBuilder.DropTable(
                name: "Entreprise");
        }
    }
}
