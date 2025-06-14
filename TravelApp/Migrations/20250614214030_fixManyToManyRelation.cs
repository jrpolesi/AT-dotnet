using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp.Migrations
{
    /// <inheritdoc />
    public partial class fixManyToManyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_PacotesTuristicos_PacoteTuristicoId",
                table: "Cidades");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_PacoteTuristicoId",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "PacoteTuristicoId",
                table: "Cidades");

            migrationBuilder.CreateTable(
                name: "CidadeDestinoPacoteTuristico",
                columns: table => new
                {
                    DestinosId = table.Column<int>(type: "INTEGER", nullable: false),
                    PacotesTuristicosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadeDestinoPacoteTuristico", x => new { x.DestinosId, x.PacotesTuristicosId });
                    table.ForeignKey(
                        name: "FK_CidadeDestinoPacoteTuristico_Cidades_DestinosId",
                        column: x => x.DestinosId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CidadeDestinoPacoteTuristico_PacotesTuristicos_PacotesTuristicosId",
                        column: x => x.PacotesTuristicosId,
                        principalTable: "PacotesTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CidadeDestinoPacoteTuristico_PacotesTuristicosId",
                table: "CidadeDestinoPacoteTuristico",
                column: "PacotesTuristicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CidadeDestinoPacoteTuristico");

            migrationBuilder.AddColumn<int>(
                name: "PacoteTuristicoId",
                table: "Cidades",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_PacoteTuristicoId",
                table: "Cidades",
                column: "PacoteTuristicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_PacotesTuristicos_PacoteTuristicoId",
                table: "Cidades",
                column: "PacoteTuristicoId",
                principalTable: "PacotesTuristicos",
                principalColumn: "Id");
        }
    }
}
