﻿// <auto-generated />
using System;
using EncyclopediaOfHadiths.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EncyclopediaOfHadiths.Migrations
{
    [DbContext(typeof(EncyclopediaOfHadithsContext))]
    [Migration("20220416141134_tryAnnotation3")]
    partial class tryAnnotation3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Chapter", b =>
                {
                    b.Property<long>("ChapterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ChapterId"), 1L, 1);

                    b.Property<string>("ChapterExplainText")
                        .HasColumnType("ntext");

                    b.Property<string>("ChapterTitle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ChapterVocabsExplain")
                        .HasColumnType("ntext");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.HasKey("ChapterId");

                    b.HasIndex("PartId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Collection", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("CollectionAuthor")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("CollectionTitle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Hadith", b =>
                {
                    b.Property<long>("HadithId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("HadithId"), 1L, 1);

                    b.Property<byte?>("CollectionId")
                        .HasColumnType("tinyint");

                    b.Property<int?>("HadithNo")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("HadithText")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<byte?>("HadithTypeId")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("ReviewTermId")
                        .HasColumnType("tinyint");

                    b.Property<string>("VocabsExplain")
                        .HasColumnType("ntext");

                    b.HasKey("HadithId");

                    b.HasIndex("CollectionId");

                    b.HasIndex("HadithTypeId");

                    b.ToTable("Hadiths");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.HadithsChapter", b =>
                {
                    b.Property<long>("ChapterId")
                        .HasColumnType("bigint");

                    b.Property<long>("HadithId")
                        .HasColumnType("bigint");

                    b.HasIndex("ChapterId");

                    b.HasIndex("HadithId");

                    b.ToTable("HadithsChapters");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.HadithsReview", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("HadithId")
                        .HasColumnType("bigint");

                    b.Property<byte>("ReviewTermId")
                        .HasColumnType("tinyint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("HadithId");

                    b.HasIndex("ReviewTermId");

                    b.ToTable("HadithsReviews");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.HadithType", b =>
                {
                    b.Property<byte>("HadithTypeId")
                        .HasColumnType("tinyint");

                    b.Property<string>("HadithTypeNote")
                        .HasColumnType("ntext");

                    b.Property<string>("HadithTypeTitle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("HadithTypeId");

                    b.ToTable("HadithTypes");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Narrator", b =>
                {
                    b.Property<int>("NarratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NarratorId"), 1L, 1);

                    b.Property<DateTime?>("NarratorDied")
                        .HasColumnType("datetime2");

                    b.Property<string>("NarratorInfo")
                        .HasColumnType("ntext");

                    b.Property<string>("NarratorName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("NarratorNote")
                        .HasColumnType("ntext");

                    b.Property<DateTime?>("NarratorWasBorned")
                        .HasColumnType("datetime2");

                    b.HasKey("NarratorId");

                    b.ToTable("Narrators");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.NarratorLevel", b =>
                {
                    b.Property<byte>("NarratorLevelId")
                        .HasColumnType("tinyint");

                    b.HasKey("NarratorLevelId");

                    b.ToTable("NarratorLevels");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.NarratorsChain", b =>
                {
                    b.Property<long>("NarratorsChainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("NarratorsChainId"), 1L, 1);

                    b.Property<long>("HadithId")
                        .HasColumnType("bigint");

                    b.Property<int>("NarratorId")
                        .HasColumnType("int");

                    b.Property<byte>("NarratorLevel")
                        .HasColumnType("tinyint");

                    b.HasKey("NarratorsChainId");

                    b.HasIndex("HadithId");

                    b.HasIndex("NarratorId");

                    b.HasIndex("NarratorLevel");

                    b.ToTable("NarratorsChains");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("PartTitle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.ReviewTerm", b =>
                {
                    b.Property<byte>("ReviewTermId")
                        .HasColumnType("tinyint");

                    b.Property<string>("StatusTerm")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ReviewTermId");

                    b.ToTable("ReviewTerms");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Chapter", b =>
                {
                    b.HasOne("EncyclopediaOfHadiths.Models.Part", "Part")
                        .WithMany("Chapters")
                        .HasForeignKey("PartId")
                        .IsRequired();

                    b.Navigation("Part");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Hadith", b =>
                {
                    b.HasOne("EncyclopediaOfHadiths.Models.Collection", "Collection")
                        .WithMany("Hadiths")
                        .HasForeignKey("CollectionId");

                    b.HasOne("EncyclopediaOfHadiths.Models.HadithType", "HadithType")
                        .WithMany("Hadiths")
                        .HasForeignKey("HadithTypeId");

                    b.Navigation("Collection");

                    b.Navigation("HadithType");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.HadithsChapter", b =>
                {
                    b.HasOne("EncyclopediaOfHadiths.Models.Chapter", "Chapter")
                        .WithMany()
                        .HasForeignKey("ChapterId")
                        .IsRequired();

                    b.HasOne("EncyclopediaOfHadiths.Models.Hadith", "Hadith")
                        .WithMany()
                        .HasForeignKey("HadithId")
                        .IsRequired();

                    b.Navigation("Chapter");

                    b.Navigation("Hadith");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.HadithsReview", b =>
                {
                    b.HasOne("EncyclopediaOfHadiths.Models.Hadith", "Hadith")
                        .WithMany("HadithsReviews")
                        .HasForeignKey("HadithId")
                        .IsRequired();

                    b.HasOne("EncyclopediaOfHadiths.Models.ReviewTerm", "ReviewTerm")
                        .WithMany("HadithsReviews")
                        .HasForeignKey("ReviewTermId")
                        .IsRequired();

                    b.Navigation("Hadith");

                    b.Navigation("ReviewTerm");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.NarratorsChain", b =>
                {
                    b.HasOne("EncyclopediaOfHadiths.Models.Hadith", "Hadith")
                        .WithMany("NarratorsChains")
                        .HasForeignKey("HadithId")
                        .IsRequired();

                    b.HasOne("EncyclopediaOfHadiths.Models.Narrator", "Narrator")
                        .WithMany("NarratorsChains")
                        .HasForeignKey("NarratorId")
                        .IsRequired();

                    b.HasOne("EncyclopediaOfHadiths.Models.NarratorLevel", "NarratorLevelNavigation")
                        .WithMany("NarratorsChains")
                        .HasForeignKey("NarratorLevel")
                        .IsRequired();

                    b.Navigation("Hadith");

                    b.Navigation("Narrator");

                    b.Navigation("NarratorLevelNavigation");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Collection", b =>
                {
                    b.Navigation("Hadiths");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Hadith", b =>
                {
                    b.Navigation("HadithsReviews");

                    b.Navigation("NarratorsChains");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.HadithType", b =>
                {
                    b.Navigation("Hadiths");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Narrator", b =>
                {
                    b.Navigation("NarratorsChains");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.NarratorLevel", b =>
                {
                    b.Navigation("NarratorsChains");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.Part", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("EncyclopediaOfHadiths.Models.ReviewTerm", b =>
                {
                    b.Navigation("HadithsReviews");
                });
#pragma warning restore 612, 618
        }
    }
}