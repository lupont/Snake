using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using static SnakeGame.Globals;

namespace SnakeGame
{
    public class Snake
    {
        #region Private fields
        private Texture2D _texture;
        private List<Vector2> _body;
        private Vector2 _direction;
        #endregion

        #region Public properties
        public Vector2 Direction
        {
            get => _direction;
            set => SetDirection(value.X, value.Y);
        } 
        #endregion

        #region Public constructors
        public Snake(float x, float y)
        {
            _body = new List<Vector2>() { new Vector2(0, 0) };
            SetDirection(1, 0);
        }
        #endregion

        #region Public indexers
        public Vector2 this[int index] => _body[index];
        #endregion

        #region Private methods
        public void SetDirection(float dx, float dy)
        {
            _direction = new Vector2(dx * Scale, dy * Scale);
        }
        #endregion

        #region Public methods
        public void Grow()
        {
            var head = _body[0];
            _body.Insert(0, head + _direction);
        }

        public void Shrink()
        {
            if (_body.Count == 0)
                return;
            _body.RemoveAt(_body.Count - 1);
        }

        public bool Eats(Apple apple)
        {
            var head = _body[0];
            return head.X == apple.Position.X && head.Y == apple.Position.Y;
        }

        public void SetTexture(GraphicsDevice graphicsDevice)
        {
            _texture = new Texture2D(graphicsDevice, Scale, Scale);
            var data = new Color[_texture.Width * _texture.Height];
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Green;
            _texture.SetData(data);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var part in _body)
            {
                var color = _body.IndexOf(part) == 0 ? Color.LightGreen : Color.Green;
                spriteBatch.Draw(_texture, part, color);
            }

            spriteBatch.End();
        }
        #endregion
    }
}