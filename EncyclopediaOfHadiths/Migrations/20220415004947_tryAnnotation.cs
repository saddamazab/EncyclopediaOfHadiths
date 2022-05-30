using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncyclopediaOfHadiths.Migrations
{
    public partial class tryAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Parts",
                table: "Chapters");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Chapters",
                newName: "ChapterId");

            migrationBuilder.AlterColumn<string>(
                name: "PartTitle",
                table: "Parts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ChapterTitle",
                table: "Chapters",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Parts_PartId",
                table: "Chapters",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Parts_PartId",
                table: "Chapters");

            migrationBuilder.RenameColumn(
                name: "ChapterId",
                table: "Chapters",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "PartTitle",
                table: "Parts",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ChapterTitle",
                table: "Chapters",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Parts",
                table: "Chapters",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id");
        }
    }
}
