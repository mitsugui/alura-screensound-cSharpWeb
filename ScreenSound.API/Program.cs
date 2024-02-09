using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();




builder.Services.Configure<JsonOptions>(
	op => op.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();



app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
{
	return dal.Listar();
});

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

app.Run();
