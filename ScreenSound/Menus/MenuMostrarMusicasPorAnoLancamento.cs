using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorAnoLancamento : Menu
{
	private readonly DAL<Musica> _musicaDal;

	public MenuMostrarMusicasPorAnoLancamento(DAL<Musica> musicaDal)
	{
		_musicaDal = musicaDal;
	}


	public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Exibir músicas por ano de lançamento");
        Console.Write("Digite o ano de lançamento: ");
        var anoLancamento = int.Parse(Console.ReadLine()!);

		var musicas = _musicaDal.ListarPor(m => m.AnoLancamento == anoLancamento);
        if (musicas.Count > 0)
        {
            Console.WriteLine($"\nMúsicas Lançadas em {anoLancamento}:");

			foreach (var musica in musicas)
			{
                musica.ExibirFichaTecnica();
			}
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("\nNenhuma música encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
