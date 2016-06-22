using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Game1 {
	interface Drawable {
		void Draw(SpriteBatch spriteBatch);
	}
	class Background : Drawable {
		Texture2D texture;
		Vector2 pos;
		public Background(Texture2D texture, Vector2 pos) {
			this.texture = texture;
			this.pos = pos;
		}
		public void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(this.texture, this.pos, Color.White);
		}
	}
	class Statics {
		public static Drawable getCheckers(GraphicsDeviceManager graphics) {
			int width = graphics.PreferredBackBufferWidth;
			int height = graphics.PreferredBackBufferHeight;
			Color[] data = new Color[width * 300];
			Texture2D texture = new Texture2D(graphics.GraphicsDevice, width , height);
			for (int i = 0; i < data.Length; i++) {

				data[i] = new Color(200, 100, 0, 255);
			}
			Statics.ActualDebug("Done");
			texture.SetData(data);
			return new Background(texture, new Vector2(0, 0));
		}

		public static void ActualDebug (string str) {
			System.Diagnostics.Debug.WriteLine("ACTUAL: " + str);
		}
	}
}