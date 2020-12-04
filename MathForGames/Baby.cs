using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Baby : Actor
    {
        private static Sprite _sprite;

        public Baby(float x, float y)
            : base(x, y)
        {
            _sprite = new Sprite("PNG/playerShip3_red.png");
            _collisionRadius = 1;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            _sprite.Draw(_globalTransform);
        }
    }
}
