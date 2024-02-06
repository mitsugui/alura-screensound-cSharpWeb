using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
	internal abstract class DAL<T>
	{
		public abstract IEnumerable<T> Listar();
		public abstract T? Mostrar(int id);
		public abstract void Adicionar(T item);
		public abstract void Atualizar(T item);
		public abstract void Remover(T item);
	}
}
