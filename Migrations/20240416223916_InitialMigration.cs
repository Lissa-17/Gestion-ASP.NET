using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionHopital.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medecin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Specialite = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Date_enregistrement = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poids = table.Column<double>(type: "float", nullable: false),
                    Hauteur = table.Column<double>(type: "float", nullable: false),
                    Diagnostique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Consultation = table.Column<DateTime>(type: "date", nullable: false),
                    MedecinId = table.Column<int>(type: "int", nullable: true),
                    PatientCode = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultation_Medecin_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Consultation_Patient_PatientCode",
                        column: x => x.PatientCode,
                        principalTable: "Patient",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescription_Consultation_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_MedecinId",
                table: "Consultation",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_PatientCode",
                table: "Consultation",
                column: "PatientCode");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ConsultationId",
                table: "Prescription",
                column: "ConsultationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "Medecin");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
