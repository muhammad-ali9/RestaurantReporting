using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peristence.Migrations
{
    /// <inheritdoc />
    public partial class SerialNumberRelationShipUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "RestaurantTasks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ZXA6g3XeOvAOJXP.Cp5hxeyBJ55glHkcQbcJMrDCEQiaKLNQW81tS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerialNo",
                table: "RestaurantTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$7FY68BCD8bMWhoJZFAIXZeagTtEIgjKV2w4S1eYaKcvrCz6P8fZey");
        }
    }
}
