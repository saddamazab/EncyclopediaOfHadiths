using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncyclopediaOfHadiths.Migrations
{
    public partial class IntialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    CollectionTitle = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    CollectionAuthor = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HadithTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    HadithType = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    HadithTypeNote = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HadithTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NarratorLevels",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarratorLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Narrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarratorName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    NarratorWasBorned = table.Column<DateTime>(type: "date", nullable: true),
                    NarratorDied = table.Column<DateTime>(type: "date", nullable: true),
                    NarratorInfo = table.Column<string>(type: "ntext", nullable: true),
                    NarratorNote = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PartTitle = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewTerms",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    StatusTerm = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hadiths",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionId = table.Column<byte>(type: "tinyint", nullable: true),
                    HadithNo = table.Column<int>(type: "int", nullable: true),
                    HadithText = table.Column<string>(type: "ntext", nullable: true),
                    VocabsExplain = table.Column<string>(type: "ntext", nullable: true),
                    ReviewTermId = table.Column<byte>(type: "tinyint", nullable: true),
                    HadithTypeId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hadiths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hadiths_Collections",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hadiths_HadithTypes",
                        column: x => x.HadithTypeId,
                        principalTable: "HadithTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterTitle = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    ChapterVocabsExplain = table.Column<string>(type: "ntext", nullable: true),
                    ChapterExplainText = table.Column<string>(type: "ntext", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Parts",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HadithsReviews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HadithId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ReviewTermId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HadithsReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HadithsReviews_Hadiths",
                        column: x => x.HadithId,
                        principalTable: "Hadiths",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HadithsReviews_ReviewTerms",
                        column: x => x.ReviewTermId,
                        principalTable: "ReviewTerms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NarratorsChains",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarratorId = table.Column<int>(type: "int", nullable: false),
                    NarratorLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    HadithId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarratorsChains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NarratorsChains_Hadiths",
                        column: x => x.HadithId,
                        principalTable: "Hadiths",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NarratorsChains_NarratorLevels",
                        column: x => x.NarratorLevel,
                        principalTable: "NarratorLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NarratorsChains_Narrators",
                        column: x => x.NarratorId,
                        principalTable: "Narrators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HadithsChapters",
                columns: table => new
                {
                    HadithId = table.Column<long>(type: "bigint", nullable: false),
                    ChapterId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_HadithsChapters_Chapters",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HadithsChapters_Hadiths",
                        column: x => x.HadithId,
                        principalTable: "Hadiths",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_PartId",
                table: "Chapters",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Hadiths_CollectionId",
                table: "Hadiths",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Hadiths_HadithTypeId",
                table: "Hadiths",
                column: "HadithTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HadithsChapters_ChapterId",
                table: "HadithsChapters",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_HadithsChapters_HadithId",
                table: "HadithsChapters",
                column: "HadithId");

            migrationBuilder.CreateIndex(
                name: "IX_HadithsReviews_HadithId",
                table: "HadithsReviews",
                column: "HadithId");

            migrationBuilder.CreateIndex(
                name: "IX_HadithsReviews_ReviewTermId",
                table: "HadithsReviews",
                column: "ReviewTermId");

            migrationBuilder.CreateIndex(
                name: "IX_NarratorsChains_HadithId",
                table: "NarratorsChains",
                column: "HadithId");

            migrationBuilder.CreateIndex(
                name: "IX_NarratorsChains_NarratorId",
                table: "NarratorsChains",
                column: "NarratorId");

            migrationBuilder.CreateIndex(
                name: "IX_NarratorsChains_NarratorLevel",
                table: "NarratorsChains",
                column: "NarratorLevel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HadithsChapters");

            migrationBuilder.DropTable(
                name: "HadithsReviews");

            migrationBuilder.DropTable(
                name: "NarratorsChains");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "ReviewTerms");

            migrationBuilder.DropTable(
                name: "Hadiths");

            migrationBuilder.DropTable(
                name: "NarratorLevels");

            migrationBuilder.DropTable(
                name: "Narrators");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "HadithTypes");
        }
    }
}
