using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using System.Text;
using System.IO;

namespace EvenAltF4.Code {
    public class StopResetPosition:ModPlayer {
        private Vector2 playerLocation;
        public override void OnEnterWorld() {
            // Main.NewText($"{Main.worldName}.txt");
            LoadLocation();
        }
        public override void PostUpdate() {
            playerLocation = Main.LocalPlayer.position;
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