using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();




builder.Services.Configure<JsonOptions>(
	op => op.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();



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




app.Run();
