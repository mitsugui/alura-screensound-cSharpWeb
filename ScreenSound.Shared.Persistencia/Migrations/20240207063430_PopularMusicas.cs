using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularMusicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "Alone, Pt. II", 2021 });
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "Faded", 2018 });
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "The Spectre", 2017 });
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "Man On The Moon", 2021 });


			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "Happier", 2018 });
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "Wolves", 2017 });
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "El Merengue", 2023 });
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "Fly", 2018 });


			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "This Love", 2009 });
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "Não deixe o amor morrer", 2009 });


			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "FU-JI-TSU", 1988 });
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "恋一夜", 1989 });
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "In the Sky", 1998 });
			migrationBuilder.InsertData("Musicas", new[] { "Nome", "AnoLancamento" },
				new object[] { "Yusha no Hata", 2023 });
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
