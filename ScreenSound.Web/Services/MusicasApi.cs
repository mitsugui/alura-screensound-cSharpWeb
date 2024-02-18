using System.Net.Http.Json;
using ScreenSound.Web.Requests;
using ScreenSound.Web.Responses;

namespace ScreenSound.Web.Services
{
	public class MusicasApi
	{
		private readonly HttpClient _httpClient;

		public MusicasApi(IHttpClientFactory factory)
		{
			_httpClient = factory.CreateClient("API");
		}

		public async Task<ICollection<MusicaResponse>?> GetMusicasPorGeneroAsync(string genero)
		{
			return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
		}

		public async Task AddMusicaAsync(MusicaRequest request)
		{
			await _httpClient.PostAsJsonAsync("musicas", request);
		}
	}
}
