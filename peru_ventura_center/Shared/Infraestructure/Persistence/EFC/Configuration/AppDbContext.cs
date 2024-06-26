using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.Entities;
using System.Reflection.Emit;

namespace peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration
{

    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            // Enable Audit Fields Interceptors
            builder.AddCreatedUpdatedInterceptor();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definición de entidades y configuraciones

            // Usuarios
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .Property(u => u.name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(u => u.email)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(u => u.password)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(u => u.phone)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(u => u.userType)
                .IsRequired()
                .HasMaxLength(10);

            // Categorías
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>()
                .Property(c => c.TypeName)
                .IsRequired()
                .HasMaxLength(50);

            // Actividades
            modelBuilder.Entity<Activity>()
                .HasKey(a => a.ActivityId);
            modelBuilder.Entity<Activity>()
                .Property(a => a.ActivityId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Activity>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder.Entity<Activity>()
                .Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder.Entity<Activity>()
                .Property(a => a.Schedule)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder.Entity<Activity>()
                .Property(a => a.MaxPeople)
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(a => a.Cost)
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(a => a.CategoryId)
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.CategoryId);

            // Estados de Reserva
            modelBuilder.Entity<BookingState>()
                .HasKey(bs => bs.booking_state_id);
            modelBuilder.Entity<BookingState>()
                .Property(bs => bs.booking_state_id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<BookingState>()
                .Property(bs => bs.state)
                .IsRequired()
                .HasMaxLength(25);

            // Reservas
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.BookingId);
            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingDate)
                .IsRequired();
            modelBuilder.Entity<Booking>()
                .Property(b => b.ActivityId)
                .IsRequired();
            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingStateId)
                .IsRequired();
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Activity)
                .WithMany()
                .HasForeignKey(b => b.ActivityId);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.BookingState)
                .WithMany()
                .HasForeignKey(b => b.BookingStateId);

            // Destinos de Viaje
            modelBuilder.Entity<DestinationTrip>()
                .HasKey(dt => dt.DestinationTripId);
            modelBuilder.Entity<DestinationTrip>()
                .Property(dt => dt.DestinationTripId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<DestinationTrip>()
                .Property(dt => dt.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder.Entity<DestinationTrip>()
                .Property(dt => dt.Description)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder.Entity<DestinationTrip>()
                .Property(dt => dt.Location)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder.Entity<DestinationTrip>()
                .Property(dt => dt.ActivityId)
                .IsRequired();
            modelBuilder.Entity<DestinationTrip>()
                .HasOne(dt => dt.Activity)
                .WithMany()
                .HasForeignKey(dt => dt.ActivityId);

            // Promociones
            modelBuilder.Entity<Promotion>()
                .HasKey(p => p.PromotionId);
            modelBuilder.Entity<Promotion>()
                .Property(p => p.PromotionId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Promotion>()
                .Property(p => p.DestinationTripId)
                .IsRequired();
            modelBuilder.Entity<Promotion>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Promotion>()
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Promotion>()
                .Property(p => p.Offer)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Promotion>()
                .HasOne(p => p.DestinationTrip)
                .WithMany()
                .HasForeignKey(p => p.DestinationTripId);

            // Dueños
            modelBuilder.Entity<Owner>()
                .HasKey(o => o.OwnerId);
            modelBuilder.Entity<Owner>()
                .Property(o => o.OwnerId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Owner>()
                .Property(o => o.UserId)
                .IsRequired();
            modelBuilder.Entity<Owner>()
                .Property(o => o.PromotionId);
            modelBuilder.Entity<Owner>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);
            modelBuilder.Entity<Owner>()
                .HasOne(o => o.Promotion)
                .WithMany()
                .HasForeignKey(o => o.PromotionId);

            // Reseñas
            modelBuilder.Entity<Review>()
                .HasKey(r => r.ReviewId);
            modelBuilder.Entity<Review>()
                .Property(r => r.ReviewId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Review>()
                .Property(r => r.Score)
                .IsRequired();
            modelBuilder.Entity<Review>()
                .Property(r => r.Comment)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder.Entity<Review>()
                .Property(r => r.ActivityId)
                .IsRequired();
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Activity)
                .WithMany()
                .HasForeignKey(r => r.ActivityId);

            // Estados de Pago
            modelBuilder.Entity<PaymentState>()
                .HasKey(ps => ps.PaymentStateId);
            modelBuilder.Entity<PaymentState>()
                .Property(ps => ps.PaymentStateId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<PaymentState>()
                .Property(ps => ps.State)
                .IsRequired()
                .HasMaxLength(10);

            // Tipos de Pago
            modelBuilder.Entity<PaymentType>()
                .HasKey(pt => pt.PaymentTypeId);
            modelBuilder.Entity<PaymentType>()
                .Property(pt => pt.PaymentTypeId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<PaymentType>()
                .Property(pt => pt.Type)
                .IsRequired()
                .HasMaxLength(50);

            // Pagos
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentId);
            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .IsRequired();
            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentDate)
                .IsRequired();
            modelBuilder.Entity<Payment>()
                .Property(p => p.BookingId)
                .IsRequired();
            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentTypeId)
                .IsRequired();
            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentStateId)
                .IsRequired();
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithMany()
                .HasForeignKey(p => p.BookingId);
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaymentType)
                .WithMany()
                .HasForeignKey(p => p.PaymentTypeId);
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaymentState)
                .WithMany()
                .HasForeignKey(p => p.PaymentStateId);

            // Turistas
            modelBuilder.Entity<Tourist>()
                .HasKey(t => t.TouristId);
            modelBuilder.Entity<Tourist>()
                .Property(t => t.TouristId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Tourist>()
                .Property(t => t.UserId)
                .IsRequired();
            modelBuilder.Entity<Tourist>()
                .Property(t => t.ReviewId);
            modelBuilder.Entity<Tourist>()
                .Property(t => t.BookingId);
            modelBuilder.Entity<Tourist>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId);
            modelBuilder.Entity<Tourist>()
                .HasOne(t => t.Review)
                .WithMany()
                .HasForeignKey(t => t.ReviewId)
                .IsRequired(false);
            modelBuilder.Entity<Tourist>()
                .HasOne(t => t.Booking)
                .WithMany()
                .HasForeignKey(t => t.BookingId)
                .IsRequired(false);
            //SnakeCase
            modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
