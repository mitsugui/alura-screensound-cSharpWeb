using System.Text.Json.Serialization;
using ScreenSound.API.Endpoints;
using ScreenSound.Shared.Modelos;
using ScreenSound.Shared.Persistencia.Banco;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();
builder.Services.AddTransient<DAL<Genero>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(
	op => op.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddArtistasEndpoints();
app.AddMusicasEndpoints();
app.AddGenerosEndpoint();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
