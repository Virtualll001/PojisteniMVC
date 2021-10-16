using Microsoft.EntityFrameworkCore.Migrations;

namespace PojisteniMVC.DataAccess.Migrations
{
    public partial class AddPojistenyDoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PojisteneOsoby",
                columns: table => new
                {
                    PojistenyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prijmeni = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PojisteneOsoby", x => x.PojistenyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PojisteneOsoby");
        }
    }
}
