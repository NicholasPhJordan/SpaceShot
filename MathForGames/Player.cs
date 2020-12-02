using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed = 1;
        private static Sprite _sprite;
        private bool _canMove = true;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public Player(float x, float y)
            : base(x, y)
        {
            _sprite = new Sprite("PNG/playerShip1_red.png");
            Rotate(-1.58f);
            SetScale(2, 2);
            _collisionRadius = 1;
        }

        // Disable all player controls including movement and shooting.
        public void DisableControls()
        {
            _canMove = false;
        }

        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);

            if (other is Enemy)
            {
                Raylib.DrawText("You Died\nPress Esc to quit", 100, 100, 100, Color.BLUE);
                Game.SetGameOver(true);
            }
        }

        public override void Update(float deltaTime)
        {
            //If the player can't move, don't ask for input.
            if (!_canMove)
                return;

            int xDirection = -Convert.ToInt32(null);
            int yDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            //Set the actors current velocity to be the a vector with the direction found scaled by the speed
            Acceleration = new Vector2(xDirection, yDirection);
            Velocity = Velocity.Normalized * Speed;

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}