using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NovaKeep.Models
{
    public partial class NovaKeepDbContext : DbContext
    {
        public NovaKeepDbContext()
        {
        }

        public NovaKeepDbContext(DbContextOptions<NovaKeepDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CharacterTable> CharacterTable { get; set; }
        public virtual DbSet<Characters> Characters { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=NovaKeep;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterTable>(entity =>
            {
                entity.HasKey(e => e.CharacterId)
                    .HasName("PK__Characte__3213E83F5A478DDB");

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Hometown).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.UserAccountedId).IsUnicode(false);

                entity.Property(e => e.Weapon).IsUnicode(false);
            });

            modelBuilder.Entity<Characters>(entity =>
            {
                entity.HasKey(e => e.CharacterId)
                    .HasName("PK__Characte__11D7652E1C071C5D");

                entity.Property(e => e.FirstName)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Hometown).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.UserAccountedId).IsUnicode(false);

                entity.Property(e => e.Weapon).IsUnicode(false);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Characters_Teams");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("PK__Games__FFE11FCF7137FB0C");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GameName)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId)
                    .HasName("PK__Teams__F82DEDBC94320643");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TeamName)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teams_Games");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
