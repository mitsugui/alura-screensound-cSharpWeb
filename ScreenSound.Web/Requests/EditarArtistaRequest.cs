namespace ScreenSound.API.Requests
{
	public record EditarArtistaRequest(int Id, string? Nome, string? Bio, string? FotoPerfil);
}
