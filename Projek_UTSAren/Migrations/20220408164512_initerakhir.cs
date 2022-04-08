using Microsoft.EntityFrameworkCore.Migrations;

namespace Projek_UTSAren.Migrations
{
    public partial class initerakhir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Tahun_Tb_Event_Id_angkatan",
                table: "Tb_Tahun");

            migrationBuilder.AddColumn<string>(
                name: "RolesId",
                table: "Tb_Tahun",
                type: "varchar(767)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Tahun_RolesId",
                table: "Tb_Tahun",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Tahun_Tb_Roles_RolesId",
                table: "Tb_Tahun",
                column: "RolesId",
                principalTable: "Tb_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Tahun_Tb_Roles_RolesId",
                table: "Tb_Tahun");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Tahun_RolesId",
                table: "Tb_Tahun");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Tb_Tahun");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Tahun_Tb_Event_Id_angkatan",
                table: "Tb_Tahun",
                column: "Id_angkatan",
                principalTable: "Tb_Event",
                principalColumn: "Id_event",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
