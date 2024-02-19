using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Responses;
using ScreenSound.Shared.Modelos;
using ScreenSound.Shared.Persistencia.Banco;

namespace ScreenSound.API.Endpoints
{
	public static class ArtistasExtensions
	{
		public static void AddArtistasEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
			Results.Ok(dal.Listar()
				.Select(a => a.ToResponse())
				.ToList()));

			app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
			{
				var artista = dal.MostrarPor(a => a.Nome.Equals(nome, StringComparison.InvariantCultureIgnoreCase));
				return artista is null
					? Results.NotFound()
					: Results.Ok(artista.ToResponse());
			});

			app.MapPost("/Artistas", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
			{
				var nome = artistaRequest.Nome.Trim();
				if (dal.ExisteEntidadeCom(a =>
						nome.Equals(a.Nome, StringComparison.InvariantCultureIgnoreCase)))
				{
					return Results.BadRequest("Já exite um artista cadastrado com este nome.");
				}

				var imagemArtista = $"{DateTime.UtcNow:yyyyMMdd_hhss}_{nome}.jpeg";
				var path = Path.Combine(env.ContentRootPath, "wwwroot", "FotosPerfis", imagemArtista);

				using var ms = new MemoryStream(Convert.FromBase64String(artistaRequest.FotoPerfil!));
				using FileStream fs = new(path, FileMode.Create);
				await ms.CopyToAsync(fs);

				var artista = new Artista
				{
					Nome = artistaRequest.Nome,
					Bio = artistaRequest.Bio,
					FotoPerfil = $"/FotosPerfis/{imagemArtista}"
				};

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

			app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] EditarArtistaRequest editarArtista) =>
			{
				var artistaAtualizar = dal.Mostrar(editarArtista.Id);
				if (artistaAtualizar is null)
				{
					return Results.NotFound();
				}

				if (editarArtista.Nome is not null) artistaAtualizar.Nome = editarArtista.Nome;
				if (editarArtista.Bio is not null) artistaAtualizar.Bio = editarArtista.Bio;
				if (editarArtista.FotoPerfil is not null) artistaAtualizar.FotoPerfil = editarArtista.FotoPerfil;

				dal.Atualizar(artistaAtualizar);
				return Results.Ok();
			});

		}

		public static ArtistaResponse ToResponse(this Artista artista) =>
			new(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
	}
}
