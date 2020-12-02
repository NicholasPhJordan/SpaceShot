using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Enemy : Actor
    {
        private Sprite _sprite;

        public Enemy(float x, float y)
            : base(x, y)
        {
            _sprite = new Sprite("PNG/Enemies/enemyBlack3.png");
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            _sprite.Draw(_globalTransform);
        }

    }
}
