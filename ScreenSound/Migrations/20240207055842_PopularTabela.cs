using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData("Artistas", new[] { "Nome", "Bio", "FotoPerfil" },
				new[]
				{
					"Alan Walker", "DJ e produtor musical norueguês",
					"https://i.scdn.co/image/ab67616d00001e02df9a35baaa98675256b35177"
				});
			migrationBuilder.InsertData("Artistas", new[] { "Nome", "Bio", "FotoPerfil" },
				new[]
				{
					"Marshmello", "DJ e produtor musical norte-americano",
					"https://s2-g1.glbimg.com/zKm4EGFX2QAEOXgBtsfYJIRNc3A=/0x0:2048x1365/1008x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_59edd422c0c84a879bd37670ae4f538a/internal_photos/bs/2017/R/t/OvEK9RSWiNUrqbUfl29A/30009872300-c7bb7716ea-k.jpg"
				});
			migrationBuilder.InsertData("Artistas", new[] { "Nome", "Bio", "FotoPerfil" },
				new[]
				{
					"Sambô", "Grupo musical de Samba Rock", "https://i.ytimg.com/vi/n_QKFb4OpNo/maxresdefault.jpg"
				});
			migrationBuilder.InsertData("Artistas", new[] { "Nome", "Bio", "FotoPerfil" },
				new[]
				{
					"Shizuka Kudo", "Shizuka Kudo é uma cantora e atriz japonesa",
					"https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png"
				});
		}

		/// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
