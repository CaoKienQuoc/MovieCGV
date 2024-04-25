using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Datalayer
{
    public partial class MovieTheaterCGVContext : DbContext
    {
        public MovieTheaterCGVContext()
        {
        }

        public MovieTheaterCGVContext(DbContextOptions<MovieTheaterCGVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketDetail> TicketDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetconnectionString());
            }
        }

        private string GetconnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config.GetConnectionString("MovieDb");

            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.IdentityCard)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("identity_card");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasColumnName("register_date");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.Actor)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("actor");

                entity.Property(e => e.CinemaRoomId).HasColumnName("cinema_room_id");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.Director)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("director");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.LargeImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("large_image");

                entity.Property(e => e.MovieNameEnglish)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("movie_name_english");

                entity.Property(e => e.MovieNameVn)
                    .HasMaxLength(255)
                    .HasColumnName("movie_name_vn");

                entity.Property(e => e.MovieProductionCompamy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("movie_production_compamy");

                entity.Property(e => e.SmallImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("small_image");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("seat");

                entity.Property(e => e.SeatId).HasColumnName("seat_id");

                entity.Property(e => e.SeatColumn)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("seat_column");

                entity.Property(e => e.SeatRow).HasColumnName("seat_row");

                entity.Property(e => e.SeatStatus).HasColumnName("seat_status");

                entity.Property(e => e.SeatType).HasColumnName("seat_type");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TicketDetailsId).HasColumnName("ticketDetails_id");

                entity.Property(e => e.TicketType).HasColumnName("ticket_type");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_ticket_account");

                entity.HasOne(d => d.TicketDetails)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TicketDetailsId)
                    .HasConstraintName("FK_ticket_ticketDetails");
            });

            modelBuilder.Entity<TicketDetail>(entity =>
            {
                entity.HasKey(e => e.TicketDetailsId)
                    .HasName("PK__ticketDe__7B099B6FD4CB084F");

                entity.ToTable("ticketDetails");

                entity.Property(e => e.TicketDetailsId).HasColumnName("ticketDetails_id");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.SeatId).HasColumnName("seat_id");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.TicketDetails)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ticketDetails_food");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.TicketDetails)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ticketDetails_movie");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.TicketDetails)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ticketDetails_seat");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
