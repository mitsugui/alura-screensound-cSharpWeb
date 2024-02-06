using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
	internal class ContextoDados
	{
		private const string ConenctionString = @"Data Source=BORDEAUX;Initial Catalog=ScreenSoundDb;User ID=sa;Password=ScR33n$ound;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

		public SqlConnection ObterConexao()
		{
			return new SqlConnection(ConenctionString);
		}
	}
}
