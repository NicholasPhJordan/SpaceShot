﻿using System;
using System.Collections.Generic;
using System.Text;

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
            _velocity.X = 6.0F;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            _sprite.Draw(_globalTransform);
        }
    }
}
