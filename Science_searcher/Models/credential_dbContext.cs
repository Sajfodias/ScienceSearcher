using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Science_searcher.Models
{
    public partial class credential_dbContext : DbContext
    {
        public credential_dbContext()
        {
        }

        public credential_dbContext(DbContextOptions<credential_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TUserPwdGen> TUserPwdGen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=credential_db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TUserPwdGen>(entity =>
            {
                entity.ToTable("t_UserPwdGen");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .IsUnicode(false);
            });
        }
    }
}
