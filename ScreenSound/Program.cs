using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;


try
{
	var dal = new MusicaDal(new ScreenSoundContext());

    dal.Adicionar(new Musica("Música 1"));

	var musicaProcurada = dal.Listar().FirstOrDefault();

	if (musicaProcurada == null)
	{
        Console.WriteLine("Música não encontrada");
		return;
	}
	else
	{
        Console.WriteLine($"Música adicionada: {musicaProcurada}");
	}

	musicaProcurada.Nome = "Música renomeada";
    dal.Atualizar(musicaProcurada);

	foreach (var musica in dal.Listar())
	{
		Console.WriteLine(musica);
	}

    dal.Remover(musicaProcurada);

	if (!dal.Listar().Any())
	{
        Console.WriteLine("Lista de músicas vazia");
	}

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

return;



Dictionary<int, Menu> opcoes = new()
{
	{ 1, new MenuRegistrarArtista() },
	{ 2, new MenuRegistrarMusica() },
	{ 3, new MenuMostrarArtistas() },
	{ 4, new MenuMostrarMusicas() },
	{ -1, new MenuSair() }
};

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um artista");
    Console.WriteLine("Digite 2 para registrar a música de um artista");
    Console.WriteLine("Digite 3 para mostrar todos os artistas");
    Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    var opcaoEscolhida = Console.ReadLine()!;
    var opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.TryGetValue(opcaoEscolhidaNumerica, out var menuASerExibido))
    {
		menuASerExibido.Executar(new ArtistaDal(new ScreenSoundContext()));
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    } 
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();