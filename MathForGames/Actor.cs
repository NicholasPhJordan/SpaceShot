using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Actor
    {
        protected Vector2 _velocity = new Vector2();
        protected Vector2 _acceleration = new Vector2();
        protected Matrix3 _globalTransform = new Matrix3();
        protected Matrix3 _localTransform = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];
        private float _maxSpeed = 5;

        public bool Started { get; private set; }

        public Vector2 WorldPosition
        {
            get { return new Vector2(_globalTransform.m13, _globalTransform.m23); }
        }

        public Vector2 LocalPosition
        {
            get { return new Vector2(_localTransform.m13, _localTransform.m23); }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Vector2 Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }

        public float MaxSpeed
        {
            get { return _maxSpeed; }
            set { _maxSpeed = value; }
        }

        //Actor Constructor
        public Actor(float x, float y)
        {
            _localTransform = new Matrix3();
            _globalTransform = new Matrix3();
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2();
        }

        public void AddChild(Actor child)
        {
            Actor[] tempArray = new Actor[_children.Length + 1];

            for (int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            tempArray[_children.Length] = child;
            _children = tempArray;
            child._parent = this;
        }

        public bool RemoveChild(Actor child)
        {
            bool childRemoved = false;

            if (child == null)
                return false;

            Actor[] tempArray = new Actor[_children.Length - 1];

            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if (child != _children[i])
                {
                    tempArray[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }
            }

            _children = tempArray;
            child._parent = null;
            return childRemoved;
        }

        public void SetTranslation(Vector2 position)
        {
            _translation = Matrix3.CreateTranslation(position);
        }

        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);

        }

        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(new Vector2(x, y));
        }

        private void UpdateTransform()
        {
            _localTransform = _translation * _rotation * _scale;

            if (_parent != null)
                _globalTransform = _parent._globalTransform * _localTransform;
            else
                _globalTransform = Game.GetCurrentScene().World * _localTransform;
        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateTransform();

            Velocity += Acceleration;

            if (Velocity.Magnitude > MaxSpeed)
                Velocity = Velocity.Normalized * MaxSpeed;

            //Increase position by the current velocity
            LocalPosition += _velocity * deltaTime;
        }

        public virtual void Draw()
        {
            //Only draws the actor on the console if it is within the bounds of the window
            if (WorldPosition.X >= 0 && WorldPosition.X < 300
                && WorldPosition.Y >= 0 && WorldPosition.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition((int)WorldPosition.X, (int)WorldPosition.Y);
            }

        }

        public virtual void End()
        {
            Started = false;
        }
    }
}
