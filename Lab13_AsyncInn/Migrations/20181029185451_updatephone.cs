using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab13_AsyncInn.Migrations
{
    public partial class updatephone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Hotels",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1,
                column: "Phone",
                value: "998-853-5544");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2,
                column: "Phone",
                value: "887-700-4030");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3,
                column: "Phone",
                value: "858-535-5221");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 4,
                column: "Phone",
                value: "550-053-4477");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 5,
                column: "Phone",
                value: "423-111-5356");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Hotels",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1,
                column: "Phone",
                value: 9988);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2,
                column: "Phone",
                value: 8877);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3,
                column: "Phone",
                value: 8585);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 4,
                column: "Phone",
                value: 5500);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 5,
                column: "Phone",
                value: 4231);
        }
    }
}
