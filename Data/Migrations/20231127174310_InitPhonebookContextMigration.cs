using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneEdit.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitPhonebookContextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tel1",
                columns: table => new
                {
                    n = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tabNumber = table.Column<string>(type: "varchar(5)", nullable: false),
                    name = table.Column<string>(type: "varchar(250)", nullable: false),
                    who = table.Column<string>(type: "varchar(250)", nullable: false),
                    work = table.Column<string>(type: "varchar(250)", nullable: false),
                    telm = table.Column<string>(type: "varchar(50)", nullable: false),
                    telg = table.Column<string>(type: "varchar(100)", nullable: false),
                    mail = table.Column<string>(type: "varchar(250)", nullable: false),
                    komnata = table.Column<string>(type: "varchar(100)", nullable: false),
                    status = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.n);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tel1");
        }
    }
}
