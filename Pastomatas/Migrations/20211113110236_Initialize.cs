using Microsoft.EntityFrameworkCore.Migrations;

namespace Pastomatas.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostTerminals",
                columns: table => new
                {
                    TerminalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Town = table.Column<string>(type: "varchar(55)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTerminals", x => x.TerminalId);
                });

            migrationBuilder.CreateTable(
                name: "PostPackages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverName = table.Column<string>(type: "varchar(20)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    TerminalId = table.Column<int>(type: "int", nullable: false),
                    TerminalModelTerminalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPackages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_PostPackages_PostTerminals_TerminalModelTerminalId",
                        column: x => x.TerminalModelTerminalId,
                        principalTable: "PostTerminals",
                        principalColumn: "TerminalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostPackages_TerminalModelTerminalId",
                table: "PostPackages",
                column: "TerminalModelTerminalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostPackages");

            migrationBuilder.DropTable(
                name: "PostTerminals");
        }
    }
}
