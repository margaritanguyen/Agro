using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Change_DosingTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsChecked",
                table: "DosingTasks",
                newName: "IsReady");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$QinOoPy3Kd0v1qU..hUliubyOb5oMBgED4kPWizMuw3sKiPdSnDDi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsReady",
                table: "DosingTasks",
                newName: "IsChecked");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$dg.CLBiDAs4WNkhlO6fLWOAmLkSkqdAaDPARhdHyqnrFO8XNjdLGG");
        }
    }
}
