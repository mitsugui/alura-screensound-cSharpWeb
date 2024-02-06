using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
	internal class MusicaDal : DAL<Musica>
	{
		private readonly ScreenSoundContext _context;

		public MusicaDal(ScreenSoundContext context)
		{
			_context = context;
		}

		public override IEnumerable<Musica> Listar()
		{
			return _context.Musicas.ToList();
		}

		public override Musica? Mostrar(int id)
		{
			return _context.Musicas
				.Find(id);
		}

		public override void Adicionar(Musica musica)
		{
			_context.Musicas.Add(musica);
			_context.SaveChanges();
		}

		public override void Atualizar(Musica musica)
		{
			_context.Musicas.Update(musica);
			_context.SaveChanges();
		}

		public override void Remover(Musica musica)
		{
			_context.Musicas.Remove(musica);
			_context.SaveChanges();
		}
	}
}
