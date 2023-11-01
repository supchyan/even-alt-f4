using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EvenAltF4.Code {
    public class DontDieBuff:ModBuff {
        public override void SetStaticDefaults() {
            Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
            int time = player.buffTime[buffIndex];
            Color col = new Color(255, 255, 2*time);
            float scl = 1.3f*(time/180f);
            Dust barier = Dust.NewDustPerfect(player.Center + new Vector2(0, -50f) + new Vector2(0f, -7f).RotatedBy(MathHelper.ToRadians(-6f*time)), DustID.PortalBolt, Vector2.Zero, 1, col, scl);
            barier.noGravity = true;
        }
    }
}