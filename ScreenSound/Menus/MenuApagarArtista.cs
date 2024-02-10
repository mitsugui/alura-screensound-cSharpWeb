using ScreenSound.Shared.Modelos;
using ScreenSound.Shared.Persistencia.Banco;

namespace ScreenSound.Menus;

internal class MenuApagarArtista : Menu
{
	private readonly DAL<Artista> _artistaDal;

	public MenuApagarArtista(DAL<Artista> artistaDal)
	{
		_artistaDal = artistaDal;
	}

	public override void Executar()
	{
		base.Executar();
		ExibirTituloDaOpcao("Registro dos Artistas");
		Console.Write("Digite o nome do artista que deseja apagar: ");
		var nomeDoArtista = Console.ReadLine()!;
		
		var artista = _artistaDal.MostrarPor(a => a.Nome == nomeDoArtista);

		if (artista != null)
		{
			_artistaDal.Remover(artista);
			Console.WriteLine($"O artista {nomeDoArtista} foi apagado com sucesso!");
		}
		else
		{
			Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
		}

		Thread.Sleep(4000);
		Console.Clear();
	}
}
