using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonelTakip.Migrations
{
    public partial class aciklamalarduzeltildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 2L,
                column: "OzetGoster",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 4L,
                column: "OzetGoster",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 5L,
                column: "OzetGoster",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 6L,
                column: "OzetGoster",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 7L,
                column: "OzetGoster",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 8L,
                column: "OzetGoster",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 9L,
                column: "OzetGoster",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 10L,
                column: "OzetGoster",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 11L,
                column: "OzetGoster",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 12L,
                column: "OzetGoster",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 2L,
                column: "OzetGoster",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 4L,
                column: "OzetGoster",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 5L,
                column: "OzetGoster",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 6L,
                column: "OzetGoster",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 7L,
                column: "OzetGoster",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 8L,
                column: "OzetGoster",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 9L,
                column: "OzetGoster",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 10L,
                column: "OzetGoster",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 11L,
                column: "OzetGoster",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hesaplamalar",
                keyColumn: "Id",
                keyValue: 12L,
                column: "OzetGoster",
                value: false);
        }
    }
}
