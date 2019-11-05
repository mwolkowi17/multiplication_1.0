using Microsoft.EntityFrameworkCore.Migrations;

namespace mnozenie.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wyniki",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GradeValue = table.Column<string>(nullable: true),
                    Numberofex = table.Column<string>(nullable: true),
                    Ocena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wyniki", x => x.GradeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wyniki");
        }
    }
}
