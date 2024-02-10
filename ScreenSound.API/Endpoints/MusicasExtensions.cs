using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Responses;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
	public static class MusicasExtensions
	{
		public static void AddMusicasEndpoints(this IEndpointRouteBuilder app)
		{

			app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
			Results.Ok(dal.Listar()
				.Select(m => m.ToResponse())
				.ToList()));

			app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
			{
				var musica = dal.MostrarPor(m => m.Nome.Equals(nome, StringComparison.InvariantCultureIgnoreCase));
				return musica is null
					? Results.NotFound()
					: Results.Ok(musica.ToResponse());
			});

			app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromServices] DAL<Artista> dalArtista, [FromBody] MusicaRequest musicaRequest) =>
			{
				var artista = dalArtista.Mostrar(musicaRequest.IdArtista);
				if (artista == null)
				{
					Results.BadRequest("Informe o artista");
				}

				var musica = new Musica(musicaRequest.Nome)
				{
					AnoLancamento = musicaRequest.AnoLancamento,
					Artista = artista
				};

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

			app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] EditarMusicaRequest editarMusica) =>
			{
				var musicaAtualizar = dal.Mostrar(editarMusica.Id);
				if (musicaAtualizar is null)
				{
					return Results.NotFound();
				}

				if (editarMusica.Nome is not null) musicaAtualizar.Nome = editarMusica.Nome;
				if (editarMusica.AnoLancamento is not null) musicaAtualizar.AnoLancamento = editarMusica.AnoLancamento;

				dal.Atualizar(musicaAtualizar);
				return Results.Ok();
			});

		}

		public static MusicaResponse ToResponse(this Musica musica)
			=> new(musica.Id, musica.Nome, musica.AnoLancamento, musica.Artista?.Id, musica.Artista?.Nome);
	}
}
