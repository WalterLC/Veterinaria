using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;
namespace Veterinaria.Data
{
    public class VeterinariaContext: DbContext
    {
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options): base(options){}
        public DbSet<Veterinaria.Models.Mascota> Mascota { get; set; }
        public DbSet<Veterinaria.Models.Veterinario> Veterinario { get; set; }
        public DbSet<Veterinaria.Models.Medicamento> Medicamento { get; set; }
        public DbSet<Veterinaria.Models.Cita> Cita { get; set; }
        
        
    }
    
}
