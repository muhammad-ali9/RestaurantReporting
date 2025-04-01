using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peristence.Migrations
{
    /// <inheritdoc />
    public partial class SerialNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$WUSY3Zx6iYgRopKoPXhp8.yO071Xk25Y3s1p8XMTaVOXsF4QBpqrC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ZXA6g3XeOvAOJXP.Cp5hxeyBJ55glHkcQbcJMrDCEQiaKLNQW81tS");
        }
    }
}
