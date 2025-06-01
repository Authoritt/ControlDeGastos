using ControlDeGastos.Models;
using ControlDeGastosControlDeGastos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ControlDeGastos.Data
{
    public class ControlDeGastosContext : IdentityDbContext<IdentityUser>
    {
        public ControlDeGastosContext(DbContextOptions<ControlDeGastosContext> options)
            : base(options)
        {
        }

        // DbSets para cada entidad
        public DbSet<TipoGastoModel> TiposGasto { get; set; }
        public DbSet<FondoMonetarioModel> FondosMonetarios { get; set; }
        public DbSet<PresupuestoModel> Presupuestos { get; set; }
        public DbSet<GastoEncabezadoModel> GastosEncabezado { get; set; }
        public DbSet<GastoDetalleModel> GastosDetalle { get; set; }
        public DbSet<DepositoModel> Depositos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuración de relaciones y restricciones
            modelBuilder.Entity<GastoEncabezadoModel>()
                .HasMany(g => g.Detalles)
                .WithOne(d => d.Encabezado)
                .HasForeignKey(d => d.encabezado_id)
                .OnDelete(DeleteBehavior.Cascade); // Eliminación en cascada

            modelBuilder.Entity<TipoGastoModel>()
                .HasIndex(t => t.nombre)
                .IsUnique(); // Código único

            modelBuilder.Entity<FondoMonetarioModel>()
                .Property(f => f.tipo)
                .HasConversion<string>()
                .HasMaxLength(20);

            //// Configuración de precisión decimal
            //modelBuilder.Entity<GastoDetalleModel>()
            //    .Property(g => g.monto)
            //    .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<DepositoModel>()
            //    .Property(d => d.monto)
            //    .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<PresupuestoModel>()
            //    .Property(p => p.monto)
            //    .HasColumnType("decimal(18,2)");
        }
    }
}
