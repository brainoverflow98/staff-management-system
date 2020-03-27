using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonelTakip.Migrations
{
    public partial class GeceCalismasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HesaplamaSecenekleri",
                keyColumns: new[] { "HesaplamaId", "SecenekId" },
                keyValues: new object[] { 17L, 5L },
                column: "Katsayi",
                value: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HesaplamaSecenekleri",
                keyColumns: new[] { "HesaplamaId", "SecenekId" },
                keyValues: new object[] { 17L, 5L },
                column: "Katsayi",
                value: 1);
        }
    }
}
