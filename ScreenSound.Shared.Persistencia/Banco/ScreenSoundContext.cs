using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.Shared.Persistencia.Banco
{
	public class ScreenSoundContext : DbContext
	{
		public DbSet<Artista> Artistas { get; set; }

		public DbSet<Musica> Musicas { get; set; }

		public DbSet<Genero> Generos { get; set; }

		//public ScreenSoundContext(){}

		public ScreenSoundContext(DbContextOptions<ScreenSoundContext> dbContext) 
			: base(dbContext)
		{
		}

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	var configuration = new ConfigurationBuilder()
		//		.Set
		//		.Build();
		//	optionsBuilder
		//		.UseSqlServer(configuration.Configuration
		//			.GetConnectionString("ScreenSoundDatabase"))
		//		.UseLazyLoadingProxies();
		//}

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
