using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncyclopediaOfHadiths.Migrations
{
    public partial class tryHashtag1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "HashTagId",
                table: "Hadiths",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HashTags",
                columns: table => new
                {
                    HashTagId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HashTagTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTags", x => x.HashTagId);
                });

            migrationBuilder.CreateTable(
                name: "HadithsHashTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HadithId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HashTagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HadithsHashTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HadithsHashTags_Hadiths_HadithId",
                        column: x => x.HadithId,
                        principalTable: "Hadiths",
                        principalColumn: "HadithId");
                    table.ForeignKey(
                        name: "FK_HadithsHashTags_HashTags_HashTagId",
                        column: x => x.HashTagId,
                        principalTable: "HashTags",
                        principalColumn: "HashTagId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HadithsHashTags_HadithId",
                table: "HadithsHashTags",
                column: "HadithId");

            migrationBuilder.CreateIndex(
                name: "IX_HadithsHashTags_HashTagId",
                table: "HadithsHashTags",
                column: "HashTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HadithsHashTags");

            migrationBuilder.DropTable(
                name: "HashTags");

            migrationBuilder.DropColumn(
                name: "HashTagId",
                table: "Hadiths");
        }
    }
}
