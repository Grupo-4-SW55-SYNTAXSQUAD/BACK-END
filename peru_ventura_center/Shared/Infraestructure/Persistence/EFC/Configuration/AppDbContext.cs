using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using peru_ventura_center.Publishing.Domain.Model.Aggregates;
using peru_ventura_center.Publishing.Domain.Model.Entities;

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
            builder.Entity<Promotion>().Property(p => p.PromotionId).ValueGeneratedOnAdd();
            builder.Entity<Promotion>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Promotion>().Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Entity<Promotion>().Property(p => p.Offer).IsRequired().HasMaxLength(100);
            builder.Entity<Promotion>().Property(p => p.DestinationTripId).IsRequired();




            builder.Entity<usuario>().HasKey(u => u.UsuarioId);
            builder.Entity<usuario>().Property(u => u.UsuarioId).ValueGeneratedOnAdd();
            builder.Entity<usuario>().Property(u => u.nombre).IsRequired().HasMaxLength(100);
            builder.Entity<usuario>().OwnsOne(
             u => u.CorreoElectronico,
             e =>
             {
                 e.Property<string>("Address")
                     .HasColumnName("correoElectronico")
                     .IsRequired()
                     .HasMaxLength(100);
             });
            builder.Entity<usuario>().Property(u => u.contrasenia).IsRequired().HasMaxLength(100);
            builder.Entity<usuario>().Property(u => u.ubicacion).IsRequired().HasMaxLength(50);

            builder.Entity<Activity>().Property(a => a.ActivityId).ValueGeneratedOnAdd();
            builder.Entity<Activity>().Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Activity>().Property(a => a.Description).IsRequired().HasMaxLength(500);
            builder.Entity<Activity>().Property(a => a.Schedule).IsRequired().HasMaxLength(50);
            builder.Entity<Activity>().Property(a => a.MaxPeople).IsRequired();
            builder.Entity<Activity>().Property(a => a.Cost).IsRequired();
            builder.Entity<Activity>().Property(a => a.CategoryId).IsRequired();

            builder.Entity<Category>().HasKey(c => c.CategoryId);
            builder.Entity<Category>().Property(c => c.CategoryId).ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(c => c.TypeName).IsRequired().HasMaxLength(100);

            builder.Entity<Review>().HasKey(r => r.ReviewId);
            builder.Entity<Review>().Property(r => r.ReviewId).ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(r => r.Score).IsRequired();
            builder.Entity<Review>().Property(r => r.Comment).IsRequired().HasMaxLength(500);
            builder.Entity<Review>().Property(r => r.ActivityId).IsRequired(); 

            builder.Entity<DestinationTrip>().HasKey(d => d.DestinationTripId);
            builder.Entity<DestinationTrip>().Property(d => d.DestinationTripId).ValueGeneratedOnAdd();
            builder.Entity<DestinationTrip>().Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Entity<DestinationTrip>().Property(d => d.Description).IsRequired().HasMaxLength(500);
            builder.Entity<DestinationTrip>().Property(d => d.Location).IsRequired().HasMaxLength(50);
            builder.Entity<DestinationTrip>().Property(d => d.ActivityId).IsRequired();
            //SnakeCase
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
