using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDesStagesSM.Server.Data.Migrations
{
    public partial class AjoutStageEtStageStatut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StageStatut",
                columns: table => new
                {
                    StageStatutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionStatut = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageStatut", x => x.StageStatutId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StageStatut");
        }
    }
}
