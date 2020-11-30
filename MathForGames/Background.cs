using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Background : Actor
    {
        private static Sprite _sprite;

        public Background(float x, float y)
            : base(x, y)
        {
            _sprite = new Sprite("Backgrounds/black.png");
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
