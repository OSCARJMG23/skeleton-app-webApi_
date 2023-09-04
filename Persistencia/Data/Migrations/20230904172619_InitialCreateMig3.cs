using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persona_Tipo Persona_IdTipoPersonaFk",
                table: "persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipo Persona",
                table: "Tipo Persona");

            migrationBuilder.RenameTable(
                name: "Tipo Persona",
                newName: "tipoPersona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tipoPersona",
                table: "tipoPersona",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_tipoPersona_IdTipoPersonaFk",
                table: "persona",
                column: "IdTipoPersonaFk",
                principalTable: "tipoPersona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persona_tipoPersona_IdTipoPersonaFk",
                table: "persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tipoPersona",
                table: "tipoPersona");

            migrationBuilder.RenameTable(
                name: "tipoPersona",
                newName: "Tipo Persona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipo Persona",
                table: "Tipo Persona",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_Tipo Persona_IdTipoPersonaFk",
                table: "persona",
                column: "IdTipoPersonaFk",
                principalTable: "Tipo Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
