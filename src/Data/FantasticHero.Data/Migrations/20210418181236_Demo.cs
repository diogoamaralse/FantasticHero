using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasticHero.Data.Migrations
{
    public partial class Demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroType",
                columns: table => new
                {
                    CoreObjectID = table.Column<Guid>(type: "TEXT", nullable: false),
                    HeroTypeName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroType", x => x.CoreObjectID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    CoreObjectID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Itens = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.CoreObjectID);
                });

            migrationBuilder.CreateTable(
                name: "Heros",
                columns: table => new
                {
                    CoreObjectID = table.Column<Guid>(type: "TEXT", nullable: false),
                    BagCoreObjectID = table.Column<Guid>(type: "TEXT", nullable: true),
                    HeroTypeCoreObjectID = table.Column<Guid>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    GamezoneCoreObjectID = table.Column<Guid>(type: "TEXT", nullable: true),
                    CharacterName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Option = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemCoreObjectID = table.Column<Guid>(type: "TEXT", nullable: true),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heros", x => x.CoreObjectID);
                    table.ForeignKey(
                        name: "FK_Heros_HeroType_HeroTypeCoreObjectID",
                        column: x => x.HeroTypeCoreObjectID,
                        principalTable: "HeroType",
                        principalColumn: "CoreObjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Heros_Item_BagCoreObjectID",
                        column: x => x.BagCoreObjectID,
                        principalTable: "Item",
                        principalColumn: "CoreObjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Heros_Item_ItemCoreObjectID",
                        column: x => x.ItemCoreObjectID,
                        principalTable: "Item",
                        principalColumn: "CoreObjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameZones",
                columns: table => new
                {
                    CoreObjectID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Option = table.Column<int>(type: "INTEGER", nullable: false),
                    ScenarioName = table.Column<string>(type: "TEXT", nullable: true),
                    PlayerCoreObjectID = table.Column<Guid>(type: "TEXT", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameZones", x => x.CoreObjectID);
                    table.ForeignKey(
                        name: "FK_GameZones_Heros_PlayerCoreObjectID",
                        column: x => x.PlayerCoreObjectID,
                        principalTable: "Heros",
                        principalColumn: "CoreObjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Monster",
                columns: table => new
                {
                    CoreObjectID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MonsterName = table.Column<string>(type: "TEXT", nullable: true),
                    GamezoneCoreObjectID = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Option = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemCoreObjectID = table.Column<Guid>(type: "TEXT", nullable: true),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monster", x => x.CoreObjectID);
                    table.ForeignKey(
                        name: "FK_Monster_GameZones_GamezoneCoreObjectID",
                        column: x => x.GamezoneCoreObjectID,
                        principalTable: "GameZones",
                        principalColumn: "CoreObjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Monster_Item_ItemCoreObjectID",
                        column: x => x.ItemCoreObjectID,
                        principalTable: "Item",
                        principalColumn: "CoreObjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "GameZones",
                columns: new[] { "CoreObjectID", "Height", "Option", "PlayerCoreObjectID", "ScenarioName", "Width" },
                values: new object[] { new Guid("457bcc00-fa3a-4266-a13c-4af4d760160e"), 30, 1, null, "Mars", 50 });

            migrationBuilder.InsertData(
                table: "GameZones",
                columns: new[] { "CoreObjectID", "Height", "Option", "PlayerCoreObjectID", "ScenarioName", "Width" },
                values: new object[] { new Guid("355203df-200b-4d54-9ece-43d95e472da2"), 25, 2, null, "Saturn", 40 });

            migrationBuilder.InsertData(
                table: "GameZones",
                columns: new[] { "CoreObjectID", "Height", "Option", "PlayerCoreObjectID", "ScenarioName", "Width" },
                values: new object[] { new Guid("5ca76bf2-abf2-48ef-95d6-1aa43ec13c89"), 50, 3, null, "Jupiter", 30 });

            migrationBuilder.InsertData(
                table: "GameZones",
                columns: new[] { "CoreObjectID", "Height", "Option", "PlayerCoreObjectID", "ScenarioName", "Width" },
                values: new object[] { new Guid("191caaaf-b45a-4b5b-9d7b-aaa5581a42ad"), 60, 4, null, "Uranus", 60 });

            migrationBuilder.InsertData(
                table: "HeroType",
                columns: new[] { "CoreObjectID", "HeroTypeName" },
                values: new object[] { new Guid("5939eef6-17fd-4609-adec-7fa44a2cb619"), "Tragic" });

            migrationBuilder.InsertData(
                table: "HeroType",
                columns: new[] { "CoreObjectID", "HeroTypeName" },
                values: new object[] { new Guid("b830c6fb-8c50-42f2-a204-43f4fc1b4cc1"), "Superhero" });

            migrationBuilder.InsertData(
                table: "HeroType",
                columns: new[] { "CoreObjectID", "HeroTypeName" },
                values: new object[] { new Guid("5b782544-77ef-4ac6-a2df-6b7f0fffaf46"), "Epic" });

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "CoreObjectID", "BagCoreObjectID", "Discriminator", "GamezoneCoreObjectID", "HeroTypeCoreObjectID", "ItemCoreObjectID", "Name", "Option", "Speed" },
                values: new object[] { new Guid("e0c14e3f-b76a-4df2-8f1c-08a49bda77ef"), null, "Hero", null, null, null, "Super Man", 1, 0 });

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "CoreObjectID", "BagCoreObjectID", "Discriminator", "GamezoneCoreObjectID", "HeroTypeCoreObjectID", "ItemCoreObjectID", "Name", "Option", "Speed" },
                values: new object[] { new Guid("b92d19b8-1cb8-4de8-a8ac-a225e0fc6f57"), null, "Hero", null, null, null, "Invisible Woman", 2, 0 });

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "CoreObjectID", "BagCoreObjectID", "Discriminator", "GamezoneCoreObjectID", "HeroTypeCoreObjectID", "ItemCoreObjectID", "Name", "Option", "Speed" },
                values: new object[] { new Guid("c3951d14-32bb-4055-b20f-cc50ab2a72be"), null, "Hero", null, null, null, "Allien", 3, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_GameZones_PlayerCoreObjectID",
                table: "GameZones",
                column: "PlayerCoreObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Heros_BagCoreObjectID",
                table: "Heros",
                column: "BagCoreObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Heros_GamezoneCoreObjectID",
                table: "Heros",
                column: "GamezoneCoreObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Heros_HeroTypeCoreObjectID",
                table: "Heros",
                column: "HeroTypeCoreObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Heros_ItemCoreObjectID",
                table: "Heros",
                column: "ItemCoreObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Monster_GamezoneCoreObjectID",
                table: "Monster",
                column: "GamezoneCoreObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Monster_ItemCoreObjectID",
                table: "Monster",
                column: "ItemCoreObjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_GameZones_GamezoneCoreObjectID",
                table: "Heros",
                column: "GamezoneCoreObjectID",
                principalTable: "GameZones",
                principalColumn: "CoreObjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameZones_Heros_PlayerCoreObjectID",
                table: "GameZones");

            migrationBuilder.DropTable(
                name: "Monster");

            migrationBuilder.DropTable(
                name: "Heros");

            migrationBuilder.DropTable(
                name: "GameZones");

            migrationBuilder.DropTable(
                name: "HeroType");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
