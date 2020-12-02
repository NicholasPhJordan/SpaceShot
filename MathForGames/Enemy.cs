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
            Rotate(-1.6f);
            SetScale(2, 2);
            _velocity.X = -3;
            _collisionRadius = 1;
        }

        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);

            if (other is Player)
            {
                Raylib.DrawText("You Died\nPress Esc to quit", 100, 100, 100, Color.BLUE);
                Game.SetGameOver(true);
            }
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            _sprite.Draw(_globalTransform);
        }

    }
}
