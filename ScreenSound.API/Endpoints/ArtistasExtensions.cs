using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
	public static class ArtistasExtensions
	{
		public static void AddArtistasEndpoints(this IEndpointRouteBuilder app)
		{

			app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) => dal.Listar());

			app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
			{
				var artista = dal.MostrarPor(a => a.Nome == nome);
				return artista is null
					? Results.NotFound()
					: Results.Ok(artista);
			});

			app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
			{
				dal.Adicionar(artista);
				return Results.Ok();
			});

			app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
			{
				var artista = dal.Mostrar(id);
				if (artista is null) return Results.NotFound();

				dal.Remover(artista);
				return Results.NoContent();
			});

			app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
			{
				var artistaAtualizar = dal.Mostrar(artista.Id);
				if (artistaAtualizar is null)
				{
					return Results.NotFound();
				}

				artistaAtualizar.Nome = artista.Nome;
				artistaAtualizar.Bio = artista.Bio;
				artistaAtualizar.FotoPerfil = artista.FotoPerfil;

				dal.Atualizar(artistaAtualizar);
				return Results.Ok();
			});

		}
	}
}
