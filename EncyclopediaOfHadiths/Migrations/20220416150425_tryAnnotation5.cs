using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncyclopediaOfHadiths.Migrations
{
    public partial class tryAnnotation5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusTerm",
                table: "ReviewTerms",
                newName: "ReviewTermTitle");

            migrationBuilder.AddColumn<long>(
                name: "NarratorsChainId",
                table: "Hadiths",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "Chapters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NarratorsChainId",
                table: "Hadiths");

            migrationBuilder.RenameColumn(
                name: "ReviewTermTitle",
                table: "ReviewTerms",
                newName: "StatusTerm");

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
