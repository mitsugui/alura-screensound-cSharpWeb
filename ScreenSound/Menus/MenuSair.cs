using ScreenSound.Banco;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(ArtistaDal artistaDal)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
