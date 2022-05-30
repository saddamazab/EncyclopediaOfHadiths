using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EncyclopediaOfHadiths.Models
{
    public partial class EncyclopediaOfHadithsContext : DbContext
    {
        public EncyclopediaOfHadithsContext()
        {
        }

        public EncyclopediaOfHadithsContext(DbContextOptions<EncyclopediaOfHadithsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chapter>? Chapters { get; set; } 
        public virtual DbSet<Collection>? Collections { get; set; } 
        public virtual DbSet<Hadith>? Hadiths { get; set; } 
        public virtual DbSet<HadithType>? HadithTypes { get; set; } 
        public virtual DbSet<HadithsChapter>? HadithsChapters { get; set; } 
        public virtual DbSet<HadithsReview>? HadithsReviews { get; set; } 
        public virtual DbSet<Narrator>? Narrators { get; set; } 
        public virtual DbSet<NarratorLevel>? NarratorLevels { get; set; } 
        public virtual DbSet<NarratorsChain>? NarratorsChains { get; set; } 
        public virtual DbSet<Part>? Parts { get; set; } 
        public virtual DbSet<ReviewTerm>? ReviewTerms { get; set; }
        public virtual DbSet<HadithsHashTag>? HadithsHashTags { get; set; }
        public virtual DbSet<HashTag>? HashTags { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=professor;Initial Catalog=EncyclopediaOfHadiths;Persist Security Info=True;User ID=sa;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chapter>(entity =>
            {
                /*
                entity.Property(e => e.ChapterExplainText).HasColumnType("ntext");

                entity.Property(e => e.ChapterTitle)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.ChapterVocabsExplain).HasColumnType("ntext");
                */
                entity.HasOne(d => d.Part)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            /*
            modelBuilder.Entity<Collection>(entity =>
            {
                entity.Property(e => e.CollectionAuthor)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.CollectionTitle)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });
            */
            modelBuilder.Entity<Hadith>(entity =>
            {
                /*
                entity.Property(e => e.HadithText).HasColumnType("ntext");

                entity.Property(e => e.VocabsExplain).HasColumnType("ntext");
                */

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.Hadiths)
                    .HasForeignKey(d => d.CollectionId);
                //.HasConstraintName("FK_Hadiths_Collections");

                entity.HasOne(d => d.HadithType)
                    .WithMany(p => p.Hadiths)
                    .HasForeignKey(d => d.HadithTypeId);
                    //.HasConstraintName("FK_Hadiths_HadithTypes");
            });
            /*
            modelBuilder.Entity<HadithType>(entity =>
            {
                entity.Property(e => e.HadithTypeTitle)
                    .HasMaxLength(50)
                    .HasColumnName("HadithType")
                    .IsFixedLength();

                entity.Property(e => e.HadithTypeNote).HasColumnType("ntext");
            });
            */
            modelBuilder.Entity<HadithsChapter>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Chapter)
                    .WithMany()
                    .HasForeignKey(d => d.ChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("FK_HadithsChapters_Chapters");

                entity.HasOne(d => d.Hadith)
                    .WithMany()
                    .HasForeignKey(d => d.HadithId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                    //.HasConstraintName("FK_HadithsChapters_Hadiths");
            });

            modelBuilder.Entity<HadithsReview>(entity =>
            {
                entity.HasOne(d => d.Hadith)
                    .WithMany(p => p.HadithsReviews)
                    .HasForeignKey(d => d.HadithId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("FK_HadithsReviews_Hadiths");

                entity.HasOne(d => d.ReviewTerm)
                    .WithMany(p => p.HadithsReviews)
                    .HasForeignKey(d => d.ReviewTermId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                    //.HasConstraintName("FK_HadithsReviews_ReviewTerms");
            });
            /*
            modelBuilder.Entity<Narrator>(entity =>
            {
                entity.Property(e => e.NarratorDied).HasColumnType("date");

                entity.Property(e => e.NarratorInfo).HasColumnType("ntext");

                entity.Property(e => e.NarratorName)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.NarratorNote).HasColumnType("ntext");

                entity.Property(e => e.NarratorWasBorned).HasColumnType("date");
            });
            */
            modelBuilder.Entity<NarratorsChain>(entity =>
            {
                entity.HasOne(d => d.Hadith)
                    .WithMany(p => p.NarratorsChains)
                    .HasForeignKey(d => d.HadithId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("FK_NarratorsChains_Hadiths");

                entity.HasOne(d => d.Narrator)
                    .WithMany(p => p.NarratorsChains)
                    .HasForeignKey(d => d.NarratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("FK_NarratorsChains_Narrators");

                entity.HasOne(d => d.NarratorLevelNavigation)
                    .WithMany(p => p.NarratorsChains)
                    .HasForeignKey(d => d.NarratorLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                    //.HasConstraintName("FK_NarratorsChains_NarratorLevels");
            });
            /*
            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PartTitle)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });
            
            modelBuilder.Entity<ReviewTerm>(entity =>
            {
                entity.Property(e => e.StatusTerm)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });
            */
            modelBuilder.Entity<HadithsHashTag>(entity =>
            {
                entity.HasOne(d => d.Hadith)
                    .WithMany(p => p.HadithsHashTags)
                    .HasForeignKey(d => d.HadithId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.HashTag)
                    .WithMany(p => p.HadithsHashTags)
                    .HasForeignKey(d => d.HashTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("FK_HadithsReviews_ReviewTerms");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
