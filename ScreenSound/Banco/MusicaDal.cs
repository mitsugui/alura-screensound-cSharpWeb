using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
	internal class MusicaDal
	{
		private readonly ScreenSoundContext _context;

		public MusicaDal(ScreenSoundContext context)
		{
			_context = context;
		}

		public IEnumerable<Musica> Listar()
		{
			return _context.Musicas.ToList();
		}

		public void Adicionar(Musica musica)
		{
			_context.Musicas.Add(musica);
			_context.SaveChanges();
		}

		public void Atualizar(Musica musica)
		{
			_context.Musicas.Update(musica);
			_context.SaveChanges();
		}

		public void Remover(Musica musica)
		{
			_context.Musicas.Remove(musica);
			_context.SaveChanges();
		}
	}
}
