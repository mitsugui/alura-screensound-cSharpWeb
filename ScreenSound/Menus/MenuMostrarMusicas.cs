﻿using ScreenSound.Banco;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicas : Menu
{
    public override void Executar(ArtistaDal artistaDal)
    {
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Exibir detalhes do artista");
        Console.Write("Digite o nome do artista que deseja conhecer melhor: ");
        var nomeDoArtista = Console.ReadLine()!;

		var artista = artistaDal.MostrarPeloNome(nomeDoArtista);
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
