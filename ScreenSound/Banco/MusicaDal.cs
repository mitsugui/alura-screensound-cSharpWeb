using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
	internal class MusicaDal : DAL<Musica>
	{
		public MusicaDal(ScreenSoundContext context) : base(context)
		{
		}
	}
}
