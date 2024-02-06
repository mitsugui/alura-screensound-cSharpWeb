using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
	internal class ArtistaDal
	{
		public IEnumerable<Artista> Listar()
		{
			using var connection = new ContextoDados().ObterConexao();
			connection.Open();

			var sql = "SELECT * FROM Artistas";
			using var cmd = new SqlCommand(sql, connection);
			using var reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				yield return new Artista(Convert.ToString(reader["Nome"]) ?? string.Empty, Convert.ToString(reader["Bio"]) ?? string.Empty)
				{
					Id = Convert.ToInt32(reader["id"]),
					FotoPerfil = Convert.ToString(reader["FotoPerfil"]) ?? string.Empty
				};
			}
		}

		public Artista? Mostrar(int id)
		{
			using var connection = new ContextoDados().ObterConexao();
			connection.Open();

			const string sql = "SELECT * FROM Artistas WHERE Id = @id";
			using var cmd = new SqlCommand(sql, connection);
			cmd.Parameters.AddWithValue("@id", id);

			using var reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				return new Artista(Convert.ToString(reader["Nome"]) ?? string.Empty, Convert.ToString(reader["Bio"]) ?? string.Empty)
				{
					Id = Convert.ToInt32(reader["id"]),
					FotoPerfil = Convert.ToString(reader["FotoPerfil"]) ?? string.Empty
				};
			}
			else
			{
				return null;
			}
		}

		public void Adicionar(Artista artista)
		{
			using var connection = new ContextoDados().ObterConexao();
			connection.Open();

			const string sql = @"
				INSERT INTO Artistas (Nome, FotoPerfil, Bio)
				VALUES (@nome, @fotoPerfil, @bio)";

			using var cmd = new SqlCommand(sql, connection);
			cmd.Parameters.AddWithValue("@nome", artista.Nome);
			cmd.Parameters.AddWithValue("@fotoPerfil", artista.FotoPerfil);
			cmd.Parameters.AddWithValue("@bio", artista.Bio);

			var resultado = cmd.ExecuteNonQuery();
			Console.WriteLine($"Linhas adicionadas: {resultado}");
		}

		public void Atualizar(Artista artista)
		{
			using var connection = new ContextoDados().ObterConexao();
			connection.Open();

			const string sql = @"
				UPDATE Artistas
				SET Nome = @nome, 
					FotoPerfil = @fotoPerfil,
					Bio = @bio
				WHERE Id = @id";

			using var cmd = new SqlCommand(sql, connection);
			cmd.Parameters.AddWithValue("@nome", artista.Nome);
			cmd.Parameters.AddWithValue("@fotoPerfil", artista.FotoPerfil);
			cmd.Parameters.AddWithValue("@bio", artista.Bio);
			cmd.Parameters.AddWithValue("@id", artista.Id);

			var resultado = cmd.ExecuteNonQuery();
			Console.WriteLine($"Linhas atualizadas: {resultado}");
		}

		public void Remover(int id)
		{
			using var connection = new ContextoDados().ObterConexao();
			connection.Open();

			const string sql = @"
				DELETE Artistas WHERE Id = @id";

			using var cmd = new SqlCommand(sql, connection);
			cmd.Parameters.AddWithValue("@id", id);

			var resultado = cmd.ExecuteNonQuery();
			Console.WriteLine($"Linhas excluídas: {resultado}");
		}
	}
}
