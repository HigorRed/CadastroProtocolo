using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroProtocolo.Migrations
{
    /// <inheritdoc />
    public partial class AddProtocoloWithEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocolos_StatusProtocolos_ProtocoloStatusId",
                table: "Protocolos");

            migrationBuilder.DropTable(
                name: "ProtocoloFollows");

            migrationBuilder.DropTable(
                name: "StatusProtocolos");

            migrationBuilder.DropIndex(
                name: "IX_Protocolos_ProtocoloStatusId",
                table: "Protocolos");

            migrationBuilder.RenameColumn(
                name: "ProtocoloStatusId",
                table: "Protocolos",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "IdProtocolo",
                table: "Protocolos",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Protocolos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAbertura",
                table: "Protocolos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Protocolos",
                newName: "ProtocoloStatusId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Protocolos",
                newName: "IdProtocolo");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Protocolos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAbertura",
                table: "Protocolos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
                        principalColumn: "IdProtocolo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusProtocolos",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusProtocolos", x => x.IdStatus);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_ProtocoloStatusId",
                table: "Protocolos",
                column: "ProtocoloStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocoloFollows_ProtocoloId",
                table: "ProtocoloFollows",
                column: "ProtocoloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Protocolos_StatusProtocolos_ProtocoloStatusId",
                table: "Protocolos",
                column: "ProtocoloStatusId",
                principalTable: "StatusProtocolos",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
