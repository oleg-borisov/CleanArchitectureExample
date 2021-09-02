using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment.DataAccess.Implementation.MSSQL.Migrations
{
    public partial class removedEquipmentItemId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentItemId",
                table: "EquipmentItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentItemId",
                table: "EquipmentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EquipmentItems",
                keyColumns: new[] { "EquipmentTypeId", "RoomId" },
                keyValues: new object[] { 1, 1 },
                column: "EquipmentItemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "EquipmentItems",
                keyColumns: new[] { "EquipmentTypeId", "RoomId" },
                keyValues: new object[] { 2, 1 },
                column: "EquipmentItemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "EquipmentItems",
                keyColumns: new[] { "EquipmentTypeId", "RoomId" },
                keyValues: new object[] { 3, 1 },
                column: "EquipmentItemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "EquipmentItems",
                keyColumns: new[] { "EquipmentTypeId", "RoomId" },
                keyValues: new object[] { 3, 4 },
                column: "EquipmentItemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "EquipmentItems",
                keyColumns: new[] { "EquipmentTypeId", "RoomId" },
                keyValues: new object[] { 4, 4 },
                column: "EquipmentItemId",
                value: 4);
        }
    }
}
