using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ControlDeGastos.Models;

namespace ControlDeGastos.Data
{
    public class ControlDeGastosContext : IdentityDbContext<IdentityUser>
    {
        public ControlDeGastosContext(DbContextOptions<ControlDeGastosContext> options)
            : base(options)
        { }
     //   public DbSet<DepositoModel> Deposito { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Configuraciones adicionales (índices únicos, flujos, etc.)
        }
    }
}
