using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.publishing.Domain.Model.Aggregates;
using peru_ventura_center.publishing.Domain.Model.Entities;

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

            builder.Entity<comunidad>().HasKey(c => c.ComunidadId);
            builder.Entity<comunidad>().Property(c => c.ComunidadId).ValueGeneratedOnAdd();
            builder.Entity<comunidad>().Property(c => c.nombre).IsRequired().HasMaxLength(100);
            builder.Entity<comunidad>().Property(c => c.descripcion).IsRequired().HasMaxLength(500);
            builder.Entity<comunidad>().Property(c => c.cultura).IsRequired().HasMaxLength(10);

            builder.Entity<promociones>().HasKey(p => p.PromocionId);
            builder.Entity<promociones>().Property(p => p.PromocionId).ValueGeneratedOnAdd();
            builder.Entity<promociones>().Property(p => p.nombre).IsRequired().HasMaxLength(100);
            builder.Entity<promociones>().Property(p => p.descripcion).IsRequired().HasMaxLength(500);
            builder.Entity<promociones>().Property(p => p.ComunidadId).IsRequired();
            builder.Entity<promociones>().Property(p => p.TallerId).IsRequired();
            builder.Entity<promociones>().Property(p => p.horaInicio).IsRequired();
            builder.Entity<promociones>().Property(p => p.ubicacion).IsRequired().HasMaxLength(50);
            builder.Entity<promociones>().Property(p => p.oferta).IsRequired().HasMaxLength(100);
            builder.Entity<promociones>().Property(p => p.precio).IsRequired();

            builder.Entity<Taller>().HasKey(t1 => t1.TallerId);
            builder.Entity<Taller>().Property(t1 => t1.TallerId).ValueGeneratedOnAdd();
            builder.Entity<Taller>().Property(t1 => t1.nombre).IsRequired().HasMaxLength(100);
            builder.Entity<Taller>().Property(t1 => t1.descripcion).IsRequired().HasMaxLength(500);
            builder.Entity<Taller>().Property(t1 => t1.ubicacion).IsRequired().HasMaxLength(50);
            builder.Entity<Taller>().Property(t1 => t1.horario).IsRequired().HasMaxLength(50);
            builder.Entity<Taller>().Property(t1 => t1.cupoMaximo).IsRequired();
            builder.Entity<Taller>().Property(t1 => t1.medidaSeguridad).IsRequired().HasMaxLength(100);
            builder.Entity<Taller>().Property(t1 => t1.ComunidadId).IsRequired();
            builder.Entity<Taller>().Property(t1 => t1.UsuarioId).IsRequired();

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

            builder.Entity<BookingState>().HasKey(bs => bs.booking_state_id);
            builder.Entity<BookingState>().Property(bs => bs.status).IsRequired().HasMaxLength(25);
            builder.Entity<BookingState>().HasOne(bs => bs.id).withMany(bs => bs.id);
        }
    }
}
