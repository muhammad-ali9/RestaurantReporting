using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peristence.Migrations
{
    /// <inheritdoc />
    public partial class AddRestaurantCitySerialNumberModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantSerialNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantSerialNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantSerialNumbers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_RestaurantSerialNumbers_SerialNumberId",
                        column: x => x.SerialNumberId,
                        principalTable: "RestaurantSerialNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$aMUkN/iQvPTc8KPEyGTsP.xGJuo8qGowFAMrwQdVPo88rIKfm3.3e");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_SerialNumberId",
                table: "Restaurants",
                column: "SerialNumberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantSerialNumbers_CityId",
                table: "RestaurantSerialNumbers",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "RestaurantSerialNumbers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$.J6PZVoGgDqy54IjxxNSjueCN4TS7jLN16zM2n3fPCOX5Md6ap/bG");
        }
    }
}
