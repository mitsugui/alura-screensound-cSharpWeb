using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicas : Menu
{
	private readonly DAL<Artista> _artistaDal;

	public MenuMostrarMusicas(DAL<Artista> artistaDal)
	{
		_artistaDal = artistaDal;
	}


	public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Exibir detalhes do artista");
        Console.Write("Digite o nome do artista que deseja conhecer melhor: ");
        var nomeDoArtista = Console.ReadLine()!;

		var artista = _artistaDal.MostrarPor(a => a.Nome == nomeDoArtista);
        if (artista is not null)
        {
            Console.WriteLine("\nDiscografia:");
         
			artista.ExibirDiscografia();
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
