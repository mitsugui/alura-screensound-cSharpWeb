using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarArtista : Menu
{
	private readonly DAL<Artista> _artistaDal;

	public MenuRegistrarArtista(DAL<Artista> artistaDal)
	{
		_artistaDal = artistaDal;
	}

	public override void Executar()
	{
		base.Executar();
		ExibirTituloDaOpcao("Registro dos Artistas");
		Console.Write("Digite o nome do artista que deseja registrar: ");
		var nomeDoArtista = Console.ReadLine()!;
		
		Console.Write("Digite a bio do artista que deseja registrar: ");
		var bioDoArtista = Console.ReadLine()!;

		var artista = new Artista
		{
			Nome = nomeDoArtista,
			Bio = bioDoArtista
		};
		_artistaDal.Adicionar(artista);
		Console.WriteLine($"O artista {nomeDoArtista} foi registrado com sucesso!");
		
		Thread.Sleep(4000);
		Console.Clear();
	}
}
