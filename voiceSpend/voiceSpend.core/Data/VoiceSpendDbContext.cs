using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using voiceSpend.Dominio.Entidades;

namespace voiceSpend.Dominio.Data
{
    public class VoiceSpendDbContext : DbContext
    {
        public VoiceSpendDbContext(DbContextOptions<VoiceSpendDbContext> options) : base(options) 
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transaccion> Transacciones {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaccion>()
                .Property(t => t.Monto)
                .HasPrecision(18, 2);
        }
    }
}
