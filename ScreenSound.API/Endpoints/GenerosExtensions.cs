using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Responses;
using ScreenSound.Shared.Modelos;
using ScreenSound.Shared.Persistencia.Banco;

namespace ScreenSound.API.Endpoints
{
    public static class GenerosExtensions
	{
		public static void AddGenerosEndpoint(this IEndpointRouteBuilder app)
		{
			app.MapGet("/Generos", ([FromServices] DAL<Genero> generosDal)
				=> Results.Ok(generosDal.Listar().ToResponse()));

			app.MapGet("/Generos/{nome}", ([FromServices] DAL<Genero> generosDal, string nome) =>
			{
				var genero = generosDal.MostrarPor(g =>
					nome.Equals(g.Nome, StringComparison.InvariantCultureIgnoreCase));
				return genero is null 
					? Results.NotFound() 
					: Results.Ok(genero.ToResponse());
			});

			app.MapPost("/Generos", ([FromServices] DAL<Genero> dal,
				[FromBody] GeneroRequest generoRequest) =>
			{
				if (dal.ExisteEntidadeCom(g => generoRequest.Nome.Equals(g.Nome, StringComparison.InvariantCultureIgnoreCase)))
				{
					return Results.BadRequest("Já exite um gênero cadastrado com este nome.");
				}

				var genero = new Genero
				{
					Nome = generoRequest.Nome,
					Descricao = generoRequest.Descricao
				};

				dal.Adicionar(genero);
				return Results.Created();
			});

			app.MapDelete("/Generos/{id}", ([FromServices] DAL<Genero> dal, int id) =>
			{
				var genero = dal.Mostrar(id);
				if (genero is null) return Results.NotFound();

				dal.Remover(genero);
				return Results.NoContent();
			});

			app.MapPut("/Generos", ([FromServices] DAL<Genero> dal, [FromBody] EditarGeneroRequest editarGenero) =>
			{
				var generoAtualizar = dal.Mostrar(editarGenero.Id);
				if (generoAtualizar is null)
				{
					return Results.NotFound();
				}

				if (editarGenero.Nome is not null) generoAtualizar.Nome = editarGenero.Nome;
				if (editarGenero.Descricao is not null) generoAtualizar.Descricao = editarGenero.Descricao;

				dal.Atualizar(generoAtualizar);
				return Results.Ok();
			});
		}

		private static GeneroResponse ToResponse(this Genero genero)
			=> new(genero.Id, genero.Nome, genero.Descricao);

		private static List<GeneroResponse> ToResponse(this IEnumerable<Genero> generos)
			=> generos
				.Select(g => g.ToResponse())
				.ToList();
	}
}
