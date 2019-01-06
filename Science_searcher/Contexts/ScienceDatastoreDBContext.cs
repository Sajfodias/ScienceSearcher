using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Science_searcher.Model
{
    public partial class ScienceDatastoreDBContext : DbContext
    {
        public ScienceDatastoreDBContext()
        {
        }

        public ScienceDatastoreDBContext(DbContextOptions<ScienceDatastoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TArticles> TArticles { get; set; }
        public virtual DbSet<TArticlesAuthorsIndex> TArticlesAuthorsIndex { get; set; }
        public virtual DbSet<TAuthors> TAuthors { get; set; }
        public virtual DbSet<TOutputFiles> TOutputFiles { get; set; }
        public virtual DbSet<TProcessedUrl> TProcessedUrl { get; set; }
        public virtual DbSet<TSession> TSession { get; set; }
        public virtual DbSet<TUrlsToProcess> TUrlsToProcess { get; set; }
        public virtual DbSet<TUserSession> TUserSession { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=science_datastore;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TArticles>(entity =>
            {
                entity.Property(e => e.AbstractText).IsUnicode(false);

                entity.Property(e => e.AuthorsLine).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.DateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Keywords).IsUnicode(false);

                entity.Property(e => e.Organizations).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);
            });

            modelBuilder.Entity<TAuthors>(entity =>
            {
                entity.Property(e => e.AuthorName).IsUnicode(false);

                entity.Property(e => e.AuthorSurename).IsUnicode(false);

                entity.Property(e => e.DateTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TOutputFiles>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DownloadDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileName).IsUnicode(false);

                entity.Property(e => e.SourceUrl).IsUnicode(false);
            });

            modelBuilder.Entity<TProcessedUrl>(entity =>
            {
                entity.Property(e => e.ProcessedUrl).IsUnicode(false);

                entity.Property(e => e.ProcessingDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TSession>(entity =>
            {
                entity.Property(e => e.RaportFilePath).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);
            });

            modelBuilder.Entity<TUrlsToProcess>(entity =>
            {
                entity.Property(e => e.NewUrl).IsUnicode(false);

                entity.Property(e => e.ParentUrl).IsUnicode(false);
            });

            modelBuilder.Entity<TUserSession>(entity =>
            {
                entity.Property(e => e.UserName).IsUnicode(false);
            });
        }
    }
}
