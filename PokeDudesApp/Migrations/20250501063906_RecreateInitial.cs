using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeDudesApp.Migrations
{
    /// <inheritdoc />
    public partial class RecreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokeDudes",
                columns: table => new
                {
                    PokeDudeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokeDudes", x => x.PokeDudeId);
                });

            migrationBuilder.CreateTable(
                name: "PokePals",
                columns: table => new
                {
                    PokePalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    PokeDudeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokePals", x => x.PokePalId);
                    table.ForeignKey(
                        name: "FK_PokePals_PokeDudes_PokeDudeId",
                        column: x => x.PokeDudeId,
                        principalTable: "PokeDudes",
                        principalColumn: "PokeDudeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokePals_PokeDudeId",
                table: "PokePals",
                column: "PokeDudeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokePals");

            migrationBuilder.DropTable(
                name: "PokeDudes");
        }
    }
}
