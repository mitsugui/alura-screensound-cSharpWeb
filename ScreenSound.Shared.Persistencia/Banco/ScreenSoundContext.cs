using Microsoft.EntityFrameworkCore;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.Shared.Persistencia.Banco
{
	public class ScreenSoundContext : DbContext
	{
		private const string ConenctionString = @"Data Source=BORDEAUX,11433;Initial Catalog=ScreenSoundDb;User ID=sa;Password=ScR33n$ound;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

		public DbSet<Artista> Artistas { get; set; }

		public DbSet<Musica> Musicas { get; set; }

		public DbSet<Genero> Generos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConenctionString)
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
