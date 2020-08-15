using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildAppDotNetCoreAngular.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_VALUES",
                columns: table => new
                {
                    VALUE_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VALUES", x => x.VALUE_ID);
                    table.UniqueConstraint("UQ1_ROLES", x => x.NAME);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_VALUES");
        }
    }
}
