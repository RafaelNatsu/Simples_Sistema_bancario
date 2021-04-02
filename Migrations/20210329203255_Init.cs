using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.MVC.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipoconta = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoModalidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Saldo = table.Column<double>(type: "REAL", nullable: false),
                    Credito = table.Column<double>(type: "REAL", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
