using Terraria;
using Terraria.ModLoader;

namespace EvenAltF4.Code {
    public class DontDieBuff:ModBuff {
        public override void SetStaticDefaults() {
			Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) { // This method gets called every frame your buff is active on your player.
            player.immune = true;
            player.immuneNoBlink = true;
            player.immuneAlpha = 1;
        }
    }
}