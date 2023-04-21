using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiHero.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Power",
                table: "Heros");

            migrationBuilder.AddColumn<int>(
                name: "PowerId",
                table: "Heros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Heros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heros_PowerId",
                table: "Heros",
                column: "PowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Heros_SchoolId",
                table: "Heros",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Powers_PowerId",
                table: "Heros",
                column: "PowerId",
                principalTable: "Powers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Schools_SchoolId",
                table: "Heros",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Powers_PowerId",
                table: "Heros");

            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Schools_SchoolId",
                table: "Heros");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Heros_PowerId",
                table: "Heros");

            migrationBuilder.DropIndex(
                name: "IX_Heros_SchoolId",
                table: "Heros");

            migrationBuilder.DropColumn(
                name: "PowerId",
                table: "Heros");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Heros");

            migrationBuilder.AddColumn<string>(
                name: "Power",
                table: "Heros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
