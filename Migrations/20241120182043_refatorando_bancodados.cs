using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    public partial class refatorando_bancodados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_especialidade",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_paciente",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_profissional",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_profissional_especialidade",
                columns: table => new
                {
                    id_profissional = table.Column<int>(type: "int", nullable: false),
                    id_especialidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_profissional_especialidade", x => new { x.id_especialidade, x.id_profissional });
                    table.ForeignKey(
                        name: "FK_tb_profissional_especialidade_especialidades_id_especialidade",
                        column: x => x.id_especialidade,
                        principalTable: "especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_profissional_especialidade_profissional_id_profissional",
                        column: x => x.id_profissional,
                        principalTable: "profissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_id_especialidade",
                table: "Consultas",
                column: "id_especialidade");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_id_paciente",
                table: "Consultas",
                column: "id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_id_profissional",
                table: "Consultas",
                column: "id_profissional");

            migrationBuilder.CreateIndex(
                name: "IX_tb_profissional_especialidade_id_profissional",
                table: "tb_profissional_especialidade",
                column: "id_profissional");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_especialidades_id_especialidade",
                table: "Consultas",
                column: "id_especialidade",
                principalTable: "especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_id_paciente",
                table: "Consultas",
                column: "id_paciente",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_profissional_id_profissional",
                table: "Consultas",
                column: "id_profissional",
                principalTable: "profissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_especialidades_id_especialidade",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_id_paciente",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_profissional_id_profissional",
                table: "Consultas");

            migrationBuilder.DropTable(
                name: "tb_profissional_especialidade");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_id_especialidade",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_id_paciente",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_id_profissional",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "id_especialidade",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "id_paciente",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "id_profissional",
                table: "Consultas");
        }
    }
}
