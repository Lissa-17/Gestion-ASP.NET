using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionHopital.Migrations
{
    /// <inheritdoc />
    public partial class migrationFinale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Medecin_MedecinId",
                table: "Consultation");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Consultation_ConsultationId",
                table: "Prescription");

            migrationBuilder.AlterColumn<int>(
                name: "ConsultationId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedecinId",
                table: "Consultation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Medecin_MedecinId",
                table: "Consultation",
                column: "MedecinId",
                principalTable: "Medecin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Consultation_ConsultationId",
                table: "Prescription",
                column: "ConsultationId",
                principalTable: "Consultation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Medecin_MedecinId",
                table: "Consultation");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Consultation_ConsultationId",
                table: "Prescription");

            migrationBuilder.AlterColumn<int>(
                name: "ConsultationId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedecinId",
                table: "Consultation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Medecin_MedecinId",
                table: "Consultation",
                column: "MedecinId",
                principalTable: "Medecin",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Consultation_ConsultationId",
                table: "Prescription",
                column: "ConsultationId",
                principalTable: "Consultation",
                principalColumn: "Id");
        }
    }
}
