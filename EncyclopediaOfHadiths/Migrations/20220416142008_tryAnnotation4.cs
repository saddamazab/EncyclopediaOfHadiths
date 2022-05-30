using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncyclopediaOfHadiths.Migrations
{
    public partial class tryAnnotation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Parts",
                newName: "PartId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Collections",
                newName: "CollectionId");

            migrationBuilder.AlterColumn<string>(
                name: "StatusTerm",
                table: "ReviewTerms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PartId",
                table: "Parts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CollectionId",
                table: "Collections",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "StatusTerm",
                table: "ReviewTerms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
