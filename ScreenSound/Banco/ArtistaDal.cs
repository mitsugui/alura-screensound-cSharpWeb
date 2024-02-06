using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
	internal class ArtistaDal
	{
		private readonly ScreenSoundContext _context;

		public ArtistaDal(ScreenSoundContext context)
		{
			_context = context;
		}

		public IEnumerable<Artista> Listar()
		{
			return _context.Artistas
				.ToList();
		}

		public Artista? Mostrar(int id)
		{
			return _context.Artistas
				.Find(id);
		}

		public Artista? MostrarPeloNome(string nome)
		{
			return _context.Artistas
				.FirstOrDefault(a => a.Nome == nome);
		}

		public void Adicionar(Artista artista)
		{
			_context.Artistas
				.Add(artista);
			_context.SaveChanges();
		}

		public void Atualizar(Artista artista)
		{
			_context.Artistas
				.Update(artista);
			_context.SaveChanges();
		}

		public void Remover(Artista artista)
		{
			_context.Artistas.Remove(artista);
			_context.SaveChanges();
		}
	}
}
