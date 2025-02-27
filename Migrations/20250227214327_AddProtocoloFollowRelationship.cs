using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroProtocolo.Migrations
{
    /// <inheritdoc />
    public partial class AddProtocoloFollowRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProtocoloFollows",
                columns: table => new
                {
                    IdFollow = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProtocoloId = table.Column<int>(type: "int", nullable: false),
                    DataAcao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoAcao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtocoloFollows", x => x.IdFollow);
                    table.ForeignKey(
                        name: "FK_ProtocoloFollows_Protocolos_ProtocoloId",
                        column: x => x.ProtocoloId,
                        principalTable: "Protocolos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProtocoloFollows_ProtocoloId",
                table: "ProtocoloFollows",
                column: "ProtocoloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProtocoloFollows");
        }
    }
}
