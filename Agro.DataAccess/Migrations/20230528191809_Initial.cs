using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Agro.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    AnimalGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalGroups_AnimalGroups_AnimalGroupId",
                        column: x => x.AnimalGroupId,
                        principalTable: "AnimalGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArchiveMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DosingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiloTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiloTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    MinBatchSize = table.Column<float>(type: "real", nullable: false),
                    MaxBatchSize = table.Column<float>(type: "real", nullable: false),
                    MixTime = table.Column<int>(type: "int", nullable: false),
                    DryMixTime = table.Column<int>(type: "int", nullable: false),
                    AnimalGroupId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AnimalGroups_AnimalGroupId",
                        column: x => x.AnimalGroupId,
                        principalTable: "AnimalGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EmptyTolerance = table.Column<float>(type: "real", nullable: false),
                    WeighTolerance = table.Column<float>(type: "real", nullable: false),
                    MinWeight = table.Column<float>(type: "real", nullable: false),
                    MaxWeight = table.Column<float>(type: "real", nullable: false),
                    MaxDosingTime = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balances_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    TechTolerance = table.Column<float>(type: "real", nullable: false),
                    RejectTolerance = table.Column<float>(type: "real", nullable: false),
                    AlertTolerance = table.Column<float>(type: "real", nullable: false),
                    Density = table.Column<float>(type: "real", nullable: false),
                    Activity = table.Column<float>(type: "real", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: true),
                    DosingTypeId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_DosingTypes_DosingTypeId",
                        column: x => x.DosingTypeId,
                        principalTable: "DosingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRecipes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Silos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    MaxCapacity = table.Column<float>(type: "real", nullable: false),
                    RealStock = table.Column<float>(type: "real", nullable: false),
                    MaxComponentSize = table.Column<float>(type: "real", nullable: false),
                    FreeFall = table.Column<float>(type: "real", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    SiloTypeId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: true),
                    PreviousResourceId = table.Column<int>(type: "int", nullable: true),
                    DefaultBalanceId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Silos_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Silos_Balances_DefaultBalanceId",
                        column: x => x.DefaultBalanceId,
                        principalTable: "Balances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Silos_Resources_PreviousResourceId",
                        column: x => x.PreviousResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Silos_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Silos_SiloTypes_SiloTypeId",
                        column: x => x.SiloTypeId,
                        principalTable: "SiloTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductRecipeId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    ResourceContent = table.Column<float>(type: "real", nullable: false),
                    DosingPriority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_ProductRecipes_ProductRecipeId",
                        column: x => x.ProductRecipeId,
                        principalTable: "ProductRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DosingTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufNr = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    BatchSize = table.Column<float>(type: "real", nullable: false),
                    BatchCount = table.Column<int>(type: "int", nullable: false),
                    InProcessBatchCount = table.Column<int>(type: "int", nullable: false),
                    ReadyBatchCount = table.Column<int>(type: "int", nullable: false),
                    SiloOneId = table.Column<int>(type: "int", nullable: true),
                    SiloTwoId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductRecipeId = table.Column<int>(type: "int", nullable: false),
                    TaskMessageId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosingTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosingTasks_ProductRecipes_ProductRecipeId",
                        column: x => x.ProductRecipeId,
                        principalTable: "ProductRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosingTasks_Silos_SiloOneId",
                        column: x => x.SiloOneId,
                        principalTable: "Silos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DosingTasks_Silos_SiloTwoId",
                        column: x => x.SiloTwoId,
                        principalTable: "Silos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DosingTasks_TaskMessages_TaskMessageId",
                        column: x => x.TaskMessageId,
                        principalTable: "TaskMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AnimalGroups",
                columns: new[] { "Id", "AnimalGroupId", "Code", "Name" },
                values: new object[] { 1, null, 0, "-" });

            migrationBuilder.InsertData(
                table: "ArchiveMessages",
                columns: new[] { "Id", "Code", "Message" },
                values: new object[,]
                {
                    { 1, 0, "OK" },
                    { 2, 1, ">T" },
                    { 3, 2, ">A>T" },
                    { 4, 3, ">T OK" },
                    { 5, 4, ">T FAIL" },
                    { 6, 5, ">A>T OK" },
                    { 7, 6, ">A>T FAIL" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, 0, "-" });

            migrationBuilder.InsertData(
                table: "DosingTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, "ручное" },
                    { 2, 2, "жидкое" },
                    { 3, 3, "автоматическое" }
                });

            migrationBuilder.InsertData(
                table: "ResourceTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, 1, "минеральное" });

            migrationBuilder.InsertData(
                table: "SiloTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, 1, "дозаторный" });

            migrationBuilder.InsertData(
                table: "TaskMessages",
                columns: new[] { "Id", "Code", "Message" },
                values: new object[,]
                {
                    { 1, 0, "-" },
                    { 2, 1, "ожидает" },
                    { 3, 2, "выполняется" },
                    { 4, 3, "выполнено" },
                    { 5, 4, "остановлено" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Администратор" },
                    { 2, "Оператор" },
                    { 3, "Технолог" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "PasswordHash", "UserName", "UserRoleId" },
                values: new object[] { 1, "Администратор", "$2a$11$.YWKg4LufRM.duzYy/5K4etBir/pguAT4Aq.o.c2mHTAO4fLbTez2", "admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalGroups_AnimalGroupId",
                table: "AnimalGroups",
                column: "AnimalGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalGroups_Code",
                table: "AnimalGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMessages_Code",
                table: "ArchiveMessages",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Code",
                table: "Areas",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_AreaId",
                table: "Balances",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_Code",
                table: "Balances",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DosingTasks_ProductRecipeId",
                table: "DosingTasks",
                column: "ProductRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_DosingTasks_SiloOneId",
                table: "DosingTasks",
                column: "SiloOneId");

            migrationBuilder.CreateIndex(
                name: "IX_DosingTasks_SiloTwoId",
                table: "DosingTasks",
                column: "SiloTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_DosingTasks_TaskMessageId",
                table: "DosingTasks",
                column: "TaskMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_DosingTypes_Code",
                table: "DosingTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_ProductId",
                table: "ProductRecipes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AnimalGroupId",
                table: "Products",
                column: "AnimalGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_ProductRecipeId",
                table: "RecipeIngredients",
                column: "ProductRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_ResourceId",
                table: "RecipeIngredients",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Code",
                table: "Resources",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_DosingTypeId",
                table: "Resources",
                column: "DosingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceTypeId",
                table: "Resources",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTypes_Code",
                table: "ResourceTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Silos_AreaId",
                table: "Silos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Silos_Code",
                table: "Silos",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Silos_DefaultBalanceId",
                table: "Silos",
                column: "DefaultBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Silos_PreviousResourceId",
                table: "Silos",
                column: "PreviousResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Silos_ResourceId",
                table: "Silos",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Silos_SiloTypeId",
                table: "Silos",
                column: "SiloTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SiloTypes_Code",
                table: "SiloTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskMessages_Code",
                table: "TaskMessages",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveMessages");

            migrationBuilder.DropTable(
                name: "DosingTasks");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Silos");

            migrationBuilder.DropTable(
                name: "TaskMessages");

            migrationBuilder.DropTable(
                name: "ProductRecipes");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "SiloTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "DosingTypes");

            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.DropTable(
                name: "AnimalGroups");
        }
    }
}
