namespace ScreenSound.Web.Responses
{
	public record MusicaResponse(int Id, string Nome, int? AnoLancamento, int? IdArtista, string? NomeArtista, ICollection<GeneroResponse>? Generos = null);
}
