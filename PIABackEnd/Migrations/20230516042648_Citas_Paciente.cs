using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIABackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Citas_Paciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cita_Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaId = table.Column<int>(type: "int", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_Pacientes_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cita_Pacientes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_Pacientes_CitaId",
                table: "Cita_Pacientes",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_Pacientes_PacienteId",
                table: "Cita_Pacientes",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita_Pacientes");
        }
    }
}
