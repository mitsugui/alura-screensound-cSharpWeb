using System.Net.Http.Json;
using ScreenSound.Web.Requests;
using ScreenSound.Web.Responses;

namespace ScreenSound.Web.Services
{
    public class ArtistasApi
    {
        private readonly HttpClient _httpClient;

        public ArtistasApi(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
        }

		public async Task<ICollection<MusicaResponse>?> GetMusicasPorGeneroAsync(string genero)
		{
			return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
		}

		public async Task AddArtistaAsync(ArtistaRequest request)
		{
			await _httpClient.PostAsJsonAsync("artistas", request);
		}
	}
}
