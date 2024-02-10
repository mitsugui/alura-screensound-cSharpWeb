using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScreenSound.Menus;
using ScreenSound.Shared.Modelos;
using ScreenSound.Shared.Persistencia.Banco;

var configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	.AddEnvironmentVariables()
	.AddCommandLine(args)
	.Build();

var contextOptions = new DbContextOptionsBuilder<ScreenSoundContext>()
	.UseSqlServer(configuration
		.GetConnectionString("ScreenSoundDatabase"))
	.UseLazyLoadingProxies()
	.Options;

var screenSoundContext = new ScreenSoundContext(contextOptions);

Dictionary<int, Menu> opcoes = new()
{
	{ 1, new MenuRegistrarArtista(new DAL<Artista>(screenSoundContext)) },
	{ 2, new MenuRegistrarMusica(new DAL<Artista>(screenSoundContext)) },
	{ 3, new MenuMostrarArtistas(new DAL<Artista>(screenSoundContext)) },
	{ 4, new MenuMostrarMusicas(new DAL<Artista>(screenSoundContext)) },
	{ 5, new MenuMostrarMusicasPorAnoLancamento(new DAL<Musica>(screenSoundContext)) },
	{ 6, new MenuApagarArtista(new DAL<Artista>(screenSoundContext)) },
	{ 7, new MenuApagarMusica(new DAL<Musica>(screenSoundContext)) },
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
	Console.WriteLine("Digite 5 para exibir as músicas por ano de lançamento");
	Console.WriteLine("Digite 6 para apagar um artista");
	Console.WriteLine("Digite 7 para apagar uma música");
	Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    var opcaoEscolhida = Console.ReadLine()!;

	int opcaoEscolhidaNumerica;
	while (!int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica))
	{
		Console.WriteLine("Opção inválida");
	}

    if (opcoes.TryGetValue(opcaoEscolhidaNumerica, out var menuASerExibido))
    {
		menuASerExibido.Executar();
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    } 
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();