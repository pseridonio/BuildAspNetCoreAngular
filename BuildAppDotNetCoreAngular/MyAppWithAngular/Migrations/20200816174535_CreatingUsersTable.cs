using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAppWithAngular.Migrations
{
    public partial class CreatingUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USERS",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    USER_NAME = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    PASSWORD_SALT = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PASSWORD_HASH = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USER_ID);
                    table.UniqueConstraint("UQ1_USERS", x => x.USER_NAME);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USERS");
        }
    }
}
