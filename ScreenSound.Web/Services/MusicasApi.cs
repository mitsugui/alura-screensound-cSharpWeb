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

		public async Task<MusicaResponse?> GetMusicaPorNomeAsync(string nomeMusica)
		{
			return await _httpClient.GetFromJsonAsync<MusicaResponse>($"musicas/{nomeMusica}");
		}

		public async Task<ICollection<MusicaResponse>?> GetMusicasPorGeneroAsync(string genero)
		{
			return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>($"musicas/generos/{genero}");
		}

		public async Task<ICollection<MusicaResponse>?> GetMusicasPorArtistaAsync(string artista)
		{
			return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>($"musicas/artistas/{artista}");
		}

		public async Task AddMusicaAsync(MusicaRequest request)
		{
			await _httpClient.PostAsJsonAsync("musicas", request);
		}

		public async Task UpdateMusicaAsync(EditarMusicaRequest request)
		{
			await _httpClient.PutAsJsonAsync("musicas", request);
		}

		public async Task DeleteMusicaAsync(int id)
		{
			await _httpClient.DeleteAsync($"musicas/{id}");
		}
	}
}
