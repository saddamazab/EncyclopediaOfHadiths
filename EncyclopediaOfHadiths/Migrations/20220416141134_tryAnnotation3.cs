using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncyclopediaOfHadiths.Migrations
{
    public partial class tryAnnotation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hadiths_Collections",
                table: "Hadiths");

            migrationBuilder.DropForeignKey(
                name: "FK_Hadiths_HadithTypes",
                table: "Hadiths");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithsChapters_Chapters",
                table: "HadithsChapters");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithsChapters_Hadiths",
                table: "HadithsChapters");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithsReviews_Hadiths",
                table: "HadithsReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithsReviews_ReviewTerms",
                table: "HadithsReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_NarratorsChains_Hadiths",
                table: "NarratorsChains");

            migrationBuilder.DropForeignKey(
                name: "FK_NarratorsChains_NarratorLevels",
                table: "NarratorsChains");

            migrationBuilder.DropForeignKey(
                name: "FK_NarratorsChains_Narrators",
                table: "NarratorsChains");

            migrationBuilder.DropColumn(
                name: "HadithType",
                table: "HadithTypes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReviewTerms",
                newName: "ReviewTermId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NarratorsChains",
                newName: "NarratorsChainId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Narrators",
                newName: "NarratorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NarratorLevels",
                newName: "NarratorLevelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HadithTypes",
                newName: "HadithTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hadiths",
                newName: "HadithId");

            migrationBuilder.AlterColumn<string>(
                name: "StatusTerm",
                table: "ReviewTerms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(50)",
                oldFixedLength: true,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PartTitle",
                table: "Parts",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NarratorWasBorned",
                table: "Narrators",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NarratorName",
                table: "Narrators",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NarratorDied",
                table: "Narrators",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HadithTypeTitle",
                table: "HadithTypes",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "HadithText",
                table: "Hadiths",
                type: "ntext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HadithNo",
                table: "Hadiths",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollectionTitle",
                table: "Collections",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CollectionAuthor",
                table: "Collections",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ChapterTitle",
                table: "Chapters",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Hadiths_Collections_CollectionId",
                table: "Hadiths",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hadiths_HadithTypes_HadithTypeId",
                table: "Hadiths",
                column: "HadithTypeId",
                principalTable: "HadithTypes",
                principalColumn: "HadithTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithsChapters_Chapters_ChapterId",
                table: "HadithsChapters",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithsChapters_Hadiths_HadithId",
                table: "HadithsChapters",
                column: "HadithId",
                principalTable: "Hadiths",
                principalColumn: "HadithId");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithsReviews_Hadiths_HadithId",
                table: "HadithsReviews",
                column: "HadithId",
                principalTable: "Hadiths",
                principalColumn: "HadithId");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithsReviews_ReviewTerms_ReviewTermId",
                table: "HadithsReviews",
                column: "ReviewTermId",
                principalTable: "ReviewTerms",
                principalColumn: "ReviewTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarratorsChains_Hadiths_HadithId",
                table: "NarratorsChains",
                column: "HadithId",
                principalTable: "Hadiths",
                principalColumn: "HadithId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarratorsChains_NarratorLevels_NarratorLevel",
                table: "NarratorsChains",
                column: "NarratorLevel",
                principalTable: "NarratorLevels",
                principalColumn: "NarratorLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarratorsChains_Narrators_NarratorId",
                table: "NarratorsChains",
                column: "NarratorId",
                principalTable: "Narrators",
                principalColumn: "NarratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hadiths_Collections_CollectionId",
                table: "Hadiths");

            migrationBuilder.DropForeignKey(
                name: "FK_Hadiths_HadithTypes_HadithTypeId",
                table: "Hadiths");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithsChapters_Chapters_ChapterId",
                table: "HadithsChapters");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithsChapters_Hadiths_HadithId",
                table: "HadithsChapters");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithsReviews_Hadiths_HadithId",
                table: "HadithsReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithsReviews_ReviewTerms_ReviewTermId",
                table: "HadithsReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_NarratorsChains_Hadiths_HadithId",
                table: "NarratorsChains");

            migrationBuilder.DropForeignKey(
                name: "FK_NarratorsChains_NarratorLevels_NarratorLevel",
                table: "NarratorsChains");

            migrationBuilder.DropForeignKey(
                name: "FK_NarratorsChains_Narrators_NarratorId",
                table: "NarratorsChains");

            migrationBuilder.DropColumn(
                name: "HadithTypeTitle",
                table: "HadithTypes");

            migrationBuilder.RenameColumn(
                name: "ReviewTermId",
                table: "ReviewTerms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NarratorsChainId",
                table: "NarratorsChains",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NarratorId",
                table: "Narrators",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NarratorLevelId",
                table: "NarratorLevels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HadithTypeId",
                table: "HadithTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HadithId",
                table: "Hadiths",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "StatusTerm",
                table: "ReviewTerms",
                type: "nchar(50)",
                fixedLength: true,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PartTitle",
                table: "Parts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NarratorWasBorned",
                table: "Narrators",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NarratorName",
                table: "Narrators",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NarratorDied",
                table: "Narrators",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HadithType",
                table: "HadithTypes",
                type: "nchar(50)",
                fixedLength: true,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "HadithText",
                table: "Hadiths",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AlterColumn<int>(
                name: "HadithNo",
                table: "Hadiths",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CollectionTitle",
                table: "Collections",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "CollectionAuthor",
                table: "Collections",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "ChapterTitle",
                table: "Chapters",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddForeignKey(
                name: "FK_Hadiths_Collections",
                table: "Hadiths",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hadiths_HadithTypes",
                table: "Hadiths",
                column: "HadithTypeId",
                principalTable: "HadithTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithsChapters_Chapters",
                table: "HadithsChapters",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithsChapters_Hadiths",
                table: "HadithsChapters",
                column: "HadithId",
                principalTable: "Hadiths",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithsReviews_Hadiths",
                table: "HadithsReviews",
                column: "HadithId",
                principalTable: "Hadiths",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithsReviews_ReviewTerms",
                table: "HadithsReviews",
                column: "ReviewTermId",
                principalTable: "ReviewTerms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NarratorsChains_Hadiths",
                table: "NarratorsChains",
                column: "HadithId",
                principalTable: "Hadiths",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NarratorsChains_NarratorLevels",
                table: "NarratorsChains",
                column: "NarratorLevel",
                principalTable: "NarratorLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NarratorsChains_Narrators",
                table: "NarratorsChains",
                column: "NarratorId",
                principalTable: "Narrators",
                principalColumn: "Id");
        }
    }
}
