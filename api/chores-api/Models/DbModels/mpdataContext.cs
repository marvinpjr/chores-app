using System;
using ChoresApi.Models.Other;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace ChoresApi.Models.DbModels
{
    public partial class mpdataContext : DbContext
    {
        private AppConfiguration _appConfig;

        public mpdataContext(IOptions<AppConfiguration> appConfig)
        {
            _appConfig = appConfig.Value;
        }

        public mpdataContext(DbContextOptions<mpdataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountRecords> AccountRecords { get; set; }
        public virtual DbSet<Achievements> Achievements { get; set; }
        public virtual DbSet<Chores> Chores { get; set; }
        public virtual DbSet<Relationships> Relationships { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<UserAchievements> UserAchievements { get; set; }
        public virtual DbSet<UserChores> UserChores { get; set; }
        public virtual DbSet<UserRelationships> UserRelationships { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_appConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountRecords>(entity =>
            {
                entity.HasKey(e => e.AccountRecordId);

                entity.Property(e => e.Amount).HasColumnType("smallmoney");

                entity.Property(e => e.Balance).HasColumnType("smallmoney");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AccountRecords)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountRecords_Users");
            });

            modelBuilder.Entity<Achievements>(entity =>
            {
                entity.HasKey(e => e.AchievementId);

                entity.Property(e => e.ChoreRaise).HasColumnType("smallmoney");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OneTimeBonusPay).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<Chores>(entity =>
            {
                entity.HasKey(e => e.ChoreId);

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pay).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<Relationships>(entity =>
            {
                entity.HasKey(e => e.RelationshipId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserAchievements>(entity =>
            {
                entity.HasKey(e => e.UserAchievementId);

                entity.HasOne(d => d.Achievement)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.AchievementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAchievements_Achievements");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAchievements_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAchievements_Users");
            });

            modelBuilder.Entity<UserChores>(entity =>
            {
                entity.HasKey(e => e.UserChoreId);

                entity.HasOne(d => d.Chore)
                    .WithMany(p => p.UserChores)
                    .HasForeignKey(d => d.ChoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserChores_Chores");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.UserChores)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserChores_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserChores)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserChores_Users");
            });

            modelBuilder.Entity<UserRelationships>(entity =>
            {
                entity.HasKey(e => e.UserRelationshipId);

                entity.HasOne(d => d.FirstUser)
                    .WithMany(p => p.UserRelationshipsFirstUser)
                    .HasForeignKey(d => d.FirstUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRelationships_FirstUsers");

                entity.HasOne(d => d.Relationship)
                    .WithMany(p => p.UserRelationships)
                    .HasForeignKey(d => d.RelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRelationships_Relationships");

                entity.HasOne(d => d.SecondUser)
                    .WithMany(p => p.UserRelationshipsSecondUser)
                    .HasForeignKey(d => d.SecondUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRelationships_SecondUsers");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
