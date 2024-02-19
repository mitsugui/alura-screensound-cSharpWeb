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
            return await _httpClient
				.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
        }

		public async Task<ArtistaResponse?> GetArtistaPorNomeAsync(string nomeArtista)
		{
			return await _httpClient
				.GetFromJsonAsync<ArtistaResponse>($"artistas/{nomeArtista}");
		}

		public async Task AddArtistaAsync(ArtistaRequest request)
		{
			await _httpClient
				.PostAsJsonAsync("artistas", request);
		}

		public async Task UpdateArtistaAsync(EditarArtistaRequest request)
		{
			await _httpClient
				.PutAsJsonAsync("artistas", request);
		}

		public async Task DeleteArtistaAsync(int idArtista)
		{
			await _httpClient
				.DeleteAsync($"artistas/{idArtista}");
		}
	}
}
