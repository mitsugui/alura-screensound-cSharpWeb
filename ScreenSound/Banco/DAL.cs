using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
	internal abstract class DAL<T> where T : class
	{
		protected readonly ScreenSoundContext Context;

		protected DAL(ScreenSoundContext context)
		{
			Context = context;
		}

		public IEnumerable<T> Listar()
		{
			return Context.Set<T>()
				.ToList();
		}

		public T? Mostrar(int id)
		{
			return Context.Set<T>()
				.Find(id);
		}

		public void Adicionar(T item)
		{
			Context.Set<T>()
				.Add(item);
			Context.SaveChanges();
		}

		public void Atualizar(T item)
		{
			Context.Set<T>()
				.Update(item);
			Context.SaveChanges();
		}

		public void Remover(T item)
		{
			Context.Set<T>()
				.Remove(item);
			Context.SaveChanges();
		}
	}
}
