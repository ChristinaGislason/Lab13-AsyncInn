using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab13_AsyncInn.Migrations
{
    public partial class addedNavProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomID1",
                table: "HotelRooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "RoomAmenities",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomID1",
                table: "HotelRooms",
                column: "RoomID1");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Hotels_HotelID",
                table: "HotelRooms",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Rooms_RoomID1",
                table: "HotelRooms",
                column: "RoomID1",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesID",
                table: "RoomAmenities",
                column: "AmenitiesID",
                principalTable: "Amenities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Hotels_HotelID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Rooms_RoomID1",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesID",
                table: "RoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_RoomID1",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "RoomID1",
                table: "HotelRooms");
        }
    }
}
