﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskSearchWPF.Models
{
    public partial class TeamSearchContext : DbContext
    {
        public TeamSearchContext()
        {
        }

        public TeamSearchContext(DbContextOptions<TeamSearchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<GameTeam> GameTeams { get; set; } = null!;
        public virtual DbSet<InTeamStatus> InTeamStatuses { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamMember> TeamMembers { get; set; } = null!;
        public virtual DbSet<Tounament> Tounaments { get; set; } = null!;
        public virtual DbSet<TounamentTeam> TounamentTeams { get; set; } = null!;
        public virtual DbSet<TournamentStatus> TournamentStatuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserForm> UserForms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TeamSearch;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.GameId).HasColumnName("Game_ID");

                entity.Property(e => e.GameName).HasMaxLength(50);
            });

            modelBuilder.Entity<GameTeam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Game_Team");

                entity.Property(e => e.GameId).HasColumnName("Game_ID");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game_Team_Game");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game_Team_Team");
            });

            modelBuilder.Entity<InTeamStatus>(entity =>
            {
                entity.ToTable("InTeamStatus");

                entity.Property(e => e.InTeamStatusId).HasColumnName("InTeamStatus_ID");

                entity.Property(e => e.InTeamStatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.Property(e => e.TeamName).HasMaxLength(50);
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => e.TeamMembersId);

                entity.Property(e => e.TeamMembersId).HasColumnName("TeamMembers_ID");

                entity.Property(e => e.InTeamStatusId).HasColumnName("InTeamStatus_ID");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.InTeamStatus)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.InTeamStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamMembers_InTeamStatus");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamMembers_Team");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamMembers_User");
            });

            modelBuilder.Entity<Tounament>(entity =>
            {
                entity.ToTable("Tounament");

                entity.Property(e => e.TounamentId).HasColumnName("Tounament_ID");

                entity.Property(e => e.TournamentName).HasMaxLength(50);

                entity.Property(e => e.TournamentStatusId).HasColumnName("TournamentStatus_ID");

                entity.Property(e => e.TournamentText).HasMaxLength(250);

                entity.HasOne(d => d.TournamentStatus)
                    .WithMany(p => p.Tounaments)
                    .HasForeignKey(d => d.TournamentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tounament_TournamentStatus");
            });

            modelBuilder.Entity<TounamentTeam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tounament_Team");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.Property(e => e.TournamentId).HasColumnName("Tournament_ID");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tounament_Team_Team");

                entity.HasOne(d => d.Tournament)
                    .WithMany()
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tounament_Team_Tounament");
            });

            modelBuilder.Entity<TournamentStatus>(entity =>
            {
                entity.ToTable("TournamentStatus");

                entity.Property(e => e.TournamentStatusId).HasColumnName("TournamentStatus_ID");

                entity.Property(e => e.TournamentStatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserNick).HasMaxLength(50);

                entity.Property(e => e.UserPassword).HasMaxLength(50);

                entity.Property(e => e.UserSurname).HasMaxLength(50);
            });

            modelBuilder.Entity<UserForm>(entity =>
            {
                entity.ToTable("UserForm");

                entity.Property(e => e.UserFormId).HasColumnName("UserForm_ID");

                entity.Property(e => e.FormText).HasMaxLength(500);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserForms)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserForm_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
