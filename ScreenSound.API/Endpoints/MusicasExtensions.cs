using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
	public static class MusicasExtensions
	{
		public static void AddMusicasEndpoints(this IEndpointRouteBuilder app)
		{

			app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) => Results.Ok(dal.Listar()));

			app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
			{
				var musica = dal.MostrarPor(a => a.Nome == nome);
				return musica is null
					? Results.NotFound()
					: Results.Ok(musica);
			});

			app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromServices] DAL<Artista> dalArtista, [FromBody] Musica musica) =>
			{
				var artista = musica.Artista?.Id != null
					? dalArtista.Mostrar(musica.Artista.Id)
					: null;
				if (artista == null)
				{
					Results.BadRequest("Informe o artista");
				}

				musica.Artista = artista;
				dal.Adicionar(musica);
				return Results.Ok();
			});

			app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
			{
				var musica = dal.Mostrar(id);
				if (musica is null) return Results.NotFound();

				dal.Remover(musica);
				return Results.NoContent();
			});

			app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
			{
				var musicaAtualizar = dal.Mostrar(musica.Id);
				if (musicaAtualizar is null)
				{
					return Results.NotFound();
				}

				musicaAtualizar.Nome = musica.Nome;
				musicaAtualizar.AnoLancamento = musica.AnoLancamento;

				dal.Atualizar(musicaAtualizar);
				return Results.Ok();
			});

		}
	}
}
