using System.IO;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace EvenAltF4.Code {
    public class StopResetPosition:ModPlayer {
        private Vector2 playerLocation;
        public override void OnEnterWorld() {
            Main.LocalPlayer.AddBuff(ModContent.BuffType<DontDieBuff>(), 120);
            LoadLocation();
        }
        public override bool ImmuneTo(PlayerDeathReason damageSource, int cooldownCounter, bool dodgeable) {
            return Main.LocalPlayer.HasBuff<DontDieBuff>();
        }
        public override void PreUpdateMovement() {
            playerLocation = Main.LocalPlayer.position;
            if(!Main.LocalPlayer.active) return;
            SaveLocation();
        }
        public void LoadLocation() {
            try {
                StreamReader sr = new StreamReader($"{Main.worldName}.txt");
                string loc = sr.ReadLine();
                if(loc!=null) {
                    string[] tempArr;
                    tempArr = loc.Replace("{X:","").Replace("}","").Split(" Y:");
                    playerLocation.X = float.Parse(tempArr[0]);
                    playerLocation.Y = float.Parse(tempArr[1]);
                    Main.LocalPlayer.position = playerLocation;
                }
            } catch {
                Main.NewText("\n\n\n\n\n\n\n\n\n");
                return;
            }
        }
        public void SaveLocation() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(playerLocation.ToString());
            File.WriteAllText($"{Main.worldName}.txt", sb.ToString());
        }
    }
}