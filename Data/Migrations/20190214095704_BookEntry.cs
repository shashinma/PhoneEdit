using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneEdit.Data.Migrations
{
    public partial class BookEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tel1",
                columns: table => new
                {
                    n = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tabNumber = table.Column<string>(type: "varchar(5)", nullable: false),
                    name = table.Column<string>(type: "varchar(250)", nullable: false),
                    who = table.Column<string>(type: "varchar(250)", nullable: false),
                    work = table.Column<string>(type: "varchar(250)", nullable: false),
                    telm = table.Column<string>(type: "varchar(50)", nullable: false),
                    telg = table.Column<string>(type: "varchar(100)", nullable: false),
                    mail = table.Column<string>(type: "varchar(250)", nullable: false),
                    komnata = table.Column<string>(type: "varchar(100)", nullable: false),
                    status = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.n);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tel1");
        }
    }
}
