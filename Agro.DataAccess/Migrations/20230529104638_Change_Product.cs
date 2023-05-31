using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Change_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AnimalGroups_AnimalGroupId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalGroupId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$dg.CLBiDAs4WNkhlO6fLWOAmLkSkqdAaDPARhdHyqnrFO8XNjdLGG");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AnimalGroups_AnimalGroupId",
                table: "Products",
                column: "AnimalGroupId",
                principalTable: "AnimalGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AnimalGroups_AnimalGroupId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalGroupId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$uBkk6kvhgypwdGBF4Dz94uF0Yv7UtCs5mkVinjo1UGB.0o4tEcxDy");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AnimalGroups_AnimalGroupId",
                table: "Products",
                column: "AnimalGroupId",
                principalTable: "AnimalGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
