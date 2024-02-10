namespace ScreenSound.Shared.Persistencia.Banco
{
	public class DAL<T> where T : class
	{
		private readonly ScreenSoundContext _context;

		public DAL(ScreenSoundContext context)
		{
			_context = context;
		}

		public IEnumerable<T> Listar()
		{
			return _context.Set<T>()
				.ToList();
		}

		public bool ExisteEntidadeCom(Func<T, bool> condicao)
		{
			return _context.Set<T>()
				.Any(condicao);
		}

		public T? Mostrar(int id)
		{
			return _context.Set<T>()
				.Find(id);
		}

		public T? MostrarPor(Func<T, bool> condicao)
		{
			return _context.Set<T>()
				.FirstOrDefault(condicao);
		}

		public List<T> ListarPor(Func<T, bool> condicao)
		{
			return _context.Set<T>()
				.Where(condicao)
				.ToList();
		}

		public void Adicionar(T item)
		{
			_context.Set<T>()
				.Add(item);
			_context.SaveChanges();
		}

		public void Atualizar(T item)
		{
			_context.Set<T>()
				.Update(item);
			_context.SaveChanges();
		}

		public void Remover(T item)
		{
			_context.Set<T>()
				.Remove(item);
			_context.SaveChanges();
		}
	}
}
