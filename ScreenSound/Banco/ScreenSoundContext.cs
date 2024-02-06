using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
	internal class ScreenSoundContext : DbContext
	{
		private const string ConenctionString = @"Data Source=BORDEAUX;Initial Catalog=ScreenSoundDb;User ID=sa;Password=ScR33n$ound;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
		public DbSet<Artista> Artistas { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConenctionString);
		}
	}
}
