using ScreenSound.Shared.Modelos;
using ScreenSound.Shared.Persistencia.Banco;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
	private readonly DAL<Artista> _artistaDal;

	public MenuRegistrarMusica(DAL<Artista> artistaDal)
	{
		_artistaDal = artistaDal;
	}

	public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o artista cuja música deseja registrar: ");
        var nomeDoArtista = Console.ReadLine()!;

		var artista = _artistaDal.MostrarPor(a => a.Nome == nomeDoArtista);
        if (artista is not null)
        {
            Console.Write("Agora digite o título da música: ");
            var tituloDaMusica = Console.ReadLine()!;

			Console.Write("Digite o ano de lançamento: ");
			var anoLancamento = int.Parse(Console.ReadLine()!);

			artista.AdicionarMusica(new Musica(tituloDaMusica){AnoLancamento = anoLancamento});
            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");

            _artistaDal.Atualizar(artista);
            Thread.Sleep(4000);
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
