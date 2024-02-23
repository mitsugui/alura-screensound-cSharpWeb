﻿using System.Net.Http.Json;
using ScreenSound.Web.Responses;

namespace ScreenSound.Web.Services;

public class GenerosApi
{
	private readonly HttpClient _httpClient;

	public GenerosApi(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("API");
	}

	public async Task<List<GeneroResponse>?> GetGenerosAsync()
	{
		return await _httpClient.GetFromJsonAsync<List<GeneroResponse>>("generos");
	}
	public async Task<GeneroResponse?> GetGeneroPorNomeAsync(string nome)
	{
		return await _httpClient.GetFromJsonAsync<GeneroResponse>($"generos/{nome}");
	}
}