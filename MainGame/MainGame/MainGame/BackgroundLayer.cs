using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MainGame
{
    class BackgroundLayer
    {
        public Texture2D picture;
        public Vector2 position = Vector2.Zero;
        public Vector2 offset = Vector2.Zero;
        public float depth = 0.0f;
        public float moveRate = 0.0f;
        public Vector2 pictureSize = Vector2.Zero;
        public Color color = Color.White;
    }
}
