using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Bullet : Actor
    {
        private static Sprite _sprite;

        //Bullet Constructor
        public Bullet(float x, float y)
            : base(x, y)
        {
            _sprite = new Sprite("PNG/Lasers/laserBlue16.png");
            Rotate(-1.6f);
            _velocity.X = 6.0F;
            _collisionRadius = 1;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            _sprite.Draw(_globalTransform);
        }
    }
}
