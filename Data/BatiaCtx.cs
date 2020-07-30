using Microsoft.EntityFrameworkCore;
using tbscore.Models;

namespace tbscore.Data
{
    public class BatiaCtx : DbContext
    {
        public BatiaCtx(DbContextOptions<BatiaCtx> options) : base(options)
        {
            
        }

        public DbSet<BTDato> BTDatos { get; set; }
        public DbSet<TGUsuario> TGUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BTDato>(entity =>
            {
                entity.HasKey(e => e.BTDatoID);
                entity.Property(e => e.Contenido).HasMaxLength(3000).IsUnicode(false);
                entity.Property(e => e.Origen).HasMaxLength(20).IsUnicode(false);
            });
            modelBuilder.Entity<TGUsuario>(entity =>
            {
                entity.HasKey(e => e.TGUsuarioID);
                entity.Property(e => e.Nombre).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Apellido).HasMaxLength(120).IsUnicode(false);
                entity.Property(e => e.Usuario).HasMaxLength(15).IsUnicode(false);
                entity.Property(e => e.Contrasena).HasMaxLength(15).IsUnicode(false);
                entity.Property(e => e.Correo).HasMaxLength(70).IsUnicode(false);
            });
        }

    }
}