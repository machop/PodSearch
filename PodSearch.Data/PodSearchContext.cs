using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PodSearch.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PodSearch.Models
{
    public class PodSearchContext : DbContext
    {
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Transcription> Transcriptions { get; set; }

        public PodSearchContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Podcast>()
                .ToTable("Podcast");

            modelBuilder.Entity<Podcast>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Podcast>()
                .Property(s => s.Id)
                .IsRequired();

            modelBuilder.Entity<Podcast>()
                .HasMany(p => p.Episodes);

            modelBuilder.Entity<Episode>()
                .ToTable("Episode");

            modelBuilder.Entity<Episode>()
                .Property(s => s.Id)
                .IsRequired();

            modelBuilder.Entity<Episode>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Episode>()
                .HasMany(p => p.Transcriptions);

            modelBuilder.Entity<Episode>()
                .HasOne(t => t.Podcast)
                .WithMany(b => b.Episodes)
                .HasForeignKey(p => p.PodcastId);

            modelBuilder.Entity<Transcription>()
                .ToTable("Transcription");

            modelBuilder.Entity<Transcription>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Transcription>()
                .HasOne(t => t.Episode)
                .WithMany(b => b.Transcriptions)
                .HasForeignKey(p => p.EpisodeId);

            modelBuilder.Entity<Transcription>()
                .Property(s => s.Id)
                .IsRequired();
        }
    }
}
