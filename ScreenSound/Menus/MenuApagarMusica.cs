using ScreenSound.Shared.Modelos;
using ScreenSound.Shared.Persistencia.Banco;

namespace ScreenSound.Menus;

internal class MenuApagarMusica : Menu
{
	private readonly DAL<Musica> _musicaDal;

	public MenuApagarMusica(DAL<Musica> musicaDal)
	{
		_musicaDal = musicaDal;
	}

	public override void Executar()
    {
		base.Executar();
		ExibirTituloDaOpcao("Registro dos músicas");
		Console.Write("Digite a música deseja apagar: ");
		var nomeDaMusica = Console.ReadLine()!;

		var musicas = _musicaDal.ListarPor(a => a.Nome == nomeDaMusica);

		if (musicas.Count == 1)
		{
			_musicaDal.Remover(musicas.First());
			Console.WriteLine($"A música {nomeDaMusica} foi apagada com sucesso!");
		}
		else if (musicas.Count > 1)
		{
			Console.WriteLine("Foram encontradas as seguintes músicas: ");
			for (var i = 0; i < musicas.Count; i++)
			{
				var musica = musicas[i];
				Console.WriteLine($"{i + 1}. Artista: {musica.Artista?.Nome} Ano Lançamento: {musica.AnoLancamento}");
			}

			Console.Write("Digite o número da música que deseja apagar: ");
			var numero = int.Parse(Console.ReadLine()!);
			_musicaDal.Remover(musicas[numero - 1]);
			Console.WriteLine($"A música {nomeDaMusica} foi apagada com sucesso!");
		}
		else
		{
			Console.WriteLine($"\nA música {nomeDaMusica} não foi encontrada!");
		}

		Thread.Sleep(4000);
		Console.Clear();

	}
}
