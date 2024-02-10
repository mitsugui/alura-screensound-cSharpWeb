using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.Shared.Persistencia.Banco
{
	public class ScreenSoundContext : DbContext
	{
		private readonly string? _conenctionString;

		public DbSet<Artista> Artistas { get; set; }

		public DbSet<Musica> Musicas { get; set; }

		public DbSet<Genero> Generos { get; set; }

		public ScreenSoundContext(IConfiguration configuration)
		{
			_conenctionString = configuration.GetConnectionString("ScreenSoundDatabase");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_conenctionString)
				.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Artista>()
				.HasMany(a => a.Musicas)
				.WithOne(m => m.Artista)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder
				.Entity<Musica>()
				.HasMany(m => m.Generos)
				.WithMany(g => g.Musicas);
		}
	}
}
