using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.Entities;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

    

            builder.Entity<Promotion>().HasKey(p => p.PromotionId);
            builder.Entity<Promotion>().Property(p => p.PromotionId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Promotion>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Promotion>().Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Entity<Promotion>().Property(p => p.Offer).IsRequired().HasMaxLength(100);
            builder.Entity<Promotion>().Property(p => p.DestinationTripId).IsRequired();




            builder.Entity<User>().HasKey(u => u.UserId);
            builder.Entity<User>().Property(u => u.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.name).IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property( u => u.email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(u => u.password).IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(u => u.phone).IsRequired().HasMaxLength(50);

            builder.Entity<Owner>().HasKey(o => o.OwnerId);
            builder.Entity<Owner>().Property(o => o.OwnerId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Owner>().Property(o => o.UserId).IsRequired();
            
            builder.Entity<Tourist>().HasKey(t => t.TouristId);
            builder.Entity<Tourist>().Property(t => t.TouristId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tourist>().Property(t => t.UserId).IsRequired();
            builder.Entity<Tourist>().Property(t => t.ReviewId).IsRequired();
            builder.Entity<Tourist>().Property(t => t.BookingId).IsRequired();


            builder.Entity<Activity>().Property(a => a.ActivityId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Activity>().Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Activity>().Property(a => a.Description).IsRequired().HasMaxLength(500);
            builder.Entity<Activity>().Property(a => a.Schedule).IsRequired().HasMaxLength(50);
            builder.Entity<Activity>().Property(a => a.MaxPeople).IsRequired();
            builder.Entity<Activity>().Property(a => a.Cost).IsRequired();
            builder.Entity<Activity>().Property(a => a.CategoryId).IsRequired();

            builder.Entity<Category>().HasKey(c => c.CategoryId);
            builder.Entity<Category>().Property(c => c.CategoryId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(c => c.TypeName).IsRequired().HasMaxLength(100);

            builder.Entity<Review>().HasKey(r => r.ReviewId);
            builder.Entity<Review>().Property(r => r.ReviewId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(r => r.Score).IsRequired();
            builder.Entity<Review>().Property(r => r.Comment).IsRequired().HasMaxLength(500);
            builder.Entity<Review>().Property(r => r.ActivityId).IsRequired(); 

            builder.Entity<DestinationTrip>().HasKey(d => d.DestinationTripId);
            builder.Entity<DestinationTrip>().Property(d => d.DestinationTripId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<DestinationTrip>().Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Entity<DestinationTrip>().Property(d => d.Description).IsRequired().HasMaxLength(500);
            builder.Entity<DestinationTrip>().Property(d => d.Location).IsRequired().HasMaxLength(50);
            builder.Entity<DestinationTrip>().Property(d => d.ActivityId).IsRequired();

            builder.Entity<Booking>().HasKey(b => b.BookingId);
            builder.Entity<Booking>().Property(b => b.BookingId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Booking>().Property(b => b.BookingDate).IsRequired();
            builder.Entity<Booking>().Property(b => b.ActivityId).IsRequired();
            builder.Entity<Booking>().Property(b => b.BookingStateId).IsRequired();

            builder.Entity<BookingState>().HasKey(e => e.booking_state_id);
            builder.Entity<BookingState>().Property(e => e.booking_state_id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Payment>().HasKey(p => p.PaymentId);
            builder.Entity<Payment>().Property(p => p.PaymentId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.Amount).IsRequired();
            builder.Entity<Payment>().Property(d => d.PaymentDate).IsRequired();
            builder.Entity<Payment>().Property(d => d.PaymentTypeId).IsRequired();
            builder.Entity<Payment>().Property(d => d.PaymentStateId).IsRequired();

            builder.Entity<PaymentState>().HasKey(s => s.PaymentStateId);
            builder.Entity<PaymentState>().Property(s => s.PaymentStateId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PaymentState>().Property(s => s.State).IsRequired().HasMaxLength(20);

            builder.Entity<PaymentType>().HasKey(t => t.PaymentTypeId);
            builder.Entity<PaymentType>().Property(t => t.PaymentTypeId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PaymentType>().Property(t => t.Type).IsRequired();
            //SnakeCase
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
