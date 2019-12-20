using Terraria.ModLoader;

namespace ToshnikaMod
{
	public class ToshnikaMod : Mod
	{
        internal static ToshnikaMod instance;
        public override void Load()
        {
            instance = this;
        }
        }
}