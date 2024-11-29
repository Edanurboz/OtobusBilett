using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BiletOtomasyonu:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=LAPTOP-8F99LGJR\MSSQLSERVER02;Database=BiletOtomasyonu;Trusted_Connection=true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.user_id);

                entity.Property(u => u.name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.surname)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.email)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.passwordHash)
                      .IsRequired()
                      .HasMaxLength(64);

                entity.Property(u => u.passwordSalt)
                      .IsRequired()
                      .HasMaxLength(64);

                entity.Property(u => u.status)
                     .IsRequired();
                     

                entity.Property(u => u.phone_number)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.HasMany(u => u.Tickets)
                      .WithOne(t => t.User)
                      .HasForeignKey(t => t.user_id)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Ticket Entity
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.ticket_id);

                entity.Property(t => t.seat_number)
                      .IsRequired();

                entity.Property(t => t.is_cancelled)
                      .IsRequired();

                entity.HasOne(t => t.Trip)
                      .WithMany(tr => tr.Tickets)
                      .HasForeignKey(t => t.trip_id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.User)
                      .WithMany(u => u.Tickets)
                      .HasForeignKey(t => t.user_id)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Trip Entity
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(tr => tr.trip_id);

                entity.Property(tr => tr.departure_city)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(tr => tr.arrival_city)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(tr => tr.departure_time)
                      .IsRequired();

                entity.Property(tr => tr.price)
                      .IsRequired();

                entity.HasMany(tr => tr.Tickets)
                      .WithOne(t => t.Trip)
                      .HasForeignKey(t => t.trip_id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(tr => tr.Seats)
                      .WithOne(s => s.Trip)
                      .HasForeignKey(s => s.trip_id)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Seat Entity
            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(s => s.seat_id);

                entity.Property(s => s.seat_number)
                      .IsRequired();

                entity.Property(s => s.is_reserved)
                      .IsRequired();

                entity.HasOne(s => s.Trip)
                      .WithMany(tr => tr.Seats)
                      .HasForeignKey(s => s.trip_id)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
