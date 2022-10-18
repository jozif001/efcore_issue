using Microsoft.EntityFrameworkCore.Migrations;

namespace efcore_issue.Migrations
{
    public partial class MG_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnyProp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "child1s",
                columns: table => new
                {
                    RootId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    AnyProp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child1s", x => x.RootId);
                    table.ForeignKey(
                        name: "FK_child1s_Roots_RootId",
                        column: x => x.RootId,
                        principalTable: "Roots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "child2s",
                columns: table => new
                {
                    RootId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    AnyProp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child2s", x => x.RootId);
                    table.ForeignKey(
                        name: "FK_child2s_Roots_RootId",
                        column: x => x.RootId,
                        principalTable: "Roots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "child3s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RootId = table.Column<int>(nullable: false),
                    AnyProp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child3s", x => new { x.RootId, x.Id });
                    table.ForeignKey(
                        name: "FK_child3s_Roots_RootId",
                        column: x => x.RootId,
                        principalTable: "Roots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "child1s");

            migrationBuilder.DropTable(
                name: "child2s");

            migrationBuilder.DropTable(
                name: "child3s");

            migrationBuilder.DropTable(
                name: "Roots");
        }
    }
}
