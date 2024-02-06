using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
	internal class ArtistaDal : DAL<Artista>
	{
		public ArtistaDal(ScreenSoundContext context) : base(context)
		{
		}
		
		public Artista? MostrarPeloNome(string nome)
		{
			return Context.Artistas
				.FirstOrDefault(a => a.Nome == nome);
		}
	}
}
