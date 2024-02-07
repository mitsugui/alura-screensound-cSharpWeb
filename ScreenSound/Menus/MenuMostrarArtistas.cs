using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarArtistas : Menu
{
	private readonly DAL<Artista> _artistaDal;

	public MenuMostrarArtistas(DAL<Artista> artistaDal)
	{
		_artistaDal = artistaDal;
	}

	public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        foreach (var artista in _artistaDal.Listar())
        {
            Console.WriteLine($"Artista: {artista.Nome}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
