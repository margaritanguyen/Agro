using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Change_Silo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalGroups_AnimalGroups_AnimalGroupId",
                table: "AnimalGroups");

            migrationBuilder.DropIndex(
                name: "IX_AnimalGroups_AnimalGroupId",
                table: "AnimalGroups");

            migrationBuilder.DropColumn(
                name: "AnimalGroupId",
                table: "AnimalGroups");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Silos",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Products",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "ProductRecipes",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "DosingTasks",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Balances",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$uBkk6kvhgypwdGBF4Dz94uF0Yv7UtCs5mkVinjo1UGB.0o4tEcxDy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Silos",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Products",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "ProductRecipes",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "DosingTasks",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Balances",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimalGroupId",
                table: "AnimalGroups",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AnimalGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "AnimalGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$.YWKg4LufRM.duzYy/5K4etBir/pguAT4Aq.o.c2mHTAO4fLbTez2");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalGroups_AnimalGroupId",
                table: "AnimalGroups",
                column: "AnimalGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalGroups_AnimalGroups_AnimalGroupId",
                table: "AnimalGroups",
                column: "AnimalGroupId",
                principalTable: "AnimalGroups",
                principalColumn: "Id");
        }
    }
}
