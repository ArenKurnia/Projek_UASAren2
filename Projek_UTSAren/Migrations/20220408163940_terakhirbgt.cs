using Microsoft.EntityFrameworkCore.Migrations;

namespace Projek_UTSAren.Migrations
{
    public partial class terakhirbgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tb_Event_Id_angkatan",
                table: "Tb_Event");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Event_Id_angkatan",
                table: "Tb_Event",
                column: "Id_angkatan",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tb_Event_Id_angkatan",
                table: "Tb_Event");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Event_Id_angkatan",
                table: "Tb_Event",
                column: "Id_angkatan");
        }
    }
}
