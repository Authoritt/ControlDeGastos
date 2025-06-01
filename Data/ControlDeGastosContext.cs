using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControlDeGastos.Data
{
    public class ControlDeGastosContext : IdentityDbContext<IdentityUser>
    {
        public ControlDeGastosContext(DbContextOptions<ControlDeGastosContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Configuraciones adicionales (índices únicos, flujos, etc.)
        }
    }
}
 