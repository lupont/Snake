using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
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

        #region Public constructors
        public Snake(float x, float y)
        {
            _body = new List<Vector2>() { new Vector2(0, 0) };
            SetDirection(1, 0);
        }
        #endregion

        #region Private methods

        #endregion

        #region Public methods
        public void SetTexture(GraphicsDevice graphicsDevice)
        {
            _texture = new Texture2D(graphicsDevice, Scale, Scale);
            var data = new Color[_texture.Width * _texture.Height];
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Green;
            _texture.SetData(data);
        }

        public void SetDirection(float dx, float dy)
        {
            _direction = new Vector2(dx * Scale, dy * Scale);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var part in _body)
                spriteBatch.Draw(_texture, part, Color.White);

            spriteBatch.End();
        }
        #endregion
    }
}