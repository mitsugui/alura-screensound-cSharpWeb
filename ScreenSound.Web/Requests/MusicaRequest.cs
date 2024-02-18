namespace ScreenSound.Web.Requests
{
	public record MusicaRequest(string Nome, int? AnoLancamento, int IdArtista, ICollection<GeneroRequest>? Generos = null);
}
