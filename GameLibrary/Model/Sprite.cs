using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Model
{
    public abstract class Sprite
    {
        protected Texture2D Texture;
        protected Vector2 Position;
        public int Width
        {
            get { return Texture.Width; }
        }

        public int Height
        {
            get { return Texture.Height; }
        }

        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Width, Height); }
        }

        protected readonly Rectangle GameBoundaries;

        public Sprite(Texture2D texture, Vector2 position, Rectangle gameBoundaries)
        {
            this.Texture = texture;
            this.Position = position;
            this.GameBoundaries = GameBoundaries;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public abstract void Update(GameTime gameTime);

    }
}
