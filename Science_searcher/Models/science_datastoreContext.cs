using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Science_searcher.Models
{
    public partial class science_datastoreContext : DbContext
    {
        public science_datastoreContext()
        {
        }

        public science_datastoreContext(DbContextOptions<science_datastoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TArticles> TArticles { get; set; }
        public virtual DbSet<TArticlesAuthorsIndex> TArticlesAuthorsIndex { get; set; }
        public virtual DbSet<TAuthors> TAuthors { get; set; }
        public virtual DbSet<TSession> TSession { get; set; }
        public virtual DbSet<TUserSession> TUserSession { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=science_datastore;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TArticles>(entity =>
            {
                entity.ToTable("t_Articles");

                entity.Property(e => e.AbstractText).IsUnicode(false);

                entity.Property(e => e.AuthorsLine).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Keywords).IsUnicode(false);

                entity.Property(e => e.Organizations).IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);
            });

            modelBuilder.Entity<TArticlesAuthorsIndex>(entity =>
            {
                entity.ToTable("t_Articles_Authors_Index");

                entity.Property(e => e.ArticleId).HasColumnName("Article_Id");

                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");
            });

            modelBuilder.Entity<TAuthors>(entity =>
            {
                entity.ToTable("t_Authors");

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AuthorSurename)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TSession>(entity =>
            {
                entity.ToTable("t_Session");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateStart).HasColumnType("datetime");

                entity.Property(e => e.RaportFilePath).IsUnicode(false);

                entity.Property(e => e.SessionId).HasColumnName("Session_Id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUserSession>(entity =>
            {
                entity.ToTable("t_UserSession");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .IsUnicode(false);

                entity.Property(e => e.UserSession).HasColumnName("userSession");
            });
        }
    }
}
