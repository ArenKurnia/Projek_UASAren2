using Microsoft.EntityFrameworkCore.Migrations;

namespace Projek_UTSAren.Migrations
{
    public partial class terakhirasli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tb_Event_Id_angkatan",
                table: "Tb_Event");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Event_Id_angkatan",
                table: "Tb_Event",
                column: "Id_angkatan");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Tahun_Tb_Event_Id_angkatan",
                table: "Tb_Tahun",
                column: "Id_angkatan",
                principalTable: "Tb_Event",
                principalColumn: "Id_event",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Tahun_Tb_Event_Id_angkatan",
                table: "Tb_Tahun");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Event_Id_angkatan",
                table: "Tb_Event");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Event_Id_angkatan",
                table: "Tb_Event",
                column: "Id_angkatan",
                unique: true);
        }
    }
}
