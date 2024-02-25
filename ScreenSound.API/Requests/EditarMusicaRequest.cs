namespace ScreenSound.API.Requests
{
	public record EditarMusicaRequest(int Id, string? Nome, int? AnoLancamento, int? IdArtista, ICollection<GeneroRequest>? Generos = null);
}
