using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class AssociarMusicasAosArtistas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
				UPDATE Musicas 
				SET ArtistaId = (SELECT Id FROM Artistas WHERE Nome = 'Alan Walker')
				FROM Musicas
				WHERE Nome IN 
				(
					'Alone, Pt. II',
					'Faded',
					'The Spectre',
					'Man On The Moon'
				)");

			migrationBuilder.Sql(@"
				UPDATE Musicas 
				SET ArtistaId = (SELECT Id FROM Artistas WHERE Nome = 'Marshmello')
				FROM Musicas
				WHERE Nome IN 
				(
					'Happier',
					'Wolves',
					'El Merengue',
					'Fly'
				)");

			migrationBuilder.Sql(@"
				UPDATE Musicas 
				SET ArtistaId = (SELECT Id FROM Artistas WHERE Nome = 'Sambô')
				FROM Musicas
				WHERE Nome IN 
				(
					'This Love',
					'Não deixe o amor morrer'
				)");

			migrationBuilder.Sql(@"
				UPDATE Musicas 
				SET ArtistaId = (SELECT Id FROM Artistas WHERE Nome = 'Shizuka Kudo')
				FROM Musicas
				WHERE Nome IN 
				(
					'FU-JI-TSU',
					'恋一夜',
					'In the Sky',
					'Yusha no Hata'
				)");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
