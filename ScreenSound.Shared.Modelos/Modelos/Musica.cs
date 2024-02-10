﻿namespace ScreenSound.Shared.Modelos;

public class Musica
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public int? AnoLancamento { get; set; }

    public virtual Artista? Artista { get; set; }

	public virtual ICollection<Genero> Generos { get; set; }

	public Musica(string nome)
    {
        Nome = nome;
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
		Console.WriteLine($"Ano de Lançamento: {AnoLancamento}");
	}

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}